using DataPhilosophiae.ConfigurationSetting;
using System.Data;

namespace ExportImportAqbMetadata
{
   public class Class1
   {
      [System.Runtime.InteropServices.DllImport( "kernel32.dll", SetLastError = true )]
      [return: System.Runtime.InteropServices.MarshalAs( System.Runtime.InteropServices.UnmanagedType.Bool )]
      static extern bool AllocConsole();

      public static void LoadDataStoreSnapshotFilesTable( System.Data.DataSet ds )
      {
         DataPhilosophiaeSection dps = System.Configuration.ConfigurationManager.GetSection( "DataPhilosophiaeSection" ) as DataPhilosophiaeSection;
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
         DataTable dscTbl = ds.Tables[ DataStoreConfig_TblName ];
         DataTable dsssfTbl = ds.Tables[ DataStoreSnapshotFile_TblName ];
         foreach( DataStoreElement dse in dps.DataStores )
         {
            System.Configuration.ConnectionStringSettings cs = css[ dse.ConnectionStringName ];
            {
               System.Data.DataRow r = dscTbl.NewRow( );
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
               dscTbl.Rows.Add( r );
               //
               if( di.Exists )
               {
                  System.IO.FileInfo[ ] files = GetFiles( di );
                  int ii = 0;
                  for( int i = 0; i < files.Length; i++ )
                  {
                     System.Data.DataRow rr = dsssfTbl.NewRow( );
                     rr[ "Name" ] = dse.Name;
                     rr[ "IsActive" ] = false;
                     rr[ "LastWriteTimeUtc" ] = files[ i ].LastWriteTimeUtc;
                     if( files[ i ].LastWriteTimeUtc > files[ ii ].LastWriteTimeUtc )
                     {
                        ii = i;
                     }
                     rr[ "SnapshotFile" ] = files[ i ];
                     dsssfTbl.Rows.Add( rr );
                  }
                  if( files.Length > 0 )
                  {
                     dsssfTbl.Rows[ iii + ii ][ "IsActive" ] = true;
                  }
                  iii += files.Length;
               }
            }
         }
      }

      private static System.IO.FileInfo[ ] GetFiles( System.IO.DirectoryInfo di )
      {
         System.IO.FileInfo[ ] files = di.GetFiles( "*.AqbQb.xml", System.IO.SearchOption.AllDirectories );
         System.IO.FileInfo[ ] files2 = di.GetFiles( "*.DsSs.xml", System.IO.SearchOption.AllDirectories );
         files2.CopyTo( files, 0 );
         return files;
      }

      public const string DataStoreConfig_TblName = "DataStoreConfig";
      public const string DataStoreSnapshotFile_TblName = "DataStoreSnapshotFiles";
      public const string MetadataItem_TblName = "MetadataItem";
      //
      public static string IsValidStagePathDir_ColName = "IsValidStagePathDir";
      public static string IsValidProviderName_ColName = "IsValidProviderName";
      public static string ConnectionStringName_ColName = "ConnectionStringName";
      public static string ConnectionString_ColName = "ConnectionString";
      public static string ProviderName_ColName = "ProviderName";
      public static string StagePathDir_ColName = "StagePathDir";

      public static System.Data.DataTable CreateDataStoreConfigTable( string name = DataStoreConfig_TblName )
      {
         System.Data.DataTable t = new System.Data.DataTable( name );
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
      public static System.Data.DataTable CreateDataStoreSnapshotFileTable( string name = DataStoreSnapshotFile_TblName )
      {
         System.Data.DataTable t = new System.Data.DataTable( name );
         {
            //System.Data.DataColumn c = new System.Data.DataColumn( );
            //c.DataType = typeof( System.Int32 );
            //c.ColumnName = "ID";
            //c.Caption = "Id";
            //c.ReadOnly = true;
            //c.Unique = false;
            //t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "Name";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Boolean );
            c.ColumnName = "IsActive";
            c.ReadOnly = false;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String ); // typeof( System.IO.FileInfo );
            c.ColumnName = "SnapshotFile";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.DateTime );
            c.ColumnName = "LastWriteTimeUtc";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         return t;
      }
      public static System.Data.DataTable CreateMetadataItemTable( string name = MetadataItem_TblName )
      {
         System.Data.DataTable t = new System.Data.DataTable( name );
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
            c.ColumnName = "DataStoreName";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String ); // typeof( System.IO.FileInfo );
            c.ColumnName = "SnapshotFile";
            c.ReadOnly = true;
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.DateTime );
            c.ColumnName = "LastWriteTimeUtc";
            c.ReadOnly = true;
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
      //
      //
      //
      //
      //

      public static void ZZZZZZZZ( System.Data.DataSet ds )
      {
         var resultSet = from p in ds.Tables[ "DataSetSnapshot" ].AsEnumerable( )
                            //join c in ds.Tables[ "DataStoreSnapshot" ].AsEnumerable( )
                            //on p[ "Name" ] equals c[ "Name" ]
                            //@#$% where p.Field<bool?>( "IsActive" ) == true
                            //@#$% && c.Field<bool?>( "IsActive" ) == true
                         orderby p.Field<string>( "DataStore" ) ascending
                               , p.Field<System.Boolean>( "IsActive" ) descending
                               , p.Field<System.Int16>( "Type" ) descending
                               , p.Field<string>( "TS" ) descending
                         select p // new
                         //{
                         //   StagePathDir = (string) p[ "StagePathDir" ],
                         //   SnapshotFile = (System.IO.FileInfo) c[ "SnapshotFile" ]
                         //}
                 ;
         foreach( var item in resultSet )
         {
            System.Console.WriteLine( item[ "DataStore" ] + " " + item[ "IsActive" ] + " " + item[ "Type" ] + " " + item[ "TS" ] );
         }
      }

      public static System.Data.DataTable CreateDataSetSnapshotTable2( string name = "DataSetSnapshot" )
      {
         System.Data.DataTable t = new System.Data.DataTable( name );
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String );
            c.ColumnName = "DataStore";
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Boolean );
            c.ColumnName = "IsActive";
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.Int16 );
            c.ColumnName = "Type";
            t.Columns.Add( c );
         }
         {
            System.Data.DataColumn c = new System.Data.DataColumn( );
            c.DataType = typeof( System.String ); //  typeof( System.DateTime );
            c.ColumnName = "TS";
            t.Columns.Add( c );
         }
         {
            {
               System.Data.DataRow r = t.NewRow( );
               r[ "DataStore" ] = "a";
               r[ "IsActive" ] = false;
               r[ "Type" ] = 0;
               r[ "TS" ] = System.DateTime.Now.ToString( "yyyyMMdd-HHmmss,fffffff" );
               t.Rows.Add( r );
            }
            {
               System.Data.DataRow r = t.NewRow( );
               r[ "DataStore" ] = "a";
               r[ "IsActive" ] = true;
               r[ "Type" ] = 0;
               r[ "TS" ] = System.DateTime.Now.ToString( "yyyyMMdd-HHmmss,fffffff" );
               t.Rows.Add( r );
            }
            {
               System.Data.DataRow r = t.NewRow( );
               r[ "DataStore" ] = "a";
               r[ "IsActive" ] = true;
               r[ "Type" ] = 0;
               r[ "TS" ] = System.DateTime.Now.ToString( "yyyyMMdd-HHmmss,fffffff" );
               t.Rows.Add( r );
            }
            {
               System.Data.DataRow r = t.NewRow( );
               r[ "DataStore" ] = "b";
               r[ "IsActive" ] = false;
               r[ "Type" ] = 0;
               r[ "TS" ] = System.DateTime.Now.ToString( "yyyyMMdd-HHmmss,fffffff" );
               t.Rows.Add( r );
            }
            {
               System.Data.DataRow r = t.NewRow( );
               r[ "DataStore" ] = "b";
               r[ "IsActive" ] = false;
               r[ "Type" ] = 0;
               r[ "TS" ] = System.DateTime.Now.ToString( "yyyyMMdd-HHmmss,fffffff" );
               t.Rows.Add( r );
            }
            {
               System.Data.DataRow r = t.NewRow( );
               r[ "DataStore" ] = "b";
               r[ "IsActive" ] = false;
               r[ "Type" ] = 0;
               r[ "TS" ] = System.DateTime.Now.ToString( "yyyyMMdd-HHmmss,fffffff" );
               t.Rows.Add( r );
            }
            {
               System.Data.DataRow r = t.NewRow( );
               r[ "DataStore" ] = "b";
               r[ "IsActive" ] = true;
               r[ "Type" ] = 0;
               r[ "TS" ] = System.DateTime.Now.ToString( "yyyyMMdd-HHmmss,fffffff" );
               t.Rows.Add( r );
            }
         }
         return t;
      }
      public static void createDataRelationMetadata( System.Data.DataSet ds )
      {
         // DataRelation requires: two DataColumns (parent and child) and a name.
         {
            System.Data.DataColumn parent = ds.Tables[ "DataStore" ].Columns[ "Name" ];
            System.Data.DataColumn child = ds.Tables[ "DataStoreSnapshot" ].Columns[ "Name" ];
            System.Data.DataRelation relation = new System.Data.DataRelation( "parent2Child", parent, child );
            // ds.Tables[ "DataStoreSnapshot" ].ParentRelations.Add( relation );
         }
      }

      #region --- Active Query Builder ---
      public static ActiveQueryBuilder.Core.SQLContext CreateAqbSqlContext4SQLiteOffline( string filepath )
      {
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
         {
            sc.MetadataContainer.LoadingOptions.OfflineMode = true;
            sc.MetadataContainer.ImportFromXML( filepath );
         }
         return sc;
      }

      private class StackItem
      {
         public ActiveQueryBuilder.Core.MetadataList list;
         public int index;
         public int parentID;
         public int grandParentID;
      }

      public static void DrillDownAqbSqlContext(
         ActiveQueryBuilder.Core.SQLContext sc
         , System.Data.DataTable tbl
         , string dataStoreName
         )
      {
         ActiveQueryBuilder.Core.MetadataList items = sc.MetadataContainer.Items;
         //
         System.Collections.Generic.Stack<StackItem> stack = new System.Collections.Generic.Stack<StackItem>( );
         stack.Push( new StackItem { list = items, index = 0, parentID = -1, grandParentID = -1 } );
         do
         {
            StackItem si = stack.Pop( );
            ActiveQueryBuilder.Core.MetadataList actualMIList = si.list;
            int actualIndex = si.index;
            int actualParentID = si.grandParentID; // IMPORTANT!!!
            for( ; actualIndex < actualMIList.Count; actualIndex++ )
            {
               System.Data.DataRow row = tbl.NewRow( );
               row[ "DataStoreName" ] = dataStoreName;
               ExtractMetadataItem( row, actualMIList[ actualIndex ], actualParentID, tbl );
               tbl.Rows.Add( row );
               if( actualMIList[ actualIndex ].Items.Count > 0 ) // branch...
               {
                  int count = tbl.Rows.Count;
                  System.Data.DataRowCollection rows = tbl.Rows;
                  int parentId = (int) rows[ count - 1 ][ "ID" ];
                  // Push the "next" Item...
                  stack.Push( new StackItem
                  {
                     list = actualMIList,
                     index = actualIndex + 1,
                     parentID = parentId,
                     grandParentID = actualParentID
                  } );
                  // Reset the loop to process the "actual" Item...
                  actualParentID = parentId;
                  actualMIList = actualMIList[ actualIndex ].Items;
                  actualIndex = -1;
               }
            } // for(;;)...

         } while( stack.Count > 0 );
      }

      private static void ExtractMetadataItem(
         System.Data.DataRow row
         , ActiveQueryBuilder.Core.MetadataItem mi
         , int parentID
         , System.Data.DataTable tbl
         )
      {
         switch( mi.Type )
         {
            case ActiveQueryBuilder.Core.MetadataType.Database:
            case ActiveQueryBuilder.Core.MetadataType.Schema:
               ExtractNamespace( row, mi, parentID, tbl );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Table:
            case ActiveQueryBuilder.Core.MetadataType.View:
               ExtractTable( row, mi, parentID, tbl );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Procedure:
               ExtractProcedure( row, mi, parentID, tbl );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Synonym:
               ExtractSynonym( row, mi, parentID, tbl );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Field:
               ExtractField( row, mi, parentID, tbl );
               break;
            case ActiveQueryBuilder.Core.MetadataType.ForeignKey:
               ExtractForeignKey( row, mi, parentID, tbl );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Root:
            case ActiveQueryBuilder.Core.MetadataType.Server:
            case ActiveQueryBuilder.Core.MetadataType.Package:
            case ActiveQueryBuilder.Core.MetadataType.Namespaces:
            case ActiveQueryBuilder.Core.MetadataType.ObjectMetadata:
            case ActiveQueryBuilder.Core.MetadataType.Objects:
            case ActiveQueryBuilder.Core.MetadataType.Aggregate:
            case ActiveQueryBuilder.Core.MetadataType.Parameter:
            case ActiveQueryBuilder.Core.MetadataType.UserQuery:
            case ActiveQueryBuilder.Core.MetadataType.UserField:
            case ActiveQueryBuilder.Core.MetadataType.All:
            default:
               ExtractItem( row, mi, parentID, tbl );
               break;
         }
      }

      private static void ExtractNamespace(
         System.Data.DataRow row
         , ActiveQueryBuilder.Core.MetadataItem mi
         , int parentID
         , System.Data.DataTable tbl
         )
      {
         if( mi == null ) return;
         ExtractItem( row, mi, parentID, tbl );
         {
            //ActiveQueryBuilder.Core.MetadataNamespace m = mi as ActiveQueryBuilder.Core.MetadataNamespace;
         }
      }

      private static void ExtractProcedure(
         System.Data.DataRow row
         , ActiveQueryBuilder.Core.MetadataItem mi
         , int parentID
         , System.Data.DataTable tbl
         )
      {
         if( mi == null ) return;
         ExtractItem( row, mi, parentID, tbl );
         {
            ActiveQueryBuilder.Core.MetadataObject m = mi as ActiveQueryBuilder.Core.MetadataObject;
         }
      }

      private static void ExtractSynonym(
         System.Data.DataRow row
         , ActiveQueryBuilder.Core.MetadataItem mi
         , int parentID
         , System.Data.DataTable tbl
         )
      {
         if( mi == null ) return;
         ExtractItem( row, mi, parentID, tbl );
         {
            ActiveQueryBuilder.Core.MetadataObject m = mi as ActiveQueryBuilder.Core.MetadataObject;
            row[ "ReferencedObject" ] = m.ReferencedObject?.NameFull;
            //
            for( int i = 0; i < m.ReferencedObjectName.Count; i++ )
            {
               ActiveQueryBuilder.Core.MetadataQualifiedNamePart x = m.ReferencedObjectName[ i ];
               row[ "ReferencedObjectName" ] += "["
               + System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), x.Type )
               + ":"
               + x.Name
               + "]"
            ;
            }
         }
      }

      private static void ExtractTable(
         System.Data.DataRow row
         , ActiveQueryBuilder.Core.MetadataItem mi
         , int parentID
         , System.Data.DataTable tbl
         )
      {
         if( mi == null ) return;
         ExtractItem( row, mi, parentID, tbl );
         {
            //ActiveQueryBuilder.Core.MetadataObject m = mi as ActiveQueryBuilder.Core.MetadataObject;
         }
      }

      private static void ExtractField(
         System.Data.DataRow row
         , ActiveQueryBuilder.Core.MetadataItem mi
         , int parentID
         , System.Data.DataTable tbl
         )
      {
         if( mi == null ) return;
         ExtractItem( row, mi, parentID, tbl );
         {
            ActiveQueryBuilder.Core.MetadataField m = mi as ActiveQueryBuilder.Core.MetadataField;
            row[ "Expression" ] = m.Expression;
            row[ "FieldType" ] = System.Enum.GetName( typeof( System.Data.DbType ), m.FieldType );
            row[ "FieldTypeName" ] = m.FieldTypeName;
            row[ "IsNullable" ] = m.Nullable;
            row[ "Precision" ] = m.Precision;
            row[ "Scale" ] = m.Scale;
            row[ "Size" ] = m.Size;
            row[ "IsPK" ] = m.PrimaryKey;
            row[ "IsRO" ] = m.ReadOnly;
         }
      }

      private static void ExtractForeignKey(
         System.Data.DataRow row
         , ActiveQueryBuilder.Core.MetadataItem mi
         , int parentID
         , System.Data.DataTable tbl
         )
      {
         if( mi == null ) return;
         ExtractItem( row, mi, parentID, tbl );
         row[ "FieldType" ] = null;
         {
            ActiveQueryBuilder.Core.MetadataForeignKey m = mi as ActiveQueryBuilder.Core.MetadataForeignKey;
            row[ "ReferencedObject" ] = m.ReferencedObject.NameFull;
            //
            for( int i = 0; i < m.ReferencedObjectName.Count; i++ )
            {
               ActiveQueryBuilder.Core.MetadataQualifiedNamePart x = m.ReferencedObjectName[ i ];
               row[ "ReferencedObjectName" ] += "["
               + System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), x.Type )
               + ":"
               + x.Name
               + "]"
            ;
            }
            //
            row[ "ReferencedFieldsCount" ] = m.ReferencedFields.Count;
            for( int i = 0; i < m.ReferencedFields.Count; i++ )
            {
               row[ "ReferencedFields" ] += "[" + m.ReferencedFields[ i ] + "]";
            }
            //
            row[ "ReferencedCardinality" ] = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataForeignKeyCardinality ), m.ReferencedCardinality );
            //
            row[ "FieldsCount" ] = m.Fields.Count;
            for( int i = 0; i < m.Fields.Count; i++ )
            {
               row[ "Fields" ] += "[" + m.Fields[ i ] + "]"
            ;
            }
            //
            row[ "Cardinality" ] = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataForeignKeyCardinality ), m.Cardinality );
         }
      }

      private static void ExtractItem(
         System.Data.DataRow row
         , ActiveQueryBuilder.Core.MetadataItem mi
         , int parentID
         , System.Data.DataTable tbl
         )

      {
         row[ "ID" ] = tbl.Rows.Count;
         row[ "ParentID" ] = parentID;
         row[ "MetadataProvider" ] = mi.SQLContext?.MetadataProvider?.Description;
         row[ "SyntaxProvider" ] = mi.SQLContext?.SyntaxProvider?.Description;
         if( mi.Parent != null )
         {
            row[ "ParentType" ] = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), mi.Parent.Type );
         }
         row[ "Type" ] = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), mi.Type );
         row[ "IsSystem" ] = mi.System;
         ////
         //string rootName = mi.Root?.Name;
         row[ "Server" ] = mi.Server?.Name;
         row[ "Database" ] = mi.Database?.Name;
         row[ "Schema" ] = mi.Schema?.Name;
         row[ "ObjectName" ] = mi.Object?.Name;
         ////
         row[ "NameFullQualified" ] = mi.NameFull + (mi.NameFull.EndsWith( "." ) ? "<?>" : "");
         row[ "NameQuoted" ] = mi.NameQuoted;
         row[ "AltName" ] = mi.AltName;
         row[ "Field" ] = mi.Name != null ? mi.Name : "<?>";
         ////
         row[ "HasDefault" ] = mi.Default;
         row[ "Description" ] = mi.Description;
         row[ "Tag" ] = mi.Tag;
         row[ "UserData" ] = mi.UserData;
      }
      #endregion
   }
}
