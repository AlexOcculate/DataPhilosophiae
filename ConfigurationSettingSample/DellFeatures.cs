namespace ConfigurationSetting
{
   public class DellFeatures : System.Configuration.ConfigurationElement
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

      [System.Configuration.ConfigurationProperty( "Color", IsRequired = false )]
      public string Color
      {
         get
         {
            return (string) this[ "Color" ];
         }
      }
      [System.Configuration.ConfigurationProperty( "Warranty", DefaultValue = "1 Years", IsRequired = false )]
      public string Warranty
      {
         get
         {
            return (string) this[ "Warranty" ];
         }
      }
   }
}
