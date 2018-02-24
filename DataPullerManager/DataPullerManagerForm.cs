using System;
using System.ServiceProcess;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;

namespace DataPhilosophiae.Service.DataPuller
{
   public partial class DataPullerManagerForm : Form
   {
      public DataPullerManagerForm()
      {
         InitializeComponent( );
         ServiceController sc = new ServiceController( DataPuller.DataPullerService.SERVICE_NAME_PREFIX );
         SetDisplay( sc );
      }

      private void SetDisplay( ServiceController sc )
      {
         sc.Refresh( );
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
            ServiceController sc = new ServiceController( DataPuller.DataPullerService.SERVICE_NAME_PREFIX );
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

         }
      }

      private void stopButton_Click( object sender, EventArgs e )
      {
         try
         {
            ServiceController sc = new ServiceController( DataPuller.DataPullerService.SERVICE_NAME_PREFIX );
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
            ServiceController sc = new ServiceController( DataPuller.DataPullerService.SERVICE_NAME_PREFIX );
            if( sc == null )
               return;
            sc.ExecuteCommand( (int) DataPuller.CustomCommand.LogIt );
         }
         //catch( System.InvalidOperationException ex )
         catch( Exception ex )
         {

         }
      }

      private void timerRefresh_Tick( object sender, EventArgs e )
      {
         ServiceController sc = new ServiceController( DataPuller.DataPullerService.SERVICE_NAME_PREFIX );
         SetDisplay( sc );
      }

      private void DataPullerManagerForm_Load( object sender, EventArgs e )
      {
         StringBuilder sb = new StringBuilder( );
         EventLog atl = new EventLog( DataPuller.DataPullerService.SERVICE_LOGGER_NAME );
         int start = atl.Entries.Count - 1;
         for( int i = start; i > -1; i-- )
         {
            sb.AppendLine( atl.Entries[ i ].Message );
         }
         this.eventLogTextBox.Text = sb.ToString( );
      }
   }
}
