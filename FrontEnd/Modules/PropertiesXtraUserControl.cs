using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FrontEnd
{
   public partial class PropertiesXtraUserControl : DevExpress.XtraEditors.XtraUserControl
   {
      public PropertiesXtraUserControl()
      {
         this.InitializeComponent( );
         this.propertyGridControl.AutoGenerateRows = true;
         this.AddControls( this, this.comboBoxEdit );
         this.comboBoxEdit.SelectedIndex = 0;
      }
      private void comboBox_SelectedIndexChanged( object sender, System.EventArgs e )
      {
         this.propertyGridControl.SelectedObject = this.comboBoxEdit.SelectedItem;
      }
      private void AddControls( Control container, ComboBoxEdit cb )
      {
         foreach( object obj in container.Controls )
         {
            cb.Properties.Items.Add( obj );
            if( obj is Control )
            {
               this.AddControls( obj as Control, cb );
            }
         }
      }
   }
}
