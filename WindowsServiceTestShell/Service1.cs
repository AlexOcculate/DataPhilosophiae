using System.ServiceProcess;

/*
Main difference is that InstallUtil is not utility meant for service installation but as general installer tool. From MSDN pages you can see that:

"The Installer tool is a command-line utility that allows you to install and uninstall server resources by executing the installer components in specified assemblies. This tool works in conjunction with classes in the System.Configuration.Install namespace."

So it can install service but it has many many many other benefits. Creating executables based on Installer Class gives you programatic control of whole installation/uninstallation procedure. ServiceInstaller and ServiceProcessInstaller, for instance, are used for service installation.

I prefer sc.exe over installutil.exe million times.

InstallUtil forces you to add the dreadful ProjectInstaller class (I believe) and hardcode there the service name and service description.

This is makes it very hard to put two versions of the same service running in the same machine at the same time.

'Sc' utility is used for service control and 'create' command will just create service based on chosen executable.

// Open windows command prompt as run as administrator
//
// sc.exe create ExampleService binPath= "F:\full\path\name.exe"
// sc.exe delete ExampleService
//
// installutil ExampleService
// installutil /u ExampleService


*/
namespace WindowsServiceTestShell
{
   public partial class Service1 : System.ServiceProcess.ServiceBase
   {
      private System.Timers.Timer _timer = null;

      // Must be int between 128 and 255
      // Numbers 0-127 are reserved for windows, and are handled in the base class.
      // 128 to 255 are there for your own use.
      public enum CustomCommand
      {
         LogIt = 255
      };
      //
      public Service1( AppConfig ac )
      {
         {
            InitializeComponent( );
            this.ServiceName = AppConfig.ServiceInstallerServiceName; // "Service1";
         }
         // Set the timer to fire every sixty seconds
         // (remember the timer is in millisecond resolution,
         //  so 1000 = 1 second. )
         this._timer = new System.Timers.Timer( AppConfig.ServiceInstallerHeartBeat );
         // Now tell the timer when the timer fires
         // (the Elapsed event) call the _timer_Elapsed
         // method in our code
         this._timer.Elapsed += new System.Timers.ElapsedEventHandler( this.OnTimeElapsed );
      }

      #region --- Service Events ---
      public void OnDebug()
      {
         log( "OnDebug" );
         OnStart( null );
         OnCustomCommand( (int) CustomCommand.LogIt );
      }

      protected override void OnStart( string[ ] args )
      {
         log( "OnStart" );
         this._timer.Start( );
      }

      protected override void OnStop()
      {
         log( "OnStop" );
         this._timer.Stop( );
      }

      protected override void OnContinue()
      {
         log( "OnContinue" );
         base.OnContinue( );
         this._timer.Start( );
      }

      protected override void OnPause()
      {
         log( "OnPause" );
         base.OnPause( );
         this._timer.Stop( );
      }

      protected override void OnShutdown()
      {
         log( "OnShutdown" );
         base.OnShutdown( );
         this._timer.Stop( );
      }

      protected override bool OnPowerEvent( PowerBroadcastStatus powerStatus )
      {
         log( "OnPowerEvent" );
         return base.OnPowerEvent( powerStatus );
      }

      protected override void OnSessionChange( SessionChangeDescription changeDescription )
      {
         log( "OnSessionChange" );
         base.OnSessionChange( changeDescription );
      }

      // This method is called when the timer fires it’s elapsed event.
      // It will write the time to the event log.
      protected void OnTimeElapsed( object sender, System.Timers.ElapsedEventArgs e )
      {
         log( "OnTimeElapsed" );
      }

      const string STR_Db = @"Data Source=D:\TEMP\SQLite\chinook\chinook.db;";
      //const string STR_Db = @"Data Source=C:\Program Files (x86)\DataPhilosophiae\DataUnderstanding\WindowsServiceTestShell\chinook.db;";
      protected override void OnCustomCommand( int command )
      {
         log( "OnCustomCommand" );
         base.OnCustomCommand( command );
         var sQLContext = CreateAqbQbSQLite( STR_Db );
      }

      #endregion

      private static ActiveQueryBuilder.Core.SQLContext CreateAqbQbSQLite( /*DataModel.DataStore*/ string ds )
      {
         //return null;
         ActiveQueryBuilder.Core.SQLContext sc = new ActiveQueryBuilder.Core.SQLContext( )
         {
            SyntaxProvider = new ActiveQueryBuilder.Core.SQLiteSyntaxProvider( ),
            MetadataProvider = new ActiveQueryBuilder.Core.SQLiteMetadataProvider( )
            {
               Connection = new System.Data.SQLite.SQLiteConnection( )
               {
                  ConnectionString = ds //.ConnectionString
               }
            }
         };
         return sc;
      }

      #region --- Write To Log Methdos ---
      private void log( string eventName )
      {
         li( AppConfig.ServiceInstallerServiceName + eventName );
         //string x = System.Environment.CurrentDirectory;
         string f = System.AppDomain.CurrentDomain.BaseDirectory + AppConfig.ServiceInstallerServiceName + "." + eventName + ".txt";
         System.IO.File.Create( f );
      }

      private void WriteToLog( string msg, System.Diagnostics.EventLogEntryType type = System.Diagnostics.EventLogEntryType.Information )
      {
         System.Diagnostics.EventLog evt = new System.Diagnostics.EventLog( AppConfig.ServiceLoggerName );
         string message = msg
            + ": "
            + System.DateTime.Now.ToShortDateString( )
            + " "
            + System.DateTime.Now.ToLongTimeString( )
            ;
         evt.Source = AppConfig.ServiceLoggerSourceName;
         evt.WriteEntry( message, type );
      }
      private void li( string msg )
      {
         WriteToLog( msg, System.Diagnostics.EventLogEntryType.Information );
      }
      private void le( string msg )
      {
         WriteToLog( msg, System.Diagnostics.EventLogEntryType.Error );
      }
      private void laf( string msg )
      {
         WriteToLog( msg, System.Diagnostics.EventLogEntryType.FailureAudit );
      }
      private void las( string msg )
      {
         WriteToLog( msg, System.Diagnostics.EventLogEntryType.SuccessAudit );
      }
      private void lw( string msg )
      {
         WriteToLog( msg, System.Diagnostics.EventLogEntryType.Warning );
      }
      #endregion
   }
}
