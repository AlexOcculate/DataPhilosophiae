namespace DataPhilosophiae.Service.DataPuller
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      //[System.STAThread] // @#$%
      static void Main()
      {
         //System.Windows.Forms.Application.EnableVisualStyles( );
         //System.Windows.Forms.Application.SetCompatibleTextRenderingDefault( false );
         //Application.Run( new DataPullerManagerForm( ) );
         //
         System.ServiceProcess.ServiceBase[ ] ServicesToRun;
         ServicesToRun = new System.ServiceProcess.ServiceBase[ ]
         {
                new DataPullerService()
         };
#if DEBUG
         ((DataPullerService) ServicesToRun[ 0 ]).OnDebug( );
         System.Threading.Thread.Sleep( System.Threading.Timeout.Infinite );
#else
         System.ServiceProcess.ServiceBase.Run( ServicesToRun );
#endif
      }
   }
}
