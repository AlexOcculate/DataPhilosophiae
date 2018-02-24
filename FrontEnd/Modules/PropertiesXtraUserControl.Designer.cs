namespace FrontEnd
{
   public partial class PropertiesXtraUserControl
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
         this.comboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit( );
         this.propertyGridControl = new DevExpress.XtraVerticalGrid.PropertyGridControl( );
         this.propertyDescriptionControl = new DevExpress.XtraVerticalGrid.PropertyDescriptionControl( );
         ((System.ComponentModel.ISupportInitialize) (this.comboBoxEdit.Properties)).BeginInit( );
         ((System.ComponentModel.ISupportInitialize) (this.propertyGridControl)).BeginInit( );
         this.SuspendLayout( );
         // 
         // comboBoxEdit
         // 
         this.comboBoxEdit.Dock = System.Windows.Forms.DockStyle.Top;
         this.comboBoxEdit.Location = new System.Drawing.Point( 0, 0 );
         this.comboBoxEdit.Name = "comboBoxEdit";
         this.comboBoxEdit.Properties.Buttons.AddRange( new DevExpress.XtraEditors.Controls.EditorButton[ ] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)} );
         this.comboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
         this.comboBoxEdit.Size = new System.Drawing.Size( 475, 20 );
         this.comboBoxEdit.TabIndex = 0;
         this.comboBoxEdit.SelectedIndexChanged += new System.EventHandler( this.comboBox_SelectedIndexChanged );
         // 
         // propertyGridControl
         // 
         this.propertyGridControl.Anchor = ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
         this.propertyGridControl.FindPanelVisible = true;
         this.propertyGridControl.Location = new System.Drawing.Point( 3, 30 );
         this.propertyGridControl.Name = "propertyGridControl";
         this.propertyGridControl.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
         this.propertyGridControl.OptionsView.ShowFilterPanelMode = DevExpress.XtraVerticalGrid.ShowFilterPanelMode.ShowAlways;
         this.propertyGridControl.Size = new System.Drawing.Size( 469, 452 );
         this.propertyGridControl.TabIndex = 1;
         // 
         // propertyDescriptionControl1
         // 
         this.propertyDescriptionControl.Anchor = (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
         this.propertyDescriptionControl.Location = new System.Drawing.Point( 3, 488 );
         this.propertyDescriptionControl.Name = "propertyDescriptionControl1";
         this.propertyDescriptionControl.PropertyGrid = this.propertyGridControl;
         this.propertyDescriptionControl.Size = new System.Drawing.Size( 469, 100 );
         this.propertyDescriptionControl.TabIndex = 2;
         this.propertyDescriptionControl.TabStop = false;
         // 
         // PropertiesXtraUserControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add( this.propertyDescriptionControl );
         this.Controls.Add( this.propertyGridControl );
         this.Controls.Add( this.comboBoxEdit );
         this.Name = "PropertiesXtraUserControl";
         this.Size = new System.Drawing.Size( 475, 591 );
         ((System.ComponentModel.ISupportInitialize) (this.comboBoxEdit.Properties)).EndInit( );
         ((System.ComponentModel.ISupportInitialize) (this.propertyGridControl)).EndInit( );
         this.ResumeLayout( false );

      }

      #endregion

      private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit;
      private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl;
      private DevExpress.XtraVerticalGrid.PropertyDescriptionControl propertyDescriptionControl;
   }
}
