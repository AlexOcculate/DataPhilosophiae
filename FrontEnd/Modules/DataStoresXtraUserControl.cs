using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FrontEnd
{
   public partial class DataStoresXtraUserControl : DevExpress.XtraEditors.XtraUserControl
   {
      public DataStoresXtraUserControl()
      {
         this.InitializeComponent( );
         InitTreeView( this.treeView );
         this.treeView.CustomDrawNodeCell += this.treeView_CustomDrawNodeCell;
         this.treeView.AfterCollapse += this.treeView_AfterCollapse;
         this.treeView.AfterExpand += this.treeView_AfterExpand;
         this.AddAllNodes( true );
      }
      public static void InitTreeView( DevExpress.XtraTreeList.TreeList treeView )
      {
         TreeListColumn column = treeView.Columns.Add( );
         column.Visible = true;
         treeView.OptionsView.ShowColumns = false;
         treeView.OptionsView.ShowIndicator = false;
         treeView.OptionsView.ShowVertLines = false;
         treeView.OptionsView.ShowHorzLines = false;
         treeView.OptionsBehavior.Editable = false;
         treeView.OptionsSelection.EnableAppearanceFocusedCell = false;
      }
      private void treeView_CustomDrawNodeCell( object sender, CustomDrawNodeCellEventArgs e )
      {
         if( e.Node.Id == 1 )
         {
            e.Appearance.Font = new System.Drawing.Font( e.Appearance.Font, FontStyle.Bold );
         }
      }
      private void treeView_AfterCollapse( object sender, DevExpress.XtraTreeList.NodeEventArgs e )
      {
         this.SetIndex( e.Node, 6, false );
         this.SetIndex( e.Node, 8, false );
      }
      private void treeView_AfterExpand( object sender, DevExpress.XtraTreeList.NodeEventArgs e )
      {
         this.SetIndex( e.Node, 7, true );
         this.SetIndex( e.Node, 9, true );
      }
      private void AddAllNodes( bool showAll )
      {
         this.treeView.Nodes.Clear( );
         this.treeView.AppendNode( new object[ ] { "Solution \'VisualStudioInspiredUIDemo\' (1 project)" }, -1, -1, -1, 3 ); //0
         this.treeView.AppendNode( new object[ ] { "VisualStudioInspiredUIDemo" }, -1, -1, -1, 4 );//1
         this.treeView.AppendNode( new object[ ] { "Properties" }, 1, -1, -1, 2 );//2
         this.treeView.AppendNode( new object[ ] { "References" }, 1, -1, -1, 5 );//3
         this.treeView.AppendNode( new object[ ] { "System" }, 3, -1, -1, 5 );
         this.treeView.AppendNode( new object[ ] { "System.Drawing" }, 3, -1, -1, 5 );
         this.treeView.AppendNode( new object[ ] { "System.Windows.Forms" }, 3, -1, -1, 5 );
         this.treeView.AppendNode( new object[ ] { "DevExpress.Utils" }, 3, -1, -1, 5 );
         this.treeView.AppendNode( new object[ ] { "DevExpress.XtraBars" }, 3, -1, -1, 5 );
         this.treeView.AppendNode( new object[ ] { "DevExpress.XtraEditors" }, 3, -1, -1, 5 );
         if( showAll )
         {
            this.treeView.AppendNode( new object[ ] { "bin" }, 1, -1, -1, 9 ); //10
            this.treeView.AppendNode( new object[ ] { "Debug" }, 10, -1, -1, 9 );
            this.treeView.AppendNode( new object[ ] { "Release" }, 10, -1, -1, 9 );
            this.treeView.AppendNode( new object[ ] { "obj" }, 1, -1, -1, 9 );//13
            this.treeView.AppendNode( new object[ ] { "Debug" }, 13, -1, -1, 9 );
            this.treeView.AppendNode( new object[ ] { "Release" }, 13, -1, -1, 9 );
         }
         this.treeView.AppendNode( new object[ ] { "Modules" }, 1, -1, -1, 7 );//16/10
         this.treeView.AppendNode( new object[ ] { "Resources" }, 1, -1, -1, 7 );//17
         this.treeView.AppendNode( new object[ ] { "AssemblyInfo.cs" }, 2, -1, -1, 10 );
         this.treeView.AppendNode( new object[ ] { "frmMain.cs" }, 1, -1, -1, 11 );//19
         this.treeView.AppendNode( new object[ ] { "ucCodeEditor.cs" }, showAll ? 16 : 10, -1, -1, 12 ); //20
         this.treeView.AppendNode( new object[ ] { "ucSolutionExplorer.cs" }, showAll ? 16 : 10, -1, -1, 12 ); //21
         this.treeView.AppendNode( new object[ ] { "ucToolbox.cs" }, showAll ? 16 : 10, -1, -1, 12 ); //22
         if( showAll )
         {
            this.treeView.AppendNode( new object[ ] { "frmMain.resx" }, 19, -1, -1, 13 );
            this.treeView.AppendNode( new object[ ] { "ucCodeEditor.resx" }, 20, -1, -1, 13 );
            this.treeView.AppendNode( new object[ ] { "ucSolutionExplorer.resx" }, 21, -1, -1, 13 );
            this.treeView.AppendNode( new object[ ] { "ucToolbox.resx" }, 22, -1, -1, 13 );
         }
         this.treeView.ExpandAll( );
      }
      private void SetIndex( TreeListNode node, int index, bool expand )
      {
         int newIndex = expand ? index - 1 : index + 1;
         if( node.StateImageIndex == index )
         {
            node.StateImageIndex = newIndex;
         }
      }
      //
      private void iShow_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.AddAllNodes( ((DevExpress.XtraBars.BarButtonItem) e.Item).Down );
      }
      //
      public event EventHandler PropertiesItemClick;
      private void iProperties_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         if( this.PropertiesItemClick != null )
         {
            this.PropertiesItemClick( sender, EventArgs.Empty );
         }
      }
      //
      public event EventHandler TreeViewItemClick;
      private void treeView_MouseDoubleClick( object sender, MouseEventArgs e )
      {
         if( this.TreeViewItemClick != null )
         {
            this.TreeViewItemClick( sender, EventArgs.Empty );
         }
      }
   }
}
