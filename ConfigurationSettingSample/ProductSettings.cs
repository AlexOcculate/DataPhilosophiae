namespace ConfigurationSetting
{
   public class ProductSettings : System.Configuration.ConfigurationSection
   {
      [System.Configuration.ConfigurationProperty( "DellSettings" )]
      public DellFeatures DellFeatures
      {
         get
         {
            return (DellFeatures) this[ "DellSettings" ];
         }
      }
   }
}
