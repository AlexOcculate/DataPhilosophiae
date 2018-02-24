namespace ConfigurationSetting
{
   public class PluginElement : System.Configuration.ConfigurationElement
   {
      [System.Configuration.ConfigurationProperty( "name" )]
      public string PluginType
      {
         get { return ((string) (base[ "name" ])); }
         set { base[ "name" ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "assembly" )]
      public string Priority
      {
         get { return ((string) (base[ "assembly" ])); }
         set { base[ "assembly" ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "class" )]
      public string XPriority
      {
         get { return ((string) (base[ "class" ])); }
         set { base[ "class" ] = value; }
      }
   }
}
