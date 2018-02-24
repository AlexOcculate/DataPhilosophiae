
namespace WindowsServiceTestShell
{
   static class Program
   {
      private static System.Configuration.Configuration cm = System.Configuration.ConfigurationManager.OpenExeConfiguration( System.Configuration.ConfigurationUserLevel.None );
      private static System.Configuration.KeyValueConfigurationCollection confColl = cm.AppSettings.Settings;
      private static System.Collections.Specialized.NameValueCollection appSettings = System.Configuration.ConfigurationManager.GetSection( "ApplicationSettings" ) as System.Collections.Specialized.NameValueCollection;

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      static void Main()
      {
         AppConfig ac = new AppConfig( cm, confColl );
         if( appSettings.Count > 0 )
         {
            foreach( var key in appSettings.AllKeys )
            {
               System.Console.WriteLine( key + " = " + appSettings[ key ] );
            }
         }
         System.ServiceProcess.ServiceBase[ ] ServicesToRun;
         ServicesToRun = new System.ServiceProcess.ServiceBase[ ]
         {
                new Service1( ac )
         };
#if DEBUG
         ((Service1) ServicesToRun[ 0 ]).OnDebug( );
         System.Threading.Thread.Sleep( System.Threading.Timeout.Infinite );
#else
         System.ServiceProcess.ServiceBase.Run( ServicesToRun );
#endif
      }
   }
}
