namespace DataPhilosophiae.DataModel
{
   public class DataCatalog
   {
      public DataCatalog()
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
         int i = 0;
         foreach( ConfigurationSetting.DataStoreElement dse in dps.DataStores )
         {
            System.Configuration.ConnectionStringSettings cs = css[ dse.ConnectionStringName ];
            {
               System.Data.DataRow r = this.ds.NewRow( );
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
               r[ "IsValidStagePathDir" ] = di.Exists;
               r[ "IsValidProviderName" ] = !string.IsNullOrWhiteSpace( cs != null ? cs.ProviderName : null );
               //
               this.ds.Rows.Add( r );
               //
               if( di.Exists )
               {
                  System.IO.FileInfo[ ] files = di.GetFiles( "*.aqb.config", System.IO.SearchOption.AllDirectories );
                  foreach( System.IO.FileInfo fi in files )
                  {
                     System.Data.DataRow rr = this.dss.NewRow( );
                     rr[ "Name" ] = dse.Name;
                     rr[ "IsActive" ] = false;
                     rr[ "SnapshotFile" ] = fi.Name;
                     this.dss.Rows.Add( rr );
                  }
               }

            }
         }
      }
      //
      public System.Data.DataSet dataSet = new System.Data.DataSet( "X" );
      public System.Data.DataTable ds = new System.Data.DataTable( "DataStore" );
      public System.Data.DataTable dss = new System.Data.DataTable( "DataStoreSnapshot" );
      //
      public class DataStore
      {
         //private static System.Data.DataColumn id;
         //public static System.Data.DataColumn ID
         //{
         //   get
         //   {
         //      if( id == null )
         //      {
         //         System.Data.DataColumn col = new System.Data.DataColumn( );
         //         col.DataType = System.Type.GetType( "System.Int32" );
         //         col.ColumnName = "ID";
         //         col.Caption = "Id";
         //         col.ReadOnly = true;
         //         col.Unique = false;
         //         id = col;
         //      }
         //      return id;
         //   }
         //}

         private static System.Data.DataColumn name;
         public static System.Data.DataColumn Name
         {
            get
            {
               if( name == null )
               {
                  System.Data.DataColumn col = new System.Data.DataColumn( );
                  col.DataType = System.Type.GetType( "System.String" );
                  col.ColumnName = "Name";
                  col.ReadOnly = true;
                  name = col;
               }
               return name;
            }
         }

         private static System.Data.DataColumn isActive;
         public static System.Data.DataColumn IsActive
         {
            get
            {
               if( isActive == null )
               {
                  System.Data.DataColumn col = new System.Data.DataColumn( );
                  col.DataType = System.Type.GetType( "System.Boolean" );
                  col.ColumnName = "IsActive";
                  col.ReadOnly = false;
                  isActive = col;
               }
               return isActive;
            }
         }

         private static System.Data.DataColumn connectionStringName;
         public static System.Data.DataColumn ConnectionStringName
         {
            get
            {
               if( connectionStringName == null )
               {
                  System.Data.DataColumn col = new System.Data.DataColumn( );
                  col.DataType = System.Type.GetType( "System.String" );
                  col.ColumnName = "ConnectionStringName";
                  col.ReadOnly = false;
                  connectionStringName = col;
               }
               return connectionStringName;
            }
         }

         private static System.Data.DataColumn loadDefaultDatabaseOnly;
         public static System.Data.DataColumn LoadDefaultDatabaseOnly
         {
            get
            {
               if( loadDefaultDatabaseOnly == null )
               {
                  System.Data.DataColumn col = new System.Data.DataColumn( );
                  col.DataType = System.Type.GetType( "System.Boolean" );
                  col.ColumnName = "LoadDefaultDatabaseOnly";
                  col.ReadOnly = true;
                  loadDefaultDatabaseOnly = col;
               }
               return loadDefaultDatabaseOnly;
            }
         }

         private static System.Data.DataColumn loadSystemObjects;
         public static System.Data.DataColumn LoadSystemObjects
         {
            get
            {
               if( loadSystemObjects == null )
               {
                  System.Data.DataColumn col = new System.Data.DataColumn( );
                  col.DataType = System.Type.GetType( "System.Boolean" );
                  col.ColumnName = "LoadSystemObjects";
                  col.ReadOnly = true;
                  loadSystemObjects = col;
               }
               return loadSystemObjects;
            }
         }

         private static System.Data.DataColumn withFields;
         public static System.Data.DataColumn WithFields
         {
            get
            {
               if( withFields == null )
               {
                  System.Data.DataColumn col = new System.Data.DataColumn( );
                  col.DataType = System.Type.GetType( "System.Boolean" );
                  col.ColumnName = "WithFields";
                  col.ReadOnly = true;
                  withFields = col;
               }
               return withFields;
            }
         }

         private static System.Data.DataColumn stagePathDir;
         public static System.Data.DataColumn StagePathDir
         {
            get
            {
               if( stagePathDir == null )
               {
                  System.Data.DataColumn col = new System.Data.DataColumn( );
                  col.DataType = System.Type.GetType( "System.String" );
                  col.ColumnName = "StagePathDir";
                  col.Caption = "StagePathDir";
                  col.ReadOnly = true;
                  stagePathDir = col;
               }
               return stagePathDir;
            }
         }

         private static System.Data.DataColumn connectionString;
         public static System.Data.DataColumn ConnectionString
         {
            get
            {
               if( connectionString == null )
               {
                  System.Data.DataColumn col = new System.Data.DataColumn( );
                  col.DataType = System.Type.GetType( "System.String" );
                  col.ColumnName = "ConnectionString";
                  col.ReadOnly = true;
                  connectionString = col;
               }
               return connectionString;
            }
         }

         private static System.Data.DataColumn providerName;
         public static System.Data.DataColumn ProviderName
         {
            get
            {
               if( providerName == null )
               {
                  System.Data.DataColumn col = new System.Data.DataColumn( );
                  col.DataType = System.Type.GetType( "System.String" );
                  col.ColumnName = "ProviderName";
                  col.ReadOnly = true;
                  providerName = col;
               }
               return providerName;
            }
         }

         // ----------------------------------------------------------------------

         private static System.Data.DataColumn isValidStagePathDir;
         public static System.Data.DataColumn IsValidStagePathDir
         {
            get
            {
               if( isValidStagePathDir == null )
               {
                  System.Data.DataColumn col = new System.Data.DataColumn( );
                  col.DataType = System.Type.GetType( "System.Boolean" );
                  col.ColumnName = "IsValidStagePathDir";
                  col.Caption = "IsValidStagePathDir";
                  col.ReadOnly = true;
                  isValidStagePathDir = col;
               }
               return isValidStagePathDir;
            }
         }

         private static System.Data.DataColumn isValidProviderName;
         public static System.Data.DataColumn IsValidProviderName
         {
            get
            {
               if( isValidProviderName == null )
               {
                  System.Data.DataColumn col = new System.Data.DataColumn( );
                  col.DataType = System.Type.GetType( "System.Boolean" );
                  col.ColumnName = "IsValidProviderName";
                  col.Caption = "IsValidProviderName";
                  col.ReadOnly = true;
                  isValidProviderName = col;
               }
               return isValidProviderName;
            }
         }

         // ----------------------------------------------------------------------

         private static System.Data.DataTable dataStore;
         public static System.Data.DataTable DataStoreX
         {
            get
            {
               if( dataStore == null )
               {
                  System.Data.DataTable tbl = new System.Data.DataTable( "DataStore" );
                  //tbl.Columns.Add( this.ID );
                  tbl.Columns.Add( Name );
                  tbl.Columns.Add( IsActive );
                  tbl.Columns.Add( ConnectionStringName );
                  tbl.Columns.Add( LoadDefaultDatabaseOnly );
                  tbl.Columns.Add( LoadSystemObjects );
                  tbl.Columns.Add( WithFields );
                  tbl.Columns.Add( StagePathDir );
                  tbl.Columns.Add( ConnectionString );
                  tbl.Columns.Add( ProviderName );
                  tbl.Columns.Add( IsValidStagePathDir );
                  tbl.Columns.Add( IsValidProviderName );
                  dataStore = tbl;
               }
               return dataStore;
            }
         }
      }
   }
}
