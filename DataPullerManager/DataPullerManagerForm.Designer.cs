namespace DataPhilosophiae.Service.DataPuller
{
   partial class DataPullerManagerForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose( bool disposing )
      {
         if( disposing && (components != null) )
         {
            components.Dispose( );
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.statusLabel = new System.Windows.Forms.Label();
         this.startButton = new System.Windows.Forms.Button();
         this.stopButton = new System.Windows.Forms.Button();
         this.timerRefresh = new System.Windows.Forms.Timer(this.components);
         this.logItButton = new System.Windows.Forms.Button();
         this.eventLogTextBox = new System.Windows.Forms.TextBox();
         this.eventLog = new System.Diagnostics.EventLog();
         ((System.ComponentModel.ISupportInitialize)(this.eventLog)).BeginInit();
         this.SuspendLayout();
         // 
         // statusLabel
         // 
         this.statusLabel.AutoSize = true;
         this.statusLabel.Location = new System.Drawing.Point(13, 13);
         this.statusLabel.Name = "statusLabel";
         this.statusLabel.Size = new System.Drawing.Size(35, 13);
         this.statusLabel.TabIndex = 0;
         this.statusLabel.Text = "label1";
         // 
         // startButton
         // 
         this.startButton.Location = new System.Drawing.Point(12, 33);
         this.startButton.Name = "startButton";
         this.startButton.Size = new System.Drawing.Size(75, 23);
         this.startButton.TabIndex = 1;
         this.startButton.Text = "Start";
         this.startButton.UseVisualStyleBackColor = true;
         this.startButton.Click += new System.EventHandler(this.startButton_Click);
         // 
         // stopButton
         // 
         this.stopButton.Location = new System.Drawing.Point(93, 33);
         this.stopButton.Name = "stopButton";
         this.stopButton.Size = new System.Drawing.Size(75, 23);
         this.stopButton.TabIndex = 2;
         this.stopButton.Text = "Stop";
         this.stopButton.UseVisualStyleBackColor = true;
         this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
         // 
         // timerRefresh
         // 
         this.timerRefresh.Enabled = true;
         this.timerRefresh.Interval = 1500;
         this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
         // 
         // logItButton
         // 
         this.logItButton.Location = new System.Drawing.Point(174, 33);
         this.logItButton.Name = "logItButton";
         this.logItButton.Size = new System.Drawing.Size(75, 23);
         this.logItButton.TabIndex = 3;
         this.logItButton.Text = "LogIt";
         this.logItButton.UseVisualStyleBackColor = true;
         this.logItButton.Click += new System.EventHandler(this.logItButton_Click);
         // 
         // eventLogTextBox
         // 
         this.eventLogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.eventLogTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.eventLogTextBox.Location = new System.Drawing.Point(12, 63);
         this.eventLogTextBox.Multiline = true;
         this.eventLogTextBox.Name = "eventLogTextBox";
         this.eventLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.eventLogTextBox.Size = new System.Drawing.Size(543, 186);
         this.eventLogTextBox.TabIndex = 4;
         // 
         // eventLog
         // 
         this.eventLog.EnableRaisingEvents = true;
         this.eventLog.Log = "DataPullerLogger";
         this.eventLog.Source = "DataPullerLoggerService";
         this.eventLog.SynchronizingObject = this;
         this.eventLog.EntryWritten += new System.Diagnostics.EntryWrittenEventHandler(this.eventLog_EntryWritten);
         // 
         // DataPullerManagerForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(565, 261);
         this.Controls.Add(this.eventLogTextBox);
         this.Controls.Add(this.logItButton);
         this.Controls.Add(this.stopButton);
         this.Controls.Add(this.startButton);
         this.Controls.Add(this.statusLabel);
         this.Name = "DataPullerManagerForm";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.DataPullerManagerForm_Load);
         ((System.ComponentModel.ISupportInitialize)(this.eventLog)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label statusLabel;
      private System.Windows.Forms.Button startButton;
      private System.Windows.Forms.Button stopButton;
      private System.Windows.Forms.Timer timerRefresh;
      private System.Windows.Forms.Button logItButton;
      private System.Windows.Forms.TextBox eventLogTextBox;
      private System.Diagnostics.EventLog eventLog;
   }
}

