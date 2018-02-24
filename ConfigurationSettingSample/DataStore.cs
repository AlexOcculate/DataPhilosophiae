namespace ConfigurationSetting
{
   public class DataStore : System.Configuration.ConfigurationSection
   {
      [System.Configuration.ConfigurationProperty( "ProductNumber", DefaultValue = 00000, IsRequired = true )]
      public int ProductNumber
      {
         get
         {
            return (int) this[ "ProductNumber" ];
         }
      }

      [System.Configuration.ConfigurationProperty( "ProductName", DefaultValue = "DELL", IsRequired = true )]
      public string ProductName
      {
         get
         {
            return (string) this[ "ProductName" ];
         }
      }
   }
}
