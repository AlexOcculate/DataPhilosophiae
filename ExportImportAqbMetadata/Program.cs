
using System.Windows.Forms;

namespace ExportImportAqbMetadata
{
   static class Program
   {
      private static string filepath = @"D:\TEMP\SQLite\DSCOLL_PATHDIR\blade04\20180125-144413-7068846+1100.ChiNook.AqbQb.xml";
      private static string filepath2 = @"D:\TEMP\SQLite\DSCOLL_PATHDIR\blade04\20180125-144413-7068846+1100.ChiNook.DataSet.xml";
      private static string filepath3 = @"D:\TEMP\SQLite\DSCOLL_PATHDIR\blade04\20180125-144413-7068846+1100.ChiNook.DataSet.bin";
      private static System.Data.DataSet ds;

      [System.STAThread]
      static void Main()
      {
         Application.EnableVisualStyles( );
         Application.SetCompatibleTextRenderingDefault( false );
         NewMethod( );
         Application.Run( new Form1( ) );
      }

      private static void NewMethod()
      {
         ds = new System.Data.DataSet( "X" );
         {
            ds.Tables.Add( Class1.CreateDataStoreConfigTable( ) );
            ds.Tables.Add( Class1.CreateDataStoreSnapshotFileTable( ) );
            ds.Tables.Add( Class1.CreateMetadataItemTable( ) );
         }
         Class1.LoadDataStoreSnapshotFilesTable( ds );
         {
            ActiveQueryBuilder.Core.SQLContext sc = Class1.CreateAqbSqlContext4SQLiteOffline( filepath );
            Class1.DrillDownAqbSqlContext( sc, ds.Tables[ Class1.MetadataItem_TblName ], "Ale" );
         }

         //ds.Tables.Add( Class1.CreateDataSetSnapshotTable( ) );
         //ds.Tables.Add( Class1.CreateMetadataItemTable( ) );
         //Class1.ZZZZZZZZ( ds );
         ////
         ////
         ds.WriteXml( filepath2 );
         //{
         //   ds.RemotingFormat = System.Data.SerializationFormat.Binary;
         //   using( System.IO.FileStream fs = new System.IO.FileStream( filepath3, System.IO.FileMode.Create ) )
         //   {
         //      System.Runtime.Serialization.Formatters.Binary.BinaryFormatter fmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter( );
         //      fmt.Serialize( fs, ds );
         //      fs.Close( );
         //   }
         //}
         //{
         //   System.Data.DataSet o = new System.Data.DataSet( );
         //   o.ReadXml( filepath2 );
         //}
      }
   }
}
