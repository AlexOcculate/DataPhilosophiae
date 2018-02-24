namespace DataPhilosophiae.Service.DataPuller
{
   // Must be int between 128 and 255
   // Numbers 0-127 are reserved for windows, and are handled in the base class.
   // 128 to 255 are there for your own use.
   public enum CustomCommand
   {
      LogIt = 255
   };
   //
   public partial class DataPullerService : System.ServiceProcess.ServiceBase
   {
      public const string SERVICE_NAME_PREFIX = "DataPuller";
      public const string SERVICE_LOGGER_NAME = SERVICE_NAME_PREFIX + "Logger";
      public const string SERVICE_LOGGER_SOURCE_NAME = SERVICE_LOGGER_NAME + "Service";
      public const int SERVICE_TIMER_INTERVAL = (60 * 60 * 1000);

      private System.Timers.Timer _timer = null;

      public DataPullerService()
      {
         InitializeComponent( );
         // Set the timer to fire every sixty seconds
         // (remember the timer is in millisecond resolution,
         //  so 1000 = 1 second. )
         this._timer = new System.Timers.Timer( SERVICE_TIMER_INTERVAL );
         // Now tell the timer when the timer fires
         // (the Elapsed event) call the _timer_Elapsed
         // method in our code
         this._timer.Elapsed += new System.Timers.ElapsedEventHandler( this._timer_Elapsed );
      }

      #region --- Write To Log Methdos ---
      private void WriteToLog( string msg, System.Diagnostics.EventLogEntryType type = System.Diagnostics.EventLogEntryType.Information )
      {
         System.Diagnostics.EventLog evt = new System.Diagnostics.EventLog( SERVICE_LOGGER_NAME );
         string message = msg
            + ": "
            + System.DateTime.Now.ToShortDateString( )
            + " "
            + System.DateTime.Now.ToLongTimeString( )
            ;
         evt.Source = SERVICE_LOGGER_SOURCE_NAME;
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

      #region --- Service Events ---
      public void OnDebug()
      {
         li( SERVICE_NAME_PREFIX + " OnDebug" );
         string x = System.Environment.CurrentDirectory;
         string f = System.AppDomain.CurrentDomain.BaseDirectory + DataPhilosophiae.Core.Global.TS_STR + ".OnDebug.txt";
         System.IO.File.Create( f );
         //
         OnStart( null );
         OnCustomCommand( (int) CustomCommand.LogIt );
      }

      protected override void OnCustomCommand( int command )
      {
         li( SERVICE_NAME_PREFIX + " OnCustomCommand" );
         string f = System.AppDomain.CurrentDomain.BaseDirectory + DataPhilosophiae.Core.Global.TS_STR + ".OnCustomCommand.txt";
         System.IO.File.Create( f );
         base.OnCustomCommand( command );
         if( command == (int) CustomCommand.LogIt )
         {
            li( SERVICE_NAME_PREFIX + CustomCommand.LogIt.ToString( ) + ": [START] " );
            try
            {
               DataPhilosophiae.Core.DataPuller.Engine.Start( );
            }
            catch( System.Exception ex )
            {
               le( SERVICE_NAME_PREFIX + CustomCommand.LogIt.ToString( ) + ": [EXCPT]" );
               string ef = System.AppDomain.CurrentDomain.BaseDirectory + DataPhilosophiae.Core.Global.TS_STR + ".OnException.txt";
               using( var fs = System.IO.File.Create( ef, 1024, System.IO.FileOptions.WriteThrough ) )
               {
                  using( System.IO.StreamWriter sw = new System.IO.StreamWriter( fs, System.Text.Encoding.UTF8, 512, false ) )
                  {
                     sw.AutoFlush = true;
                     sw.WriteLine( ex.ToString( ) );
                  }
               }
            }
            li( SERVICE_NAME_PREFIX + CustomCommand.LogIt.ToString( ) + ": [  END]" );
         }
      }

      protected override void OnStart( string[ ] args )
      {
         li( SERVICE_NAME_PREFIX + " OnStart" );
         string f = System.AppDomain.CurrentDomain.BaseDirectory + DataPhilosophiae.Core.Global.TS_STR + ".OnStart.txt";
         System.IO.File.Create( f );
         this._timer.Start( );
      }

      protected override void OnStop()
      {
         li( SERVICE_NAME_PREFIX + " OnStop" );
         string f = System.AppDomain.CurrentDomain.BaseDirectory + DataPhilosophiae.Core.Global.TS_STR + ".OnStop.txt";
         System.IO.File.Create( f );
         this._timer.Stop( );
      }

      protected override void OnContinue()
      {
         li( SERVICE_NAME_PREFIX + " OnContinue" );
         string f = System.AppDomain.CurrentDomain.BaseDirectory + DataPhilosophiae.Core.Global.TS_STR + ".OnContinue.txt";
         System.IO.File.Create( f );
         base.OnContinue( );
         this._timer.Start( );
      }

      protected override void OnPause()
      {
         li( SERVICE_NAME_PREFIX + " OnPause" );
         string f = System.AppDomain.CurrentDomain.BaseDirectory + DataPhilosophiae.Core.Global.TS_STR + ".OnPause.txt";
         System.IO.File.Create( f );
         base.OnPause( );
         this._timer.Stop( );
      }

      protected override void OnShutdown()
      {
         li( SERVICE_NAME_PREFIX + " OnShutdown" );
         string f = System.AppDomain.CurrentDomain.BaseDirectory + DataPhilosophiae.Core.Global.TS_STR + ".OnShutdown.txt";
         System.IO.File.Create( f );
         base.OnShutdown( );
         this._timer.Stop( );
      }
      #endregion

      // This method is called when the timer fires
      // it’s elapsed event. It will write the time
      // to the event log.
      protected void _timer_Elapsed( object sender, System.Timers.ElapsedEventArgs e )
      {
         li( SERVICE_NAME_PREFIX + " Timer" );
      }
   }
}
