namespace ConfigurationSetting
{
   [System.Configuration.ConfigurationCollection( typeof( PluginElement ) )]
   public class PluginsCollection : System.Configuration.ConfigurationElementCollection
   {
      protected override System.Configuration.ConfigurationElement CreateNewElement()
      {
         return new PluginElement( );
      }

      protected override object GetElementKey( System.Configuration.ConfigurationElement element )
      {
         return ((PluginElement) (element)).PluginType;
      }

      protected override string ElementName
      {
         get
         {
            return "Plugin";
         }
      }
      protected override bool IsElementName( string elementName )
      {
         return !string.IsNullOrEmpty( elementName ) && elementName == "Plugin";
      }
      public override System.Configuration.ConfigurationElementCollectionType CollectionType
      {
         get
         {
            return System.Configuration.ConfigurationElementCollectionType.BasicMap;
         }
      }
      public PluginElement this[ int idx ]
      {
         get { return (PluginElement) BaseGet( idx ); }
      }
      public new PluginElement this[ string key ]
      {
         get
         {
            return base.BaseGet( key ) as PluginElement;
         }
      }
   }
}
