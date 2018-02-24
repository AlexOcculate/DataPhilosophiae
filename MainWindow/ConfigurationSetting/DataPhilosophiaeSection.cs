//using System.Configuration;

namespace DataPhilosophiae.ConfigurationSetting
{
   public class DataPhilosophiaeSection : System.Configuration.ConfigurationSection
   {
      [System.Configuration.ConfigurationProperty( "Stage", IsRequired = true )]
      public DataStage Stage
      {
         get { return (DataStage) this[ "Stage" ]; }
         set { this[ "Stage" ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "", IsDefaultCollection = true )]
      public DataStoreCollection DataStores
      {
         get
         {
            DataStoreCollection dsCollection = (DataStoreCollection) base[ "" ];
            return dsCollection;
         }
      }
   }

   public class DataStage : System.Configuration.ConfigurationElement
   {
      [System.Configuration.ConfigurationProperty( "PathDir", IsRequired = true )]
      [System.Configuration.StringValidator( InvalidCharacters = "*?\"<>|" )]
      public string PathDir
      {
         get { return (string) this[ "PathDir" ]; }
         set { this[ "PathDir" ] = value; }
      }
   }

   public class DataStoreCollection : System.Configuration.ConfigurationElementCollection
   {
      public DataStoreCollection()
      {
         DataStoreElement details = (DataStoreElement) CreateNewElement( );
         if( details.Name != "" )
         {
            Add( details );
         }
      }

      public override System.Configuration.ConfigurationElementCollectionType CollectionType
      {
         get
         {
            return System.Configuration.ConfigurationElementCollectionType.BasicMap;
         }
      }

      protected override System.Configuration.ConfigurationElement CreateNewElement()
      {
         return new DataStoreElement( );
      }

      protected override System.Object GetElementKey( System.Configuration.ConfigurationElement element )
      {
         return ((DataStoreElement) element).Name;
      }

      public DataStoreElement this[ int index ]
      {
         get
         {
            return (DataStoreElement) BaseGet( index );
         }
         set
         {
            if( BaseGet( index ) != null )
            {
               BaseRemoveAt( index );
            }
            BaseAdd( index, value );
         }
      }

      new public DataStoreElement this[ string name ]
      {
         get
         {
            return (DataStoreElement) BaseGet( name );
         }
      }

      public int IndexOf( DataStoreElement details )
      {
         return BaseIndexOf( details );
      }

      public void Add( DataStoreElement details )
      {
         BaseAdd( details );
      }
      protected override void BaseAdd( System.Configuration.ConfigurationElement element )
      {
         BaseAdd( element, false );
      }

      public void Remove( DataStoreElement details )
      {
         if( BaseIndexOf( details ) >= 0 )
            BaseRemove( details.Name );
      }

      public void RemoveAt( int index )
      {
         BaseRemoveAt( index );
      }

      public void Remove( string name )
      {
         BaseRemove( name );
      }

      public void Clear()
      {
         BaseClear( );
      }

      protected override string ElementName
      {
         get { return "datastore"; }
      }
   }

   public class DataStoreElement : System.Configuration.ConfigurationElement
   {
      [System.Configuration.ConfigurationProperty( "Name", IsRequired = true, IsKey = true )]
      [System.Configuration.StringValidator( InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\" )]
      public string Name
      {
         get { return (string) this[ "Name" ]; }
         set { this[ "Name" ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "csName", IsRequired = true )]
      [System.Configuration.StringValidator( InvalidCharacters = "*?\"<>|" )]
      public string ConnectionStringName
      {
         get { return (string) this[ "csName" ]; }
         set { this[ "csName" ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "LoadDefaultDatabaseOnly", IsRequired = false, DefaultValue = 0 )]
      [System.Configuration.IntegerValidator( MinValue = 0, MaxValue = 1 )]
      public int LoadDefaultDatabaseOnly
      {
         get { return (int) this[ "LoadDefaultDatabaseOnly" ]; }
         set { this[ "LoadDefaultDatabaseOnly" ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "LoadSystemObjects", IsRequired = false, DefaultValue = 0 )]
      [System.Configuration.IntegerValidator( MinValue = 0, MaxValue = 1 )]
      public int LoadSystemObjects
      {
         get { return (int) this[ "LoadSystemObjects" ]; }
         set { this[ "LoadSystemObjects" ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "WithFields", IsRequired = false, DefaultValue = 0 )]
      [System.Configuration.IntegerValidator( MinValue = 0, MaxValue = 1 )]
      public int WithFields
      {
         get { return (int) this[ "WithFields" ]; }
         set { this[ "WithFields" ] = value; }
      }

      [System.Configuration.ConfigurationProperty( "PathDir", IsRequired = false )]
      [System.Configuration.StringValidator( InvalidCharacters = "*?\"<>|" )]
      public string PathDir
      {
         get { return (string) this[ "PathDir" ]; }
         set { this[ "PathDir" ] = value; }
      }
   }
}
