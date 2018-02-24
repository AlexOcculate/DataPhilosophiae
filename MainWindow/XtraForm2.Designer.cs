namespace DataPhilosophiae
{
   partial class XtraForm2
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
         this.tabFormControl1 = new DevExpress.XtraBars.TabFormControl();
         this.dataStoreTabFormPage = new DevExpress.XtraBars.TabFormPage();
         this.dataStoreTabFormContentContainer = new DevExpress.XtraBars.TabFormContentContainer();
         this.dataStoreTreeList = new DevExpress.XtraTreeList.TreeList();
         this.snapshotsTabFormPage = new DevExpress.XtraBars.TabFormPage();
         this.snapshotTabFormContentContainer = new DevExpress.XtraBars.TabFormContentContainer();
         this.metadataItemTabFormPage = new DevExpress.XtraBars.TabFormPage();
         this.metadataItemTabFormContentContainer = new DevExpress.XtraBars.TabFormContentContainer();
         this.gridControl1 = new DevExpress.XtraGrid.GridControl();
         this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gridControl2 = new DevExpress.XtraGrid.GridControl();
         this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
         ((System.ComponentModel.ISupportInitialize)(this.tabFormControl1)).BeginInit();
         this.dataStoreTabFormContentContainer.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataStoreTreeList)).BeginInit();
         this.snapshotTabFormContentContainer.SuspendLayout();
         this.metadataItemTabFormContentContainer.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
         this.SuspendLayout();
         // 
         // tabFormControl1
         // 
         this.tabFormControl1.Location = new System.Drawing.Point(0, 0);
         this.tabFormControl1.Name = "tabFormControl1";
         this.tabFormControl1.Pages.Add(this.dataStoreTabFormPage);
         this.tabFormControl1.Pages.Add(this.snapshotsTabFormPage);
         this.tabFormControl1.Pages.Add(this.metadataItemTabFormPage);
         this.tabFormControl1.SelectedPage = this.snapshotsTabFormPage;
         this.tabFormControl1.ShowAddPageButton = false;
         this.tabFormControl1.ShowTabCloseButtons = false;
         this.tabFormControl1.Size = new System.Drawing.Size(809, 50);
         this.tabFormControl1.TabForm = this;
         this.tabFormControl1.TabIndex = 0;
         this.tabFormControl1.TabStop = false;
         // 
         // dataStoreTabFormPage
         // 
         this.dataStoreTabFormPage.ContentContainer = this.dataStoreTabFormContentContainer;
         this.dataStoreTabFormPage.Name = "dataStoreTabFormPage";
         this.dataStoreTabFormPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
         this.dataStoreTabFormPage.Text = "DataStore";
         // 
         // dataStoreTabFormContentContainer
         // 
         this.dataStoreTabFormContentContainer.Controls.Add(this.dataStoreTreeList);
         this.dataStoreTabFormContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataStoreTabFormContentContainer.Location = new System.Drawing.Point(0, 50);
         this.dataStoreTabFormContentContainer.Name = "dataStoreTabFormContentContainer";
         this.dataStoreTabFormContentContainer.Size = new System.Drawing.Size(809, 517);
         this.dataStoreTabFormContentContainer.TabIndex = 1;
         // 
         // dataStoreTreeList
         // 
         this.dataStoreTreeList.DataSource = null;
         this.dataStoreTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataStoreTreeList.Location = new System.Drawing.Point(0, 0);
         this.dataStoreTreeList.Name = "dataStoreTreeList";
         this.dataStoreTreeList.OptionsFind.AlwaysVisible = true;
         this.dataStoreTreeList.OptionsMenu.ShowConditionalFormattingItem = true;
         this.dataStoreTreeList.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
         this.dataStoreTreeList.OptionsView.ShowAutoFilterRow = true;
         this.dataStoreTreeList.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.ShowAlways;
         this.dataStoreTreeList.OptionsView.ShowSummaryFooter = true;
         this.dataStoreTreeList.Size = new System.Drawing.Size(809, 517);
         this.dataStoreTreeList.TabIndex = 0;
         // 
         // snapshotsTabFormPage
         // 
         this.snapshotsTabFormPage.ContentContainer = this.snapshotTabFormContentContainer;
         this.snapshotsTabFormPage.Name = "snapshotsTabFormPage";
         this.snapshotsTabFormPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
         this.snapshotsTabFormPage.Text = "Snapshots";
         // 
         // snapshotTabFormContentContainer
         // 
         this.snapshotTabFormContentContainer.Controls.Add(this.gridControl2);
         this.snapshotTabFormContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.snapshotTabFormContentContainer.Location = new System.Drawing.Point(0, 50);
         this.snapshotTabFormContentContainer.Name = "snapshotTabFormContentContainer";
         this.snapshotTabFormContentContainer.Size = new System.Drawing.Size(809, 517);
         this.snapshotTabFormContentContainer.TabIndex = 2;
         // 
         // metadataItemTabFormPage
         // 
         this.metadataItemTabFormPage.ContentContainer = this.metadataItemTabFormContentContainer;
         this.metadataItemTabFormPage.Name = "metadataItemTabFormPage";
         this.metadataItemTabFormPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
         this.metadataItemTabFormPage.Text = "MetadataItem";
         // 
         // metadataItemTabFormContentContainer
         // 
         this.metadataItemTabFormContentContainer.Controls.Add(this.gridControl1);
         this.metadataItemTabFormContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.metadataItemTabFormContentContainer.Location = new System.Drawing.Point(0, 50);
         this.metadataItemTabFormContentContainer.Name = "metadataItemTabFormContentContainer";
         this.metadataItemTabFormContentContainer.Size = new System.Drawing.Size(809, 517);
         this.metadataItemTabFormContentContainer.TabIndex = 2;
         // 
         // gridControl1
         // 
         this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.gridControl1.Location = new System.Drawing.Point(0, 0);
         this.gridControl1.MainView = this.gridView1;
         this.gridControl1.Name = "gridControl1";
         this.gridControl1.Size = new System.Drawing.Size(809, 517);
         this.gridControl1.TabIndex = 0;
         this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
         // 
         // gridView1
         // 
         this.gridView1.GridControl = this.gridControl1;
         this.gridView1.Name = "gridView1";
         // 
         // gridControl2
         // 
         this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.gridControl2.Location = new System.Drawing.Point(0, 0);
         this.gridControl2.MainView = this.gridView2;
         this.gridControl2.Name = "gridControl2";
         this.gridControl2.Size = new System.Drawing.Size(809, 517);
         this.gridControl2.TabIndex = 0;
         this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
         // 
         // gridView2
         // 
         this.gridView2.GridControl = this.gridControl2;
         this.gridView2.Name = "gridView2";
         // 
         // XtraForm2
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(809, 567);
         this.Controls.Add(this.snapshotTabFormContentContainer);
         this.Controls.Add(this.tabFormControl1);
         this.Name = "XtraForm2";
         this.TabFormControl = this.tabFormControl1;
         this.Text = "XtraForm2";
         ((System.ComponentModel.ISupportInitialize)(this.tabFormControl1)).EndInit();
         this.dataStoreTabFormContentContainer.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataStoreTreeList)).EndInit();
         this.snapshotTabFormContentContainer.ResumeLayout(false);
         this.metadataItemTabFormContentContainer.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraBars.TabFormControl tabFormControl1;
      private DevExpress.XtraBars.TabFormPage dataStoreTabFormPage;
      private DevExpress.XtraBars.TabFormContentContainer dataStoreTabFormContentContainer;
      private DevExpress.XtraBars.TabFormPage metadataItemTabFormPage;
      private DevExpress.XtraBars.TabFormContentContainer metadataItemTabFormContentContainer;
      private DevExpress.XtraTreeList.TreeList dataStoreTreeList;
      private DevExpress.XtraGrid.GridControl gridControl1;
      private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
      private DevExpress.XtraBars.TabFormPage snapshotsTabFormPage;
      private DevExpress.XtraBars.TabFormContentContainer snapshotTabFormContentContainer;
      private DevExpress.XtraGrid.GridControl gridControl2;
      private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
   }
}