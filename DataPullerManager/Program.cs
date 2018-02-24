namespace DataPhilosophiae.Service.DataPuller
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [System.STAThread]
      static void Main()
      {
         System.Console.WriteLine( );
         System.Console.WriteLine( "BEGIN" );
         System.Windows.Forms.Application.EnableVisualStyles( );
         System.Windows.Forms.Application.SetCompatibleTextRenderingDefault( false );
         System.Windows.Forms.Application.Run( new DataPullerManagerForm( ) );
         System.Console.WriteLine( );
         System.Console.WriteLine( "END" );
      }
   }
}
