using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent( );
         this.Icon = DevExpress.Utils.ResourceImageHelper.CreateIconFromResourcesEx( "FrontEnd.Resources.AppIcon.ico", typeof( Form1 ).Assembly );
         // Handling the QueryControl event that will populate all automatically generated Documents
         this.tabbedView1.QueryControl += this.tabbedView1_QueryControl;
         this.dataStoresXtraUserControl1.PropertiesItemClick += this.DataStoresXtraUserControl1_PropertiesItemClick;
         this.dataStoresXtraUserControl1.TreeViewItemClick += this.DataStoresXtraUserControl1_TreeViewItemClick;
      }

      private void DataStoresXtraUserControl1_TreeViewItemClick( object sender, EventArgs e )
      {
         throw new NotImplementedException( );
      }

      private void DataStoresXtraUserControl1_PropertiesItemClick( object sender, EventArgs e )
      {
         throw new NotImplementedException( );
      }

      private void Form1_Load( object sender, EventArgs e )
      {
         BeginInvoke( new MethodInvoker( this.InitDemo ) );
      }
      private void InitDemo()
      {
         DevExpress.XtraSplashScreen.SplashScreenManager.HideImage( 1000, this );
      }

      // Assigning a required content for each auto generated Document
      private void tabbedView1_QueryControl( object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e )
      {
         if( e.Document == this.xtraUserControl1Document )
            e.Control = new FrontEnd.XtraUserControl1( );
         if( e.Document == this.xtraUserControl2Document )
            e.Control = new FrontEnd.XtraUserControl2( );
         if( e.Control == null )
            e.Control = new System.Windows.Forms.Control( );
      }

   }
}
