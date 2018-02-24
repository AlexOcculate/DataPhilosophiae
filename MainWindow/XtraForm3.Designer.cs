namespace DataPhilosophiae
{
   partial class XtraForm3
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
         this.tabFormControl = new DevExpress.XtraBars.TabFormControl();
         this.dataStoreTabFormPage = new DevExpress.XtraBars.TabFormPage();
         this.dataStoreTabFormContentContainer = new DevExpress.XtraBars.TabFormContentContainer();
         this.dataStoreGridControl = new DevExpress.XtraGrid.GridControl();
         this.dataStoreGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.dataStoreSnapshotTabFormPage = new DevExpress.XtraBars.TabFormPage();
         this.dataStoreSnapshotTabFormContentContainer = new DevExpress.XtraBars.TabFormContentContainer();
         this.dataStoreSnapshotGridControl = new DevExpress.XtraGrid.GridControl();
         this.dataStoreSnapshotGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
         ((System.ComponentModel.ISupportInitialize)(this.tabFormControl)).BeginInit();
         this.dataStoreTabFormContentContainer.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataStoreGridControl)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataStoreGridView)).BeginInit();
         this.dataStoreSnapshotTabFormContentContainer.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataStoreSnapshotGridControl)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataStoreSnapshotGridView)).BeginInit();
         this.SuspendLayout();
         // 
         // tabFormControl
         // 
         this.tabFormControl.Location = new System.Drawing.Point(0, 0);
         this.tabFormControl.Name = "tabFormControl";
         this.tabFormControl.Pages.Add(this.dataStoreTabFormPage);
         this.tabFormControl.Pages.Add(this.dataStoreSnapshotTabFormPage);
         this.tabFormControl.SelectedPage = this.dataStoreTabFormPage;
         this.tabFormControl.ShowAddPageButton = false;
         this.tabFormControl.ShowTabCloseButtons = false;
         this.tabFormControl.Size = new System.Drawing.Size(1075, 50);
         this.tabFormControl.TabForm = this;
         this.tabFormControl.TabIndex = 0;
         this.tabFormControl.TabStop = false;
         // 
         // dataStoreTabFormPage
         // 
         this.dataStoreTabFormPage.ContentContainer = this.dataStoreTabFormContentContainer;
         this.dataStoreTabFormPage.Name = "dataStoreTabFormPage";
         this.dataStoreTabFormPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
         this.dataStoreTabFormPage.Text = "DataStores";
         // 
         // dataStoreTabFormContentContainer
         // 
         this.dataStoreTabFormContentContainer.Controls.Add(this.dataStoreGridControl);
         this.dataStoreTabFormContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataStoreTabFormContentContainer.Location = new System.Drawing.Point(0, 50);
         this.dataStoreTabFormContentContainer.Name = "dataStoreTabFormContentContainer";
         this.dataStoreTabFormContentContainer.Size = new System.Drawing.Size(1075, 510);
         this.dataStoreTabFormContentContainer.TabIndex = 1;
         // 
         // dataStoreGridControl
         // 
         this.dataStoreGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataStoreGridControl.Location = new System.Drawing.Point(0, 0);
         this.dataStoreGridControl.MainView = this.dataStoreGridView;
         this.dataStoreGridControl.Name = "dataStoreGridControl";
         this.dataStoreGridControl.Size = new System.Drawing.Size(1075, 510);
         this.dataStoreGridControl.TabIndex = 0;
         this.dataStoreGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dataStoreGridView});
         // 
         // dataStoreGridView
         // 
         this.dataStoreGridView.GridControl = this.dataStoreGridControl;
         this.dataStoreGridView.Name = "dataStoreGridView";
         this.dataStoreGridView.OptionsFind.AlwaysVisible = true;
         this.dataStoreGridView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
         this.dataStoreGridView.OptionsMenu.ShowConditionalFormattingItem = true;
         this.dataStoreGridView.OptionsMenu.ShowFooterItem = true;
         this.dataStoreGridView.OptionsMenu.ShowGroupSummaryEditorItem = true;
         this.dataStoreGridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
         this.dataStoreGridView.OptionsView.ShowAutoFilterRow = true;
         this.dataStoreGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
         this.dataStoreGridView.OptionsView.ShowFooter = true;
         // 
         // dataStoreSnapshotTabFormPage
         // 
         this.dataStoreSnapshotTabFormPage.ContentContainer = this.dataStoreSnapshotTabFormContentContainer;
         this.dataStoreSnapshotTabFormPage.Name = "dataStoreSnapshotTabFormPage";
         this.dataStoreSnapshotTabFormPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
         this.dataStoreSnapshotTabFormPage.Text = "Snapshots";
         // 
         // dataStoreSnapshotTabFormContentContainer
         // 
         this.dataStoreSnapshotTabFormContentContainer.Controls.Add(this.dataStoreSnapshotGridControl);
         this.dataStoreSnapshotTabFormContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataStoreSnapshotTabFormContentContainer.Location = new System.Drawing.Point(0, 50);
         this.dataStoreSnapshotTabFormContentContainer.Name = "dataStoreSnapshotTabFormContentContainer";
         this.dataStoreSnapshotTabFormContentContainer.Size = new System.Drawing.Size(1075, 510);
         this.dataStoreSnapshotTabFormContentContainer.TabIndex = 2;
         // 
         // dataStoreSnapshotGridControl
         // 
         this.dataStoreSnapshotGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataStoreSnapshotGridControl.Location = new System.Drawing.Point(0, 0);
         this.dataStoreSnapshotGridControl.MainView = this.dataStoreSnapshotGridView;
         this.dataStoreSnapshotGridControl.Name = "dataStoreSnapshotGridControl";
         this.dataStoreSnapshotGridControl.Size = new System.Drawing.Size(1075, 510);
         this.dataStoreSnapshotGridControl.TabIndex = 0;
         this.dataStoreSnapshotGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dataStoreSnapshotGridView});
         // 
         // dataStoreSnapshotGridView
         // 
         this.dataStoreSnapshotGridView.GridControl = this.dataStoreSnapshotGridControl;
         this.dataStoreSnapshotGridView.Name = "dataStoreSnapshotGridView";
         // 
         // XtraForm3
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1075, 560);
         this.Controls.Add(this.dataStoreTabFormContentContainer);
         this.Controls.Add(this.tabFormControl);
         this.Name = "XtraForm3";
         this.TabFormControl = this.tabFormControl;
         this.Text = "XtraForm3";
         ((System.ComponentModel.ISupportInitialize)(this.tabFormControl)).EndInit();
         this.dataStoreTabFormContentContainer.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataStoreGridControl)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataStoreGridView)).EndInit();
         this.dataStoreSnapshotTabFormContentContainer.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataStoreSnapshotGridControl)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataStoreSnapshotGridView)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraBars.TabFormControl tabFormControl;
      private DevExpress.XtraBars.TabFormPage dataStoreTabFormPage;
      private DevExpress.XtraBars.TabFormContentContainer dataStoreTabFormContentContainer;
      private DevExpress.XtraGrid.GridControl dataStoreGridControl;
      private DevExpress.XtraGrid.Views.Grid.GridView dataStoreGridView;
      private DevExpress.XtraBars.TabFormPage dataStoreSnapshotTabFormPage;
      private DevExpress.XtraBars.TabFormContentContainer dataStoreSnapshotTabFormContentContainer;
      private DevExpress.XtraGrid.GridControl dataStoreSnapshotGridControl;
      private DevExpress.XtraGrid.Views.Grid.GridView dataStoreSnapshotGridView;
   }
}