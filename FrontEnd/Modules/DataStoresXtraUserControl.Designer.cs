namespace FrontEnd
{
   public partial class DataStoresXtraUserControl
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
         if( disposing && (this.components != null) )
         {
            this.components.Dispose( );
         }
         base.Dispose( disposing );
      }

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container( );
         this.barManager = new DevExpress.XtraBars.BarManager( this.components );
         this.bar1 = new DevExpress.XtraBars.Bar( );
         this.iRefresh = new DevExpress.XtraBars.BarButtonItem( );
         this.iShow = new DevExpress.XtraBars.BarButtonItem( );
         this.iProperties = new DevExpress.XtraBars.BarButtonItem( );
         this.barAndDockingController = new DevExpress.XtraBars.BarAndDockingController( this.components );
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl( );
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl( );
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl( );
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl( );
         this.treeView = new DevExpress.XtraTreeList.TreeList( );
         this.svgImageCollection = new DevExpress.Utils.SvgImageCollection( this.components );
         ((System.ComponentModel.ISupportInitialize) (this.barManager)).BeginInit( );
         ((System.ComponentModel.ISupportInitialize) (this.barAndDockingController)).BeginInit( );
         ((System.ComponentModel.ISupportInitialize) (this.treeView)).BeginInit( );
         ((System.ComponentModel.ISupportInitialize) (this.svgImageCollection)).BeginInit( );
         this.SuspendLayout( );
         // 
         // barManager
         // 
         this.barManager.Bars.AddRange( new DevExpress.XtraBars.Bar[ ] {
            this.bar1} );
         this.barManager.Controller = this.barAndDockingController;
         this.barManager.DockControls.Add( this.barDockControlTop );
         this.barManager.DockControls.Add( this.barDockControlBottom );
         this.barManager.DockControls.Add( this.barDockControlLeft );
         this.barManager.DockControls.Add( this.barDockControlRight );
         this.barManager.Form = this;
         this.barManager.Images = this.svgImageCollection;
         this.barManager.Items.AddRange( new DevExpress.XtraBars.BarItem[ ] {
            this.iRefresh,
            this.iShow,
            this.iProperties} );
         this.barManager.MaxItemId = 3;
         // 
         // bar1
         // 
         this.bar1.BarName = "Explorer";
         this.bar1.DockCol = 0;
         this.bar1.DockRow = 0;
         this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.bar1.LinksPersistInfo.AddRange( new DevExpress.XtraBars.LinkPersistInfo[ ] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.iShow, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iProperties, true)} );
         this.bar1.OptionsBar.AllowQuickCustomization = false;
         this.bar1.OptionsBar.DrawDragBorder = false;
         this.bar1.OptionsBar.RotateWhenVertical = false;
         this.bar1.OptionsBar.UseWholeRow = true;
         this.bar1.Text = "Explorer";
         // 
         // iRefresh
         // 
         this.iRefresh.Caption = "Refresh";
         this.iRefresh.Hint = "Refresh";
         this.iRefresh.Id = 0;
         this.iRefresh.ImageOptions.ImageIndex = 0;
         this.iRefresh.Name = "iRefresh";
         // 
         // iShow
         // 
         this.iShow.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
         this.iShow.Caption = "Show All Files";
         this.iShow.Hint = "Show All Files";
         this.iShow.Id = 1;
         this.iShow.ImageOptions.ImageIndex = 1;
         this.iShow.Name = "iShow";
         this.iShow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler( this.iShow_ItemClick );
         // 
         // iProperties
         // 
         this.iProperties.Caption = "Properties";
         this.iProperties.Hint = "Properties";
         this.iProperties.Id = 2;
         this.iProperties.ImageOptions.ImageIndex = 2;
         this.iProperties.Name = "iProperties";
         this.iProperties.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler( this.iProperties_ItemClick );
         // 
         // barAndDockingController
         // 
         this.barAndDockingController.PropertiesBar.AllowLinkLighting = false;
         this.barAndDockingController.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size( 16, 16 );
         this.barAndDockingController.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size( 32, 32 );
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point( 0, 0 );
         this.barDockControlTop.Manager = this.barManager;
         this.barDockControlTop.Size = new System.Drawing.Size( 362, 29 );
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point( 0, 468 );
         this.barDockControlBottom.Manager = this.barManager;
         this.barDockControlBottom.Size = new System.Drawing.Size( 362, 0 );
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point( 0, 29 );
         this.barDockControlLeft.Manager = this.barManager;
         this.barDockControlLeft.Size = new System.Drawing.Size( 0, 439 );
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point( 362, 29 );
         this.barDockControlRight.Manager = this.barManager;
         this.barDockControlRight.Size = new System.Drawing.Size( 0, 439 );
         // 
         // treeView
         // 
         this.treeView.DataSource = null;
         this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.treeView.Location = new System.Drawing.Point( 0, 29 );
         this.treeView.Name = "treeView";
         this.treeView.Size = new System.Drawing.Size( 362, 439 );
         this.treeView.StateImageList = this.svgImageCollection;
         this.treeView.TabIndex = 4;
         this.treeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler( this.treeView_MouseDoubleClick );
         // 
         // svgImageCollection1
         // 
         this.svgImageCollection.Add( "refresh", "image://devav/actions/refresh.svg" );
         this.svgImageCollection.Add( "show", "image://devav/actions/show.svg" );
         this.svgImageCollection.Add( "viewsetting", "image://devav/actions/viewsetting.svg" );
         this.svgImageCollection.Add( "showproduct", "image://devav/actions/showproduct.svg" );
         this.svgImageCollection.Add( "driving", "image://devav/actions/driving.svg" );
         this.svgImageCollection.Add( "add", "image://devav/actions/add.svg" );
         this.svgImageCollection.Add( "picture", "image://devav/actions/picture.svg" );
         this.svgImageCollection.Add( "remove", "image://devav/actions/remove.svg" );
         this.svgImageCollection.Add( "newsales", "image://devav/actions/newsales.svg" );
         this.svgImageCollection.Add( "clearformat", "image://devav/actions/clearformat.svg" );
         this.svgImageCollection.Add( "addcolumn", "image://devav/actions/addcolumn.svg" );
         this.svgImageCollection.Add( "productshipments", "image://devav/actions/productshipments.svg" );
         this.svgImageCollection.Add( "edit", "image://devav/actions/edit.svg" );
         this.svgImageCollection.Add( "mapit", "image://devav/actions/mapit.svg" );
         // 
         // DataStoresXtraUserControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add( this.treeView );
         this.Controls.Add( this.barDockControlLeft );
         this.Controls.Add( this.barDockControlRight );
         this.Controls.Add( this.barDockControlBottom );
         this.Controls.Add( this.barDockControlTop );
         this.Name = "DataStoresXtraUserControl";
         this.Size = new System.Drawing.Size( 362, 468 );
         ((System.ComponentModel.ISupportInitialize) (this.barManager)).EndInit( );
         ((System.ComponentModel.ISupportInitialize) (this.barAndDockingController)).EndInit( );
         ((System.ComponentModel.ISupportInitialize) (this.treeView)).EndInit( );
         ((System.ComponentModel.ISupportInitialize) (this.svgImageCollection)).EndInit( );
         this.ResumeLayout( false );
         this.PerformLayout( );

      }

      #endregion

      internal DevExpress.XtraBars.BarManager barManager;
      private DevExpress.XtraBars.Bar bar1;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraBars.BarButtonItem iRefresh;
      private DevExpress.XtraBars.BarButtonItem iShow;
      private DevExpress.XtraBars.BarButtonItem iProperties;
      private DevExpress.XtraTreeList.TreeList treeView;
      private DevExpress.XtraBars.BarAndDockingController barAndDockingController;
      private DevExpress.Utils.SvgImageCollection svgImageCollection;
   }
}
