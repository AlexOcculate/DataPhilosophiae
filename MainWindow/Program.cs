namespace DataPhilosophiae
{
   using ActiveQueryBuilder.Core;
   using DataPhilosophiae.ConfigurationSetting;
   using DataPhilosophiae.DataModel;
   using System;
   using System.Data;
   using System.Linq;

   static class Program
   {
      [System.Runtime.InteropServices.DllImport( "kernel32.dll", SetLastError = true )]
      [return: System.Runtime.InteropServices.MarshalAs( System.Runtime.InteropServices.UnmanagedType.Bool )]
      static extern bool AllocConsole();

      //private static System.ComponentModel.BindingList<DataStore> list;
      private static DataStoreTable dsTbl;
      private static System.Data.DataSet dataset;

      //      private static System.Configuration.Configuration cm = System.Configuration.ConfigurationManager.OpenExeConfiguration( System.Configuration.ConfigurationUserLevel.None );

      [System.STAThread]
      static void Main()
      {
         AllocConsole( );
         System.Windows.Forms.Application.EnableVisualStyles( );
         System.Windows.Forms.Application.SetCompatibleTextRenderingDefault( false );
         DevExpress.UserSkins.BonusSkins.Register( );
         DevExpress.Skins.SkinManager.EnableFormSkins( );

         //list = LoadConfigurationSettings( );
         //dataset = LoadConfigurationSettings2( );
         dataset = createDataSetMetadata( );
         loadDataSetDataValue( dataset );
         loadAQB( dataset );
         //System.Windows.Forms.Application.Run( new XtraForm2( list ) );
         //System.Windows.Forms.Application.Run( new XtraForm3( dataset ) );
         System.Windows.Forms.Application.Run( new XtraForm3( dataset ) );
      }

      private static void loadAQB( System.Data.DataSet ds )
      {
         /*
            ActiveQueryBuilder.Core.SyntaxProviderList syntaxProviderList = new ActiveQueryBuilder.Core.SyntaxProviderList( );
            //
            ActiveQueryBuilder.Core.SQLContext sc = new ActiveQueryBuilder.Core.SQLContext( )
            {
               SyntaxProvider = new ActiveQueryBuilder.Core.SQLiteSyntaxProvider( ),
               MetadataProvider = new ActiveQueryBuilder.Core.SQLiteMetadataProvider( )
               {
                  Connection = new System.Data.SQLite.SQLiteConnection( )
                  {
                     ConnectionString = cs.ConnectionString
                  }
               }
            };
            ActiveQueryBuilder.Core.MetadataLoadingOptions loadingOptions = sc.MetadataContainer.LoadingOptions;
            loadingOptions.LoadDefaultDatabaseOnly = ds.LoadDefaultDatabaseOnly == 1 ? true : false;
            loadingOptions.LoadSystemObjects = ds.LoadSystemObjects == 1 ? true : false;
            //loadingOptions.IncludeFilter.Types = MetadataType.Field;
            //loadingOptions.ExcludeFilter.Schemas.Add(“dbo”);
            sc.MetadataContainer.LoadAll( ds.WithFields == 1 ? true : false );
         */
         {
            var resultSet = from p in ds.Tables[ "DataStore" ].AsEnumerable( )
                            join c in ds.Tables[ "DataStoreSnapshot" ].AsEnumerable( )
                            on p[ "Name" ] equals c[ "Name" ]
                            //@#$% where p.Field<bool?>( "IsActive" ) == true
                            //@#$% && c.Field<bool?>( "IsActive" ) == true
                            select new
                            {
                               StagePathDir = (string) p[ "StagePathDir" ],
                               SnapshotFile = (System.IO.FileInfo) c[ "SnapshotFile" ]
                            }
                    ;
            foreach( var item in resultSet )
            {
               string combine = System.IO.Path.Combine( item.StagePathDir, item.SnapshotFile.Name );
               ActiveQueryBuilder.Core.SQLContext sc = new ActiveQueryBuilder.Core.SQLContext( )
               {
                  SyntaxProvider = new ActiveQueryBuilder.Core.SQLiteSyntaxProvider( ),
                  //MetadataProvider = new ActiveQueryBuilder.Core.SQLiteMetadataProvider( )
                  //{
                  //   Connection = new System.Data.SQLite.SQLiteConnection( )
                  //   {
                  //      ConnectionString = cs.ConnectionString
                  //   }
                  //}
               };
               sc.MetadataContainer.LoadingOptions.OfflineMode = true;
               sc.MetadataContainer.ImportFromXML( combine );
               BuildBindingList( ds, sc );
            }
         }
      }

      #region --- EXTRACT METADATA VALUES ---

      private class StackItem
      {
         public ActiveQueryBuilder.Core.MetadataList list;
         public int index;
         public int parentID;
         public int grandParentID;
      }
      private static void BuildBindingList( DataSet ds, ActiveQueryBuilder.Core.SQLContext sc )
      {
         //System.ComponentModel.BindingList<DataModel.MetadataItem> list = new System.ComponentModel.BindingList<DataModel.MetadataItem>( );

         using( ActiveQueryBuilder.Core.MetadataList miList = new ActiveQueryBuilder.Core.MetadataList( sc.MetadataContainer ) )
         {
            miList.Load( ActiveQueryBuilder.Core.MetadataType.All, true );
            System.Collections.Generic.Stack<StackItem> stack = new System.Collections.Generic.Stack<StackItem>( );
            stack.Push( new StackItem { list = miList, index = 0, parentID = -1, grandParentID = -1 } );
            do
            {
               StackItem si = stack.Pop( );
               ActiveQueryBuilder.Core.MetadataList actualMIList = si.list;
               int actualIndex = si.index;
               int actualParentID = si.grandParentID; // IMPORTANT!!!
               {
                  for( ; actualIndex < actualMIList.Count; actualIndex++ )
                  {
                     ExtractMetadataItem( ds, actualMIList[ actualIndex ], actualParentID );
                     if( actualMIList[ actualIndex ].Items.Count > 0 ) // branch...
                     {
                        // Push the "next" Item...
                        stack.Push( new StackItem
                        {
                           list = actualMIList,
                           index = actualIndex + 1,
                           //parentID = list[ list.Count - 1 ].ID,
                           grandParentID = actualParentID
                        } );
                        // Reset the loop to process the "actual" Item...
                        //actualParentID = list[ list.Count - 1 ].ID;
                        actualMIList = actualMIList[ actualIndex ].Items;
                        actualIndex = -1;
                     }
                  } // for(;;)...
               }
            } while( stack.Count > 0 );
         } // using()...

      } // buildBindingList(...)
      private static void BuildBindingListOLD( DataSet ds, ActiveQueryBuilder.Core.SQLContext sc )
      {
         //System.ComponentModel.BindingList<DataModel.MetadataItem> list = new System.ComponentModel.BindingList<DataModel.MetadataItem>( );
         using( var sqlContext = new ActiveQueryBuilder.Core.SQLContext( ) )
         {
            sqlContext.Assign( sc );
            sqlContext.MetadataContainer.LoadingOptions.OfflineMode = true;
            //sqlContext.MetadataContainer.LoadingOptions.LoadDefaultDatabaseOnly = false;
            //sqlContext.MetadataContainer.LoadingOptions.LoadSystemObjects = false;

            using( ActiveQueryBuilder.Core.MetadataList miList = new ActiveQueryBuilder.Core.MetadataList( sqlContext.MetadataContainer ) )
            {
               miList.Load( ActiveQueryBuilder.Core.MetadataType.All, true );
               System.Collections.Generic.Stack<StackItem> stack = new System.Collections.Generic.Stack<StackItem>( );
               stack.Push( new StackItem { list = miList, index = 0, parentID = -1, grandParentID = -1 } );
               do
               {
                  StackItem si = stack.Pop( );
                  ActiveQueryBuilder.Core.MetadataList actualMIList = si.list;
                  int actualIndex = si.index;
                  int actualParentID = si.grandParentID; // IMPORTANT!!!
                  {
                     for( ; actualIndex < actualMIList.Count; actualIndex++ )
                     {
                        //ExtractMetadataItem( ds, actualMIList[ actualIndex ], actualParentID );
                        if( actualMIList[ actualIndex ].Items.Count > 0 ) // branch...
                        {
                           // Push the "next" Item...
                           stack.Push( new StackItem
                           {
                              list = actualMIList,
                              index = actualIndex + 1,
                              //parentID = list[ list.Count - 1 ].ID,
                              grandParentID = actualParentID
                           } );
                           // Reset the loop to process the "actual" Item...
                           //actualParentID = list[ list.Count - 1 ].ID;
                           actualMIList = actualMIList[ actualIndex ].Items;
                           actualIndex = -1;
                        }
                     } // for(;;)...
                  }
               } while( stack.Count > 0 );
            } // using()...
         } // using()...
      } // buildBindingList(...)


      private static void ExtractMetadataItem(
         DataSet list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         switch( mi.Type )
         {
            case ActiveQueryBuilder.Core.MetadataType.Root:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Server:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Database:
               ExtractNamespace( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Schema:
               ExtractNamespace( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Package:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Namespaces:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Table:
               ExtractTable( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.View:
               ExtractTable( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Procedure:
               ExtractProcedure( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Synonym:
               ExtractSynonym( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Objects:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Aggregate:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Parameter:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Field:
               ExtractField( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.ForeignKey:
               ExtractForeignKey( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.ObjectMetadata:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.UserQuery:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.UserField:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.All:
               ExtractItem( list, mi, parentID );
               break;
            default:
               ExtractItem( list, mi, parentID );
               break;
         } // switch()...
      }
      private static void ExtractProcedure(
         DataSet list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         {
            ActiveQueryBuilder.Core.MetadataObject m = mi as ActiveQueryBuilder.Core.MetadataObject;
         }
      }
      private static void ExtractSynonym(
         DataSet list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         {
            ActiveQueryBuilder.Core.MetadataObject m = mi as ActiveQueryBuilder.Core.MetadataObject;
            o.ReferencedObject = m.ReferencedObject?.NameFull;
            //
            for( int i = 0; i < m.ReferencedObjectName.Count; i++ )
            {
               ActiveQueryBuilder.Core.MetadataQualifiedNamePart x = m.ReferencedObjectName[ i ];
               o.ReferencedObjectName += "["
               + System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), x.Type )
               + ":"
               + x.Name
               + "]"
            ;
            }
         }
      }
      private static void ExtractNamespace(
         DataSet list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         {
            ActiveQueryBuilder.Core.MetadataNamespace m = mi as ActiveQueryBuilder.Core.MetadataNamespace;
         }
      }
      private static void ExtractTable(
         DataSet list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         {
            ActiveQueryBuilder.Core.MetadataObject m = mi as ActiveQueryBuilder.Core.MetadataObject;
         }
      }
      private static void ExtractForeignKey(
         DataSet list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         o.FieldType = null;
         {
            ActiveQueryBuilder.Core.MetadataForeignKey m = mi as ActiveQueryBuilder.Core.MetadataForeignKey;
            o.ReferencedObject = m.ReferencedObject.NameFull;
            //
            for( int i = 0; i < m.ReferencedObjectName.Count; i++ )
            {
               ActiveQueryBuilder.Core.MetadataQualifiedNamePart x = m.ReferencedObjectName[ i ];
               o.ReferencedObjectName += "["
               + System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), x.Type )
               + ":"
               + x.Name
               + "]"
            ;
            }
            //
            o.ReferencedFieldsCount = m.ReferencedFields.Count;
            for( int i = 0; i < m.ReferencedFields.Count; i++ )
            {
               o.ReferencedFields += "[" + m.ReferencedFields[ i ] + "]"
            ;
            }
            //
            o.ReferencedCardinality = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataForeignKeyCardinality ), m.ReferencedCardinality );
            //
            o.FieldsCount = m.Fields.Count;
            for( int i = 0; i < m.Fields.Count; i++ )
            {
               o.Fields += "[" + m.Fields[ i ] + "]"
            ;
            }
            //
            o.Cardinality = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataForeignKeyCardinality ), m.Cardinality );
         }
      }
      private static void ExtractField(
         DataSet list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         {
            ActiveQueryBuilder.Core.MetadataField m = mi as ActiveQueryBuilder.Core.MetadataField;
            o.Expression = m.Expression;
            o.FieldType = System.Enum.GetName( typeof( System.Data.DbType ), m.FieldType );
            o.FieldTypeName = m.FieldTypeName;
            o.IsNullable = m.Nullable;
            o.Precision = m.Precision;
            o.Scale = m.Scale;
            o.Size = m.Size;
            o.IsPK = m.PrimaryKey;
            o.IsRO = m.ReadOnly;
         }
      }
      private static DataModel.MetadataItem ExtractItem(
         DataSet list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         var o = new DataModel.MetadataItem( );
         {
            o.MetadataProvider = mi.SQLContext?.MetadataProvider.Description;
            o.SyntaxProvider = mi.SQLContext?.SyntaxProvider.Description;
            o.ID = list.Count;
            o.ParentID = parentID;
            if( mi.Parent != null )
            {
               o.ParentType = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), mi.Parent.Type );
            }
            o.Type = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), mi.Type );
            o.IsSystem = mi.System;
            //
            // o.RootName = item.Root?.Name;
            o.Server = mi.Server?.Name;
            o.Database = mi.Database?.Name;
            o.Schema = mi.Schema?.Name;
            o.ObjectName = mi.Object?.Name;
            //
            o.NameFullQualified = mi.NameFull;
            o.NameFullQualified += mi.NameFull.EndsWith( "." ) ? "<?>" : "";
            o.NameQuoted = mi.NameQuoted;
            o.AltName = mi.AltName;
            o.Field = mi.Name != null ? mi.Name : "<?>";
            //
            //
            o.HasDefault = mi.Default;
            o.Description = mi.Description;
            o.Tag = mi.Tag;
            o.UserData = mi.UserData;
         }
         list.Add( o );
         return o;
      }

      #endregion

      private static System.Data.DataSet LoadConfigurationSettings2()
      {
         System.Data.DataSet set = new System.Data.DataSet( "X" );
         DataStoreTable dst = new DataStoreTable( );
         System.Data.DataTable tbl = dst.DataStore;
         DataStoreSnapshotTable dsst = new DataStoreSnapshotTable( );
         System.Data.DataTable tbl2 = dsst.DataStoreSnapShot;
         set.Tables.Add( tbl );
         set.Tables.Add( tbl2 );
         System.Data.DataColumn parentColumn = set.Tables[ "DataStore" ].Columns[ "Name" ];
         System.Data.DataColumn childColumn = set.Tables[ "DataStoreSnapshot" ].Columns[ "Name" ];
         System.Data.DataRelation relation = new System.Data.DataRelation( "parent2Child", parentColumn, childColumn );
         set.Tables[ "DataStoreSnapshot" ].ParentRelations.Add( relation );

         try
         {
            DataPhilosophiaeSection dps = System.Configuration.ConfigurationManager.GetSection( "DataPhilosophiaeSection" ) as DataPhilosophiaeSection;
            System.Configuration.ConnectionStringSettingsCollection css = System.Configuration.ConfigurationManager.ConnectionStrings;
            if( dps == null )
            {
               System.Console.WriteLine( "[DataPhilosophiaeSection] section missing in app.config!!!" );
               return set;
            }
            if( css == null )
            {
               System.Console.WriteLine( "[connectionStrings] section missing in app.config!!!" );
               return set;
            }
            {
               System.Console.WriteLine( "          Stage PathDir: " + dps.Stage.PathDir );
               int i = 0;
               foreach( ConfigurationSetting.DataStoreElement dse in dps.DataStores )
               {
                  System.Configuration.ConnectionStringSettings cs = css[ dse.ConnectionStringName ];
                  {
                     System.Data.DataRow r = tbl.NewRow( );
                     //r[ "ID" ] = i++;
                     r[ "Name" ] = dse.Name;
                     r[ "ConnectionStringName" ] = dse.ConnectionStringName;
                     r[ "LoadDefaultDatabaseOnly" ] = dse.LoadDefaultDatabaseOnly == 1 ? true : false;
                     r[ "LoadSystemObjects" ] = dse.LoadSystemObjects == 1 ? true : false;
                     r[ "WithFields" ] = dse.WithFields == 1 ? true : false;
                     r[ "StagePathDir" ] = string.IsNullOrWhiteSpace( dse.PathDir )
                     ? System.IO.Path.Combine( dps.Stage.PathDir, dse.Name )
                     : dse.PathDir;
                     r[ "ConnectionString" ] = cs != null ? cs.ConnectionString : null;
                     r[ "ProviderName" ] = cs != null ? cs.ProviderName : null;
                     //
                     System.IO.DirectoryInfo di = new System.IO.DirectoryInfo( (string) r[ "StagePathDir" ] );
                     r[ IsValidStagePathDir_ColName ] = di.Exists;
                     r[ "IsValidProviderName" ] = !string.IsNullOrWhiteSpace( cs != null ? cs.ProviderName : null );
                     //
                     tbl.Rows.Add( r );
                     //
                     if( di.Exists )
                     {
                        System.IO.FileInfo[ ] files = di.GetFiles( "*.aqb.config", System.IO.SearchOption.AllDirectories );
                        foreach( System.IO.FileInfo fi in files )
                        {
                           System.Data.DataRow rr = tbl2.NewRow( );
                           rr[ "Name" ] = dse.Name;
                           rr[ "IsActive" ] = false;
                           rr[ "SnapshotFile" ] = fi.Name;
                           tbl2.Rows.Add( rr );
                        }
                     }

                  }
               }
            }
         }
         catch( System.Configuration.ConfigurationErrorsException ex )
         {
            System.Console.WriteLine( ex.Message );
         }
         return set;
      }

      private static System.ComponentModel.BindingList<DataStore> LoadConfigurationSettings()
      {
         System.ComponentModel.BindingList<DataStore> list = new System.ComponentModel.BindingList<DataStore>( );
         try
         {
            DataPhilosophiaeSection dps = System.Configuration.ConfigurationManager.GetSection( "DataPhilosophiaeSection" ) as DataPhilosophiaeSection;
            System.Configuration.ConnectionStringSettingsCollection css = System.Configuration.ConfigurationManager.ConnectionStrings;
            if( dps == null )
            {
               System.Console.WriteLine( "[DataPhilosophiaeSection] section missing in app.config!!!" );
               return list;
            }
            if( css == null )
            {
               System.Console.WriteLine( "[connectionStrings] section missing in app.config!!!" );
               return list;
            }
            {
               System.Console.WriteLine( "          Stage PathDir: " + dps.Stage.PathDir );
               foreach( ConfigurationSetting.DataStoreElement dse in dps.DataStores )
               {
                  System.Configuration.ConnectionStringSettings cs = css[ dse.ConnectionStringName ];
                  DataStore ds = new DataStore( )
                  {
                     Name = dse.Name,
                     ConnectionStringName = dse.ConnectionStringName,
                     LoadDefaultDatabaseOnly = dse.LoadDefaultDatabaseOnly == 1 ? true : false,
                     LoadSystemObjects = dse.LoadSystemObjects == 1 ? true : false,
                     WithFields = dse.WithFields == 1 ? true : false,
                     StagePathDir = string.IsNullOrWhiteSpace( dse.PathDir )
                     ? System.IO.Path.Combine( dps.Stage.PathDir, dse.Name )
                     : dse.PathDir,
                     ConnectionString = cs != null ? cs.ConnectionString : null,
                     ProviderName = cs != null ? cs.ProviderName : null
                  };
                  list.Add( ds );
                  System.Console.WriteLine( "                DS Name: " + ds.Name );
                  System.Console.WriteLine( "                CS Name: " + ds.ConnectionStringName );
                  System.Console.WriteLine( "       CS Provider Name: " + ds.ProviderName );
                  System.Console.WriteLine( "LoadDefaultDatabaseOnly: " + ds.LoadDefaultDatabaseOnly );
                  System.Console.WriteLine( "      LoadSystemObjects: " + ds.LoadSystemObjects );
                  System.Console.WriteLine( "             WithFields: " + ds.WithFields );
                  System.Console.WriteLine( "          Stage PathDir: " + ds.StagePathDir );
               }
            }
         }
         catch( System.Configuration.ConfigurationErrorsException ex )
         {
            System.Console.WriteLine( ex.Message );
         }
         return list;
      }

      private static void f()
      {
         try
         {
            System.Configuration.ConnectionStringSettingsCollection settings = System.Configuration.ConfigurationManager.ConnectionStrings;
            if( settings != null )
            {
               foreach( System.Configuration.ConnectionStringSettings cs in settings )
               {
                  System.Console.WriteLine( "         CS Name: " + cs.Name );
                  System.Console.WriteLine( "    ProviderName: " + cs.ProviderName );
                  System.Console.WriteLine( "ConnectionString: " + cs.ConnectionString );
               }
            }
         }
         catch( System.Configuration.ConfigurationErrorsException ex )
         {
            System.Console.WriteLine( ex.Message );
         }
         System.Console.WriteLine( "estou aqui f_01" );
         {
            DataPhilosophiaeSection dps = System.Configuration.ConfigurationManager.GetSection( "DataPhilosophiaeSection" ) as DataPhilosophiaeSection;
            DataStoreElement ds = dps.DataStores[ 0 ];
            System.Configuration.ConnectionStringSettingsCollection settings = System.Configuration.ConfigurationManager.ConnectionStrings;
            System.Configuration.ConnectionStringSettings cs = settings[ ds.ConnectionStringName ];
            //

            ActiveQueryBuilder.Core.SyntaxProviderList syntaxProviderList = new ActiveQueryBuilder.Core.SyntaxProviderList( );
            ActiveQueryBuilder.Core.SQLContext sc = new ActiveQueryBuilder.Core.SQLContext( )
            {
               SyntaxProvider = new ActiveQueryBuilder.Core.AutoSyntaxProvider( ),
               MetadataProvider = new ActiveQueryBuilder.Core.OLEDBMetadataProvider
               {
                  Connection = new System.Data.OleDb.OleDbConnection( )
                  {
                     ConnectionString = cs.ConnectionString
                  }
               }
            };
         }
         {
            //DataPhilosophiaeSection dps = cm.GetSection( "DataPhilosophiaeSection" ) as DataPhilosophiaeSection;
            DataPhilosophiaeSection dps = System.Configuration.ConfigurationManager.GetSection( "DataPhilosophiaeSection" ) as DataPhilosophiaeSection;
            DataStoreElement ds = dps.DataStores[ 0 ];
            System.Configuration.ConnectionStringSettingsCollection settings = System.Configuration.ConfigurationManager.ConnectionStrings;
            System.Configuration.ConnectionStringSettings cs = settings[ ds.ConnectionStringName ];
            //
            ActiveQueryBuilder.Core.SyntaxProviderList syntaxProviderList = new ActiveQueryBuilder.Core.SyntaxProviderList( );
            ActiveQueryBuilder.Core.SQLContext sc = new ActiveQueryBuilder.Core.SQLContext( )
            {
               SyntaxProvider = new ActiveQueryBuilder.Core.SQLiteSyntaxProvider( ),
               MetadataProvider = new ActiveQueryBuilder.Core.SQLiteMetadataProvider( )
               {
                  Connection = new System.Data.SQLite.SQLiteConnection( )
                  {
                     ConnectionString = cs.ConnectionString
                  }
               }
            };
            ActiveQueryBuilder.Core.MetadataLoadingOptions loadingOptions = sc.MetadataContainer.LoadingOptions;
            loadingOptions.LoadDefaultDatabaseOnly = ds.LoadDefaultDatabaseOnly == 1 ? true : false;
            loadingOptions.LoadSystemObjects = ds.LoadSystemObjects == 1 ? true : false;
            //loadingOptions.IncludeFilter.Types = MetadataType.Field;
            //loadingOptions.ExcludeFilter.Schemas.Add(“dbo”);
            sc.MetadataContainer.LoadAll( ds.WithFields == 1 ? true : false );
         }

      }

      private static void loadDataSetDataValue( System.Data.DataSet ds )
      {
         ConfigurationSetting.DataPhilosophiaeSection dps = System.Configuration.ConfigurationManager.GetSection( "DataPhilosophiaeSection" ) as ConfigurationSetting.DataPhilosophiaeSection;
         System.Configuration.ConnectionStringSettingsCollection css = System.Configuration.ConfigurationManager.ConnectionStrings;
         if( dps == null )
         {
            throw new System.Exception( "[DataPhilosophiaeSection] section missing in app.config!!!" );
         }
         if( css == null )
         {
            throw new System.Exception( "[connectionStrings] section missing in app.config!!!" );
         }
         int iii = 0;
         foreach( ConfigurationSetting.DataStoreElement dse in dps.DataStores )
         {
            System.Configuration.ConnectionStringSettings cs = css[ dse.ConnectionStringName ];
            {
               System.Data.DataRow r = ds.Tables[ "DataStore" ].NewRow( );
               //r[ "ID" ] = i++;
               r[ "Name" ] = dse.Name;
               r[ "ConnectionStringName" ] = dse.ConnectionStringName;
               r[ "LoadDefaultDatabaseOnly" ] = dse.LoadDefaultDatabaseOnly == 1 ? true : false;
               r[ "LoadSystemObjects" ] = dse.LoadSystemObjects == 1 ? true : false;
               r[ "WithFields" ] = dse.WithFields == 1 ? true : false;
               r[ "StagePathDir" ] = string.IsNullOrWhiteSpace( dse.PathDir )
               ? System.IO.Path.Combine( dps.Stage.PathDir, dse.Name )
               : dse.PathDir;
               r[ "ConnectionString" ] = cs != null ? cs.ConnectionString : null;
               r[ "ProviderName" ] = cs != null ? cs.ProviderName : null;
               //
               System.IO.DirectoryInfo di = new System.IO.DirectoryInfo( (string) r[ "StagePathDir" ] );
               r[ IsValidStagePathDir_ColName ] = di.Exists;
               r[ "IsValidProviderName" ] = !string.IsNullOrWhiteSpace( cs != null ? cs.ProviderName : null );
               //
               ds.Tables[ "DataStore" ].Rows.Add( r );
               //
               if( di.Exists )
               {
                  //System.IO.FileInfo[ ] files = di.GetFiles( "*.aqb.config", System.IO.SearchOption.AllDirectories );
                  System.IO.FileInfo[ ] files = di.GetFiles( "*.AqbQb.xml", System.IO.SearchOption.AllDirectories );
                  int ii = 0;
                  for( int i = 0; i < files.Length; i++ )
                  {
                     System.Data.DataRow rr = ds.Tables[ "DataStoreSnapshot" ].NewRow( );
                     rr[ "Name" ] = dse.Name;
                     rr[ "IsActive" ] = false;
                     rr[ "LastWriteTimeUtc" ] = files[ i ].LastWriteTimeUtc;
                     if( files[ i ].LastWriteTimeUtc > files[ ii ].LastWriteTimeUtc )
                     {
                        ii = i;
                     }
                     rr[ "SnapshotFile" ] = files[ i ]; //fi.Name;
                     ds.Tables[ "DataStoreSnapshot" ].Rows.Add( rr );
                  }
                  if( files.Length > 0 )
                  {
                     ds.Tables[ "DataStoreSnapshot" ].Rows[ iii + ii ][ "IsActive" ] = true;
                  }
                  iii += files.Length;
               }
            }
         }
      }
      private static System.Data.DataSet createDataSetMetadata()
      {
         System.Data.DataSet ds = new System.Data.DataSet( "X" );
         ds.Tables.Add( createDataStoreMetadata( ) );
         ds.Tables.Add( createDataStoreSnapshotMetadata( ) );
         ds.Tables.Add( createMetadataItem( ) );
         createDataRelationMetadata( ds );
         return ds;
      }

      public static string IsValidStagePathDir_ColName = "IsValidStagePathDir";
      public static string IsValidProviderName_ColName = "IsValidProviderName";
      public static string ConnectionStringName_ColName = "ConnectionStringName";
      public static string ConnectionString_ColName = "ConnectionString";
      public static string ProviderName_ColName = "ProviderName";
      public static string StagePathDir_ColName = "StagePathDir";

      private static System.Data.DataTable createDataStoreMetadata()
      {
         System.Data.DataTable t = new System.Data.DataTable( "DataStore" );
         {
            //System.Data.DataColumn c = new System.Data.DataColumn( );
            //c.DataType = System.Type.GetType( "System.Int32" );
            //c.ColumnName = "ID";
            //c.Caption = "Id";
            //c.ReadOnly = true;
            //c.Unique = false;
            //t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.String" );
            c.ColumnName = "Name";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.Boolean" );
            c.ColumnName = "IsActive";
            c.ReadOnly = false;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.String" );
            c.ColumnName = ConnectionStringName_ColName;
            c.ReadOnly = false;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.Boolean" );
            c.ColumnName = "LoadDefaultDatabaseOnly";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.Boolean" );
            c.ColumnName = "LoadSystemObjects";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.Boolean" );
            c.ColumnName = "WithFields";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.String" );
            c.ColumnName = StagePathDir_ColName;
            c.Caption = "StagePathDir";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.String" );
            c.ColumnName = ConnectionString_ColName;
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.String" );
            c.ColumnName = ProviderName_ColName;
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.Boolean" );
            c.ColumnName = IsValidStagePathDir_ColName;
            c.Caption = IsValidStagePathDir_ColName;
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.Boolean" );
            c.ColumnName = IsValidProviderName_ColName;
            c.Caption = "IsValidProviderName";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         return t;
      }
      private static System.Data.DataTable createDataStoreSnapshotMetadata()
      {
         System.Data.DataTable t = new System.Data.DataTable( "DataStoreSnapshot" );
         {
            //System.Data.DataColumn c = new System.Data.DataColumn( );
            //c.DataType = System.Type.GetType( "System.Int32" );
            //c.ColumnName = "ID";
            //c.Caption = "Id";
            //c.ReadOnly = true;
            //c.Unique = false;
            //t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.String" );
            c.ColumnName = "Name";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.Boolean" );
            c.ColumnName = "IsActive";
            c.ReadOnly = false;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.IO.FileInfo" ); // "System.String" );
            c.ColumnName = "SnapshotFile";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = System.Type.GetType( "System.DateTime" );
            c.ColumnName = "LastWriteTimeUtc";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         return t;
      }
      private static System.Data.DataTable createMetadataItem()
      {
         System.Data.DataTable t = new System.Data.DataTable( "MetadataItem" );
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Int32 );
            c.ColumnName = "ID";
            c.Caption = "Id";
            c.ReadOnly = true;
            c.Unique = false;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "MetadataProvider";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "SyntaxProvider";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            //System.Data.DataColumn c = new System.Data.DataColumn( );
            //c.DataType = typeof( System.Int32 );
            //c.ColumnName = "ID";
            //c.ReadOnly = true;
            //t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Int32 );
            c.ColumnName = "ParentID";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Boolean );
            c.ColumnName = "IsSystem";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "Type";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "ParentType";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "Cardinality";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Int32 );
            c.ColumnName = "FieldsCount";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "Fields";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "ReferencedCardinality";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "ReferencedObject";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "ReferencedObjectName";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Int32 );
            c.ColumnName = "ReferencedFieldsCount";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "ReferencedFields";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "Server";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "Database";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "Schema";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "ObjectName";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "NameFullQualified";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "NameQuoted";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "AltName";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "Field";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Boolean );
            c.ColumnName = "HasDefault";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "Expression";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "FieldType";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "FieldTypeName";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Boolean );
            c.ColumnName = "IsNullable";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Int32 );
            c.ColumnName = "Precision";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Int32 );
            c.ColumnName = "Scale";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Int32 );
            c.ColumnName = "Size";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Boolean );
            c.ColumnName = "IsPK";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Boolean );
            c.ColumnName = "IsRO";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "Description";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Object );
            c.ColumnName = "Tag";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "UserData";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         return t;
      }
      private static void createDataRelationMetadata( System.Data.DataSet ds )
      {
         // DataRelation requires: two DataColumns (parent and child) and a name.
         {
            System.Data.DataColumn parent = ds.Tables[ "DataStore" ].Columns[ "Name" ];
            System.Data.DataColumn child = ds.Tables[ "DataStoreSnapshot" ].Columns[ "Name" ];
            System.Data.DataRelation relation = new System.Data.DataRelation( "parent2Child", parent, child );
            // ds.Tables[ "DataStoreSnapshot" ].ParentRelations.Add( relation );
         }
      }
   }
}
