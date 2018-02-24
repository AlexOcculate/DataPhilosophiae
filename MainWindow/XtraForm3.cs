namespace DataPhilosophiae
{
   public partial class XtraForm3 : DevExpress.XtraBars.TabForm
   {
      public XtraForm3()
      {
         InitializeComponent( );
      }
      public XtraForm3( System.Data.DataSet ds )
      {
         InitializeComponent( );
         {
            this.dataStoreGridView.OptionsFind.AlwaysVisible = true;
            this.dataStoreGridView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.dataStoreGridView.OptionsMenu.ShowFooterItem = true;
            this.dataStoreGridView.OptionsMenu.ShowConditionalFormattingItem = true;
            this.dataStoreGridView.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.dataStoreGridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.dataStoreGridView.OptionsView.ShowAutoFilterRow = true;
            this.dataStoreGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.dataStoreGridView.OptionsView.ShowFooter = true;
         }
         {
            this.dataStoreGridControl.DataSource = ds.Tables[ "DataStore" ];
            {
               this.dataStoreGridView.Columns[ Program.IsValidStagePathDir_ColName ].Visible = false;
               this.dataStoreGridView.Columns[ Program.IsValidProviderName_ColName ].Visible = false;
               this.dataStoreGridView.Columns[ Program.ConnectionString_ColName ].Visible = false;
               this.dataStoreGridView.Columns[ Program.ProviderName_ColName ].Visible = false;
            }
            {
               DevExpress.XtraGrid.GridFormatRule fr = new DevExpress.XtraGrid.GridFormatRule( );
               DevExpress.XtraEditors.FormatConditionRuleExpression fcrExpression = new DevExpress.XtraEditors.FormatConditionRuleExpression( );
               fr.Column = this.dataStoreGridView.Columns[ Program.StagePathDir_ColName ];
               fr.ApplyToRow = false;
               fcrExpression.PredefinedName = "Red Fill, Red Text";
               fcrExpression.Expression = "![" + Program.IsValidStagePathDir_ColName + "]";
               fr.Rule = fcrExpression;
               this.dataStoreGridView.FormatRules.Add( fr );
            }
            {
               DevExpress.XtraGrid.GridFormatRule fr = new DevExpress.XtraGrid.GridFormatRule( );
               DevExpress.XtraEditors.FormatConditionRuleExpression fcrExpression = new DevExpress.XtraEditors.FormatConditionRuleExpression( );
               fr.Column = this.dataStoreGridView.Columns[ Program.ConnectionStringName_ColName ];
               fr.ApplyToRow = false;
               fcrExpression.PredefinedName = "Red Fill, Red Text";
               fcrExpression.Expression = "![" + Program.IsValidProviderName_ColName + "]"; ;
               fr.Rule = fcrExpression;
               this.dataStoreGridView.FormatRules.Add( fr );
            }
            this.dataStoreGridControl.RefreshDataSource( );
         }
         {
            this.dataStoreSnapshotGridControl.DataSource = ds.Tables[ "DataStoreSnapshot" ];
            {
               DevExpress.XtraGrid.Columns.GridColumn colSalesDate = this.dataStoreSnapshotGridView.Columns[ "LastWriteTimeUtc" ];
               colSalesDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
               colSalesDate.DisplayFormat.FormatString = "u";
            }
            {
               this.dataStoreSnapshotGridView.BeginDataUpdate( );
               try
               {
                  DevExpress.XtraGrid.Columns.GridColumnSortInfo[ ] sortInfo = {
                    new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.dataStoreSnapshotGridView.Columns["Name"], DevExpress.Data.ColumnSortOrder.Ascending),
                    new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.dataStoreSnapshotGridView.Columns["IsActive"], DevExpress.Data.ColumnSortOrder.Descending),
                    new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.dataStoreSnapshotGridView.Columns["LastWriteTimeUtc"], DevExpress.Data.ColumnSortOrder.Ascending)
                  };
                  this.dataStoreSnapshotGridView.SortInfo.ClearAndAddRange( sortInfo, 1 );
               }
               finally
               {
                  this.dataStoreSnapshotGridView.EndDataUpdate( );
               }
            }
            this.dataStoreSnapshotGridControl.RefreshDataSource( );
         }
      }
   }
}