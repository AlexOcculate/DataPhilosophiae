namespace DataPhilosophiae.DataModel
{
   public class DataStoreTable
   {
      //private System.Data.DataColumn id;
      //public System.Data.DataColumn ID
      //{
      //   get
      //   {
      //      if( this.id == null )
      //      {
      //         System.Data.DataColumn col = new System.Data.DataColumn( );
      //         col.DataType = System.Type.GetType( "System.Int32" );
      //         col.ColumnName = "ID";
      //         col.Caption = "Id";
      //         col.ReadOnly = true;
      //         col.Unique = false;
      //         this.id = col;
      //      }
      //      return this.id;
      //   }
      //}

      private System.Data.DataColumn name;
      public System.Data.DataColumn Name
      {
         get
         {
            if( this.name == null )
            {
               System.Data.DataColumn col = new System.Data.DataColumn( );
               col.DataType = System.Type.GetType( "System.String" );
               col.ColumnName = "Name";
               col.ReadOnly = true;
               this.name = col;
            }
            return this.name;
         }
      }

      private System.Data.DataColumn isActive;
      public System.Data.DataColumn IsActive
      {
         get
         {
            if( this.isActive == null )
            {
               System.Data.DataColumn col = new System.Data.DataColumn( );
               col.DataType = System.Type.GetType( "System.Boolean" );
               col.ColumnName = "IsActive";
               col.ReadOnly = false;
               this.isActive = col;
            }
            return this.isActive;
         }
      }

      private System.Data.DataColumn connectionStringName;
      public System.Data.DataColumn ConnectionStringName
      {
         get
         {
            if( this.connectionStringName == null )
            {
               System.Data.DataColumn col = new System.Data.DataColumn( );
               col.DataType = System.Type.GetType( "System.String" );
               col.ColumnName = "ConnectionStringName";
               col.ReadOnly = false;
               this.connectionStringName = col;
            }
            return this.connectionStringName;
         }
      }

      private System.Data.DataColumn loadDefaultDatabaseOnly;
      public System.Data.DataColumn LoadDefaultDatabaseOnly
      {
         get
         {
            if( this.loadDefaultDatabaseOnly == null )
            {
               System.Data.DataColumn col = new System.Data.DataColumn( );
               col.DataType = System.Type.GetType( "System.Boolean" );
               col.ColumnName = "LoadDefaultDatabaseOnly";
               col.ReadOnly = true;
               this.loadDefaultDatabaseOnly = col;
            }
            return this.loadDefaultDatabaseOnly;
         }
      }

      private System.Data.DataColumn loadSystemObjects;
      public System.Data.DataColumn LoadSystemObjects
      {
         get
         {
            if( this.loadSystemObjects == null )
            {
               System.Data.DataColumn col = new System.Data.DataColumn( );
               col.DataType = System.Type.GetType( "System.Boolean" );
               col.ColumnName = "LoadSystemObjects";
               col.ReadOnly = true;
               this.loadSystemObjects = col;
            }
            return this.loadSystemObjects;
         }
      }

      private System.Data.DataColumn withFields;
      public System.Data.DataColumn WithFields
      {
         get
         {
            if( this.withFields == null )
            {
               System.Data.DataColumn col = new System.Data.DataColumn( );
               col.DataType = System.Type.GetType( "System.Boolean" );
               col.ColumnName = "WithFields";
               col.ReadOnly = true;
               this.withFields = col;
            }
            return this.withFields;
         }
      }

      private System.Data.DataColumn stagePathDir;
      public System.Data.DataColumn StagePathDir
      {
         get
         {
            if( this.stagePathDir == null )
            {
               System.Data.DataColumn col = new System.Data.DataColumn( );
               col.DataType = System.Type.GetType( "System.String" );
               col.ColumnName = "StagePathDir";
               col.Caption = "StagePathDir";
               col.ReadOnly = true;
               this.stagePathDir = col;
            }
            return this.stagePathDir;
         }
      }

      private System.Data.DataColumn connectionString;
      public System.Data.DataColumn ConnectionString
      {
         get
         {
            if( this.connectionString == null )
            {
               System.Data.DataColumn col = new System.Data.DataColumn( );
               col.DataType = System.Type.GetType( "System.String" );
               col.ColumnName = "ConnectionString";
               col.ReadOnly = true;
               this.connectionString = col;
            }
            return this.connectionString;
         }
      }

      private System.Data.DataColumn providerName;
      public System.Data.DataColumn ProviderName
      {
         get
         {
            if( this.providerName == null )
            {
               System.Data.DataColumn col = new System.Data.DataColumn( );
               col.DataType = System.Type.GetType( "System.String" );
               col.ColumnName = "ProviderName";
               col.ReadOnly = true;
               this.providerName = col;
            }
            return this.providerName;
         }
      }

      // ----------------------------------------------------------------------

      private System.Data.DataColumn isValidStagePathDir;
      public System.Data.DataColumn IsValidStagePathDir
      {
         get
         {
            if( this.isValidStagePathDir == null )
            {
               System.Data.DataColumn col = new System.Data.DataColumn( );
               col.DataType = System.Type.GetType( "System.Boolean" );
               col.ColumnName = "IsValidStagePathDir";
               col.Caption = "IsValidStagePathDir";
               col.ReadOnly = true;
               this.isValidStagePathDir = col;
            }
            return this.isValidStagePathDir;
         }
      }

      private System.Data.DataColumn isValidProviderName;
      public System.Data.DataColumn IsValidProviderName
      {
         get
         {
            if( this.isValidProviderName == null )
            {
               System.Data.DataColumn col = new System.Data.DataColumn( );
               col.DataType = System.Type.GetType( "System.Boolean" );
               col.ColumnName = "IsValidProviderName";
               col.Caption = "IsValidProviderName";
               col.ReadOnly = true;
               this.isValidProviderName = col;
            }
            return this.isValidProviderName;
         }
      }

      // ----------------------------------------------------------------------

      private System.Data.DataTable dataStore;
      public System.Data.DataTable DataStore
      {
         get
         {
            if( this.dataStore == null )
            {
               System.Data.DataTable tbl = new System.Data.DataTable( "DataStore" );
               //tbl.Columns.Add( this.ID );
               tbl.Columns.Add( this.Name );
               tbl.Columns.Add( this.IsActive );
               tbl.Columns.Add( this.ConnectionStringName );
               tbl.Columns.Add( this.LoadDefaultDatabaseOnly );
               tbl.Columns.Add( this.LoadSystemObjects );
               tbl.Columns.Add( this.WithFields );
               tbl.Columns.Add( this.StagePathDir );
               tbl.Columns.Add( this.ConnectionString );
               tbl.Columns.Add( this.ProviderName );
               tbl.Columns.Add( this.IsValidStagePathDir );
               tbl.Columns.Add( this.IsValidProviderName );
               this.dataStore = tbl;
            }
            return this.dataStore;
         }
      }
   }
}
