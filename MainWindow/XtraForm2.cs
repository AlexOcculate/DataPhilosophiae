using DataPhilosophiae.DataModel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList.StyleFormatConditions;
using System;
using System.ComponentModel;
using System.Linq;

namespace DataPhilosophiae
{
   public partial class XtraForm2 : DevExpress.XtraBars.TabForm
   {
      private BindingList<DataStore> list;

      public XtraForm2() : this( null )
      {
      }

      public XtraForm2( BindingList<DataStore> list )
      {
         this.list = list;
         InitializeComponent( );
         {
            this.dataStoreTreeList.OptionsView.ShowSummaryFooter = true;
            this.dataStoreTreeList.OptionsMenu.ShowConditionalFormattingItem = true;
            this.dataStoreTreeList.OptionsFind.AlwaysVisible = true;
            this.dataStoreTreeList.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.dataStoreTreeList.OptionsView.ShowAutoFilterRow = true;
            this.dataStoreTreeList.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.ShowAlways;
         }
         //
         this.dataStoreTreeList.DataSource = this.list;
         //
         //MainWindow.CustomersList customersList = new MainWindow.CustomersList( );
         //customersList.LoadCustomers( );
         //this.gridControl1.DataSource = customersList;
         //
         //MainWindow.MyVirtualTables o = new MainWindow.MyVirtualTables( );
         //o.MakeDataTables( );
         //System.Data.DataTable dataTable = o.dataSet.Tables[ "ParentTable" ];
         //this.gridControl1.DataSource = dataTable;
         //
         //MainWindow.MyVirtualTables o = new MainWindow.MyVirtualTables( );
         //System.Data.DataSet x = o.x( );
         //System.Data.DataTable dataTable = x.Tables[ "DSSS_01" ];
         //this.gridControl1.DataSource = dataTable;
         //
         MainWindow.MyVirtualTables o = new MainWindow.MyVirtualTables( );
         System.Data.DataSet x = o.x( );
         this.gridControl1.DataSource = o.dv;
         //
         this.gridControl1.RefreshDataSource( );
         //
         {
            this.dataStoreTreeList.Columns[ "ValidStagePathDir" ].Visible = false;
            this.dataStoreTreeList.Columns[ "ValidProviderName" ].Visible = false;
            this.dataStoreTreeList.Columns[ "ProviderName" ].Visible = false;
         }
         {
            TreeListFormatRule fr = new TreeListFormatRule( );
            FormatConditionRuleDataBar fcrDataBar = new FormatConditionRuleDataBar( );
            fr.Column = this.dataStoreTreeList.Columns[ "AqbCounter" ];
            fcrDataBar.PredefinedName = "Orange Bar";
            fr.Rule = fcrDataBar;
            this.dataStoreTreeList.FormatRules.Add( fr );
         }
         {
            TreeListFormatRule fr = new TreeListFormatRule( );
            FormatConditionRuleDataBar fcrDataBar = new FormatConditionRuleDataBar( );
            fr.Column = this.dataStoreTreeList.Columns[ "MdiCounter" ];
            fcrDataBar.PredefinedName = "Blue Bar";
            fr.Rule = fcrDataBar;
            this.dataStoreTreeList.FormatRules.Add( fr );
         }
         {
            TreeListFormatRule fr = new TreeListFormatRule( );
            FormatConditionRuleExpression fcrExpression = new FormatConditionRuleExpression( );
            fr.Column = this.dataStoreTreeList.Columns[ "StagePathDir" ];
            fr.ApplyToRow = false;
            fcrExpression.PredefinedName = "Red Fill, Red Text";
            fcrExpression.Expression = "![ValidStagePathDir]";
            fr.Rule = fcrExpression;
            this.dataStoreTreeList.FormatRules.Add( fr );
         }
         {
            TreeListFormatRule fr = new TreeListFormatRule( );
            FormatConditionRuleExpression fcrExpression = new FormatConditionRuleExpression( );
            fr.Column = this.dataStoreTreeList.Columns[ "ConnectionStringName" ];
            fr.ApplyToRow = false;
            fcrExpression.PredefinedName = "Red Fill, Red Text";
            fcrExpression.Expression = "![ValidProviderName]";
            fr.Rule = fcrExpression;
            this.dataStoreTreeList.FormatRules.Add( fr );
         }
      }
   }
}
