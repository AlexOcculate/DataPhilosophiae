using System;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace WindowsServiceTestShellManager
{
   public partial class Form1 : Form
   {
      public const string SERVICE_NAME_PREFIX = "WindowsServiceTestShell.exe";
      public const string SERVICE_LOGGER_NAME = SERVICE_NAME_PREFIX + "Logger";
      public const string SERVICE_LOGGER_SOURCE_NAME = SERVICE_LOGGER_NAME + "Service";
      public const int SERVICE_TIMER_INTERVAL = (60 * 60 * 1000);

      // Must be int between 128 and 255
      // Numbers 0-127 are reserved for windows, and are handled in the base class.
      // 128 to 255 are there for your own use.
      public enum CustomCommand
      {
         LogIt = 255
      };

      public Form1()
      {
         InitializeComponent( );
         ServiceController sc = new ServiceController( SERVICE_NAME_PREFIX );
         SetDisplay( sc );
      }

      private void SetDisplay( ServiceController sc )
      {
         sc.Refresh( );
         try
         {
            this.statusLabel.Text = sc.Status.ToString( );
            if( sc.Status == ServiceControllerStatus.Stopped )
            {
               this.stopButton.Enabled = false;
               this.startButton.Enabled = true;
               this.logItButton.Enabled = false;
            }
            if( sc.Status == ServiceControllerStatus.Running )
            {
               this.startButton.Enabled = false;
               this.stopButton.Enabled = true;
               this.logItButton.Enabled = true;
            }
         }
         catch( System.InvalidOperationException ex )
         {
            
         }
      }

      private void eventLog_EntryWritten( object sender, System.Diagnostics.EntryWrittenEventArgs e )
      {
         this.eventLogTextBox.Text = e.Entry.Message
           + System.Environment.NewLine
           + this.eventLogTextBox.Text
           ;
      }

      private void startButton_Click( object sender, EventArgs e )
      {
         try
         {
            ServiceController sc = new ServiceController( SERVICE_NAME_PREFIX );
            if( sc == null || sc.Status != ServiceControllerStatus.Stopped )
            {
               return;
            }
            sc.Start( );
            this.startButton.Enabled = false;
            this.stopButton.Enabled = true;
            this.logItButton.Enabled = true;
            this.statusLabel.Text = "Running";
            sc.Refresh( );
         }
         //catch( System.InvalidOperationException ex )
         catch( Exception ex )
         {
            this.eventLogTextBox.Text = ex.Message;
         }
      }

      private void stopButton_Click( object sender, EventArgs e )
      {
         try
         {
            ServiceController sc = new ServiceController( SERVICE_NAME_PREFIX );
            if( sc == null || sc.Status == ServiceControllerStatus.Stopped )
            {
               return;
            }
            sc.Stop( );
            this.stopButton.Enabled = false;
            this.startButton.Enabled = true;
            this.logItButton.Enabled = false;
            this.statusLabel.Text = "Stopped";
            sc.Refresh( );
         }
         //catch( System.InvalidOperationException ex )
         catch( Exception ex )
         {

         }
      }

      private void logItButton_Click( object sender, EventArgs e )
      {
         try
         {
            ServiceController sc = new ServiceController( SERVICE_NAME_PREFIX );
            if( sc == null )
               return;
            sc.ExecuteCommand( (int) CustomCommand.LogIt );
         }
         //catch( System.InvalidOperationException ex )
         catch( Exception ex )
         {

         }
      }

      private void timerRefresh_Tick( object sender, EventArgs e )
      {
         ServiceController sc = new ServiceController( SERVICE_NAME_PREFIX );
         SetDisplay( sc );
      }

      private void DataPullerManagerForm_Load( object sender, EventArgs e )
      {
         StringBuilder sb = new StringBuilder( );
         System.Diagnostics.EventLog atl = new System.Diagnostics.EventLog( SERVICE_LOGGER_NAME );
         try
         {
            int start = atl.Entries.Count - 1;
            for( int i = start; i > -1; i-- )
            {
               sb.AppendLine( atl.Entries[ i ].Message );
            }
            this.eventLogTextBox.Text = sb.ToString( );
         }
         catch( System.InvalidOperationException ex )
         {
            this.eventLogTextBox.Text = "--- NO LOG SO FAR! ---";
         }
      }
   }
}
