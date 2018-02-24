using System;

namespace MainWindow
{
   public class Customer : System.ComponentModel.IEditableObject
   {

      struct CustomerData
      {
         internal string id;
         internal string firstName;
         internal string lastName;
      }

      private CustomersList parent;
      private CustomerData custData;
      private CustomerData backupData;
      private bool inTxn = false;

      // Implements IEditableObject
      void System.ComponentModel.IEditableObject.BeginEdit()
      {
         Console.WriteLine( "Start BeginEdit" );
         if( !this.inTxn )
         {
            this.backupData = this.custData;
            this.inTxn = true;
            Console.WriteLine( "BeginEdit - " + this.backupData.lastName );
         }
         Console.WriteLine( "End BeginEdit" );
      }

      void System.ComponentModel.IEditableObject.CancelEdit()
      {
         Console.WriteLine( "Start CancelEdit" );
         if( this.inTxn )
         {
            this.custData = this.backupData;
            this.inTxn = false;
            Console.WriteLine( "CancelEdit - " + this.custData.lastName );
         }
         Console.WriteLine( "End CancelEdit" );
      }

      void System.ComponentModel.IEditableObject.EndEdit()
      {
         Console.WriteLine( "Start EndEdit" + this.custData.id + this.custData.lastName );
         if( this.inTxn )
         {
            this.backupData = new CustomerData( );
            this.inTxn = false;
            Console.WriteLine( "Done EndEdit - " + this.custData.id + this.custData.lastName );
         }
         Console.WriteLine( "End EndEdit" );
      }

      ////////////////////////////////////////////////////////////////

      public Customer( string ID ) : base( )
      {
         this.custData = new CustomerData( );
         this.custData.id = ID;
         this.custData.firstName = string.Empty;
         this.custData.lastName = string.Empty;
      }

      public string ID { get { return this.custData.id; } }

      public string FirstName
      {
         get { return this.custData.firstName; }
         set
         {
            this.custData.firstName = value;
            this.OnCustomerChanged( );
         }
      }

      public string LastName
      {
         get { return this.custData.lastName; }
         set
         {
            this.custData.lastName = value;
            this.OnCustomerChanged( );
         }
      }

      internal CustomersList Parent
      {
         get { return this.parent; }
         set { this.parent = value; }
      }

      private void OnCustomerChanged()
      {
         if( !this.inTxn && this.Parent != null )
         {
            this.Parent.CustomerChanged( this );
         }
      }

      public override string ToString()
      {
         System.IO.StringWriter sb = new System.IO.StringWriter( );
         sb.Write( this.FirstName );
         sb.Write( " " );
         sb.Write( this.LastName );
         return sb.ToString( );
      }
   }
}
