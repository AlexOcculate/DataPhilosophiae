namespace DataPhilosophiae.DataModel
{
   public class DataStoreSnapshotTable
   {
      //private System.Data.DataColumn id;
      //public System.Data.DataColumn ID
      //{
      //   get
      //   {
      //      if( this.id == null )
      //      {
      //         System.Data.DataColumn c = new System.Data.DataColumn( );
      //         c.DataType = System.Type.GetType( "System.Int32" );
      //         c.ColumnName = "ID";
      //         c.Caption = "Id";
      //         c.ReadOnly = true;
      //         c.Unique = false;
      //         this.id = c;
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
               System.Data.DataColumn c = new System.Data.DataColumn( );
               c.DataType = System.Type.GetType( "System.String" );
               c.ColumnName = "Name";
               c.ReadOnly = true;
               this.name = c;
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
               System.Data.DataColumn c = new System.Data.DataColumn( );
               c.DataType = System.Type.GetType( "System.Boolean" );
               c.ColumnName = "IsActive";
               c.ReadOnly = false;
               this.isActive = c;
            }
            return this.isActive;
         }
      }

      private System.Data.DataColumn snapshotFile;
      public System.Data.DataColumn SnapshotFile
      {
         get
         {
            if( this.snapshotFile == null )
            {
               System.Data.DataColumn c = new System.Data.DataColumn( );
               c.DataType = System.Type.GetType( "System.String" );
               c.ColumnName = "SnapshotFile";
               c.ReadOnly = true;
               this.snapshotFile = c;
            }
            return this.snapshotFile;
         }
      }

      private System.Data.DataTable dataStoreSnapshot;
      public System.Data.DataTable DataStoreSnapShot
      {
         get
         {
            if( this.dataStoreSnapshot == null )
            {
               {
                  System.Data.DataTable tbl = new System.Data.DataTable( "DataStoreSnapshot" );
                  //tbl.Columns.Add( this.ID );
                  tbl.Columns.Add( this.Name );
                  tbl.Columns.Add( this.IsActive );
                  tbl.Columns.Add( this.SnapshotFile );
                  this.dataStoreSnapshot = tbl;
               }
            }
            return this.dataStoreSnapshot;
         }
      }
   }
}
