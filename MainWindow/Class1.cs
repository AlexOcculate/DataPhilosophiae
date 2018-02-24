using System.Data;

namespace MainWindow
{
   public class MyVirtualTables
   {
      // Put the next line into the Declarations section.
      public System.Data.DataSet dataSet;
      public System.Data.DataView dv;
      public System.Data.DataSet x()
      {
         System.Data.DataSet ds = new System.Data.DataSet( "DataStoreSnapshot" );
         {
            ds.Tables.Add( CreateTable( "DSSS_01" ) );
            ds.Tables.Add( CreateTable( "DSSS_02" ) );
            ds.Tables.Add( CreateTable( "DSSS_03" ) );
         }
         {
            System.Data.DataView dw1 = new System.Data.DataView( ds.Tables[ "DSSS_01" ] );
            System.Data.DataView dw2 = new System.Data.DataView( ds.Tables[ "DSSS_02" ] );
            System.Data.DataView dw3 = new System.Data.DataView( ds.Tables[ "DSSS_03" ] );

            dw1.Table.Merge( dw2.Table );
            dw1.Table.Merge( dw3.Table );

            this.dv = dw1;
         }
         return ds;
      }

      private static DataTable CreateTable( string tableName )
      {
         System.Data.DataTable tbl = new System.Data.DataTable( tableName );
         {
            System.Data.DataColumn col = new System.Data.DataColumn( );
            col.DataType = System.Type.GetType( "System.Int32" );
            col.ColumnName = "ID";
            col.Caption = "ID";
            col.ReadOnly = true;
            col.Unique = false;
            tbl.Columns.Add( col );
         }
         {
            System.Data.DataColumn col = new System.Data.DataColumn( );
            col.DataType = System.Type.GetType( "System.String" );
            col.ColumnName = "DataStore";
            col.AutoIncrement = false;
            col.Caption = "DataStore";
            col.ReadOnly = false;
            col.Unique = false;
            tbl.Columns.Add( col );
         }
         for( int i = 0; i <= 2; i++ )
         {
            System.Data.DataRow row = tbl.NewRow( );
            row[ "id" ] = i;
            row[ "DataStore" ] = tableName;
            tbl.Rows.Add( row );
         }

         return tbl;
      }

      ///////////////////////////////////////////////////////////////////////////

      public void MakeDataTables()
      {
         // Run all of the functions. 
         MakeParentTable( );
         MakeChildTable( );
         MakeDataRelation( );
         //BindToDataGrid( );
      }

      private void MakeParentTable()
      {
         // Create a new DataTable.
         System.Data.DataTable table = new DataTable( "ParentTable" );
         // Declare variables for DataColumn and DataRow objects.
         DataColumn column;
         DataRow row;

         // Create new DataColumn, set DataType, 
         // ColumnName and add to DataTable.    
         column = new DataColumn( );
         column.DataType = System.Type.GetType( "System.Int32" );
         column.ColumnName = "id";
         column.ReadOnly = true;
         column.Unique = true;
         // Add the Column to the DataColumnCollection.
         table.Columns.Add( column );

         // Create second column.
         column = new DataColumn( );
         column.DataType = System.Type.GetType( "System.String" );
         column.ColumnName = "ParentItem";
         column.AutoIncrement = false;
         column.Caption = "ParentItem";
         column.ReadOnly = false;
         column.Unique = false;
         // Add the column to the table.
         table.Columns.Add( column );

         // Make the ID column the primary key column.
         DataColumn[ ] PrimaryKeyColumns = new DataColumn[ 1 ];
         PrimaryKeyColumns[ 0 ] = table.Columns[ "id" ];
         table.PrimaryKey = PrimaryKeyColumns;

         // Instantiate the DataSet variable.
         this.dataSet = new DataSet( );
         // Add the new DataTable to the DataSet.
         this.dataSet.Tables.Add( table );

         // Create three new DataRow objects and add 
         // them to the DataTable
         for( int i = 0; i <= 2; i++ )
         {
            row = table.NewRow( );
            row[ "id" ] = i;
            row[ "ParentItem" ] = "ParentItem " + i;
            table.Rows.Add( row );
         }
      }

      private void MakeChildTable()
      {
         // Create a new DataTable.
         DataTable table = new DataTable( "childTable" );
         DataColumn column;
         DataRow row;

         // Create first column and add to the DataTable.
         column = new DataColumn( );
         column.DataType = System.Type.GetType( "System.Int32" );
         column.ColumnName = "ChildID";
         column.AutoIncrement = true;
         column.Caption = "ID";
         column.ReadOnly = true;
         column.Unique = true;

         // Add the column to the DataColumnCollection.
         table.Columns.Add( column );

         // Create second column.
         column = new DataColumn( );
         column.DataType = System.Type.GetType( "System.String" );
         column.ColumnName = "ChildItem";
         column.AutoIncrement = false;
         column.Caption = "ChildItem";
         column.ReadOnly = false;
         column.Unique = false;
         table.Columns.Add( column );

         // Create third column.
         column = new DataColumn( );
         column.DataType = System.Type.GetType( "System.Int32" );
         column.ColumnName = "ParentID";
         column.AutoIncrement = false;
         column.Caption = "ParentID";
         column.ReadOnly = false;
         column.Unique = false;
         table.Columns.Add( column );

         this.dataSet.Tables.Add( table );

         // Create three sets of DataRow objects, 
         // five rows each, and add to DataTable.
         for( int i = 0; i <= 4; i++ )
         {
            row = table.NewRow( );
            row[ "childID" ] = i;
            row[ "ChildItem" ] = "Item " + i;
            row[ "ParentID" ] = 0;
            table.Rows.Add( row );
         }
         for( int i = 0; i <= 4; i++ )
         {
            row = table.NewRow( );
            row[ "childID" ] = i + 5;
            row[ "ChildItem" ] = "Item " + i;
            row[ "ParentID" ] = 1;
            table.Rows.Add( row );
         }
         for( int i = 0; i <= 4; i++ )
         {
            row = table.NewRow( );
            row[ "childID" ] = i + 10;
            row[ "ChildItem" ] = "Item " + i;
            row[ "ParentID" ] = 2;
            table.Rows.Add( row );
         }
      }

      private void MakeDataRelation()
      {
         // DataRelation requires two DataColumn 
         // (parent and child) and a name.
         DataColumn parentColumn = this.dataSet.Tables[ "ParentTable" ].Columns[ "id" ];
         DataColumn childColumn = this.dataSet.Tables[ "ChildTable" ].Columns[ "ParentID" ];
         DataRelation relation = new DataRelation( "parent2Child", parentColumn, childColumn );
         this.dataSet.Tables[ "ChildTable" ].ParentRelations.Add( relation );
      }

      //private void BindToDataGrid()
      //{
      //   // Instruct the DataGrid to bind to the DataSet, with the 
      //   // ParentTable as the topmost DataTable.
      //   dataGrid1.SetDataBinding( this.dataSet, "ParentTable" );
      //}
   }
}
