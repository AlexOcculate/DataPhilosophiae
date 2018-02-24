namespace ConfigurationSetting
{
   public class ConfigurationClassLoader : System.Configuration.ConfigurationSection
   {
      [System.Configuration.ConfigurationProperty( "Plugins", IsDefaultCollection = true, IsKey = false, IsRequired = true )]
      public PluginsCollection Plugins
      {
         get { return ((PluginsCollection) (base[ "Plugins" ])); }
      }
   }
}

// ConfigurationSetting.ConfigurationClassLoader 