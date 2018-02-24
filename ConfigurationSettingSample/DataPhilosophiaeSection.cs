using System;
using System.Configuration;

namespace ConfigurationSetting
{
   public class DataPhilosophiaeSection : ConfigurationSection
   {
      [ConfigurationProperty( "Stage", IsRequired = true )]
      public DataStage Stage
      {
         get { return (DataStage) this[ "Stage" ]; }
         set { this[ "Stage" ] = value; }
      }

      [ConfigurationProperty( "", IsDefaultCollection = true )]
      public DataStoreCollection DataStores
      {
         get
         {
            DataStoreCollection dsCollection = (DataStoreCollection) base[ "" ];
            return dsCollection;
         }
      }
   }

   public class DataStage : ConfigurationElement
   {
      [ConfigurationProperty( "PathDir", IsRequired = true )]
      [StringValidator( InvalidCharacters = "*?\"<>|" )]
      public string PathDir
      {
         get { return (string) this[ "PathDir" ]; }
         set { this[ "PathDir" ] = value; }
      }
   }

   public class DataStoreCollection : ConfigurationElementCollection
   {
      public DataStoreCollection()
      {
         DataStoreElement details = (DataStoreElement) CreateNewElement( );
         if( details.Name != "" )
         {
            Add( details );
         }
      }

      public override ConfigurationElementCollectionType CollectionType
      {
         get
         {
            return ConfigurationElementCollectionType.BasicMap;
         }
      }

      protected override ConfigurationElement CreateNewElement()
      {
         return new DataStoreElement( );
      }

      protected override Object GetElementKey( ConfigurationElement element )
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
      protected override void BaseAdd( ConfigurationElement element )
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

   public class DataStoreElement : ConfigurationElement
   {
      [ConfigurationProperty( "Name", IsRequired = true, IsKey = true )]
      [StringValidator( InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\" )]
      public string Name
      {
         get { return (string) this[ "Name" ]; }
         set { this[ "Name" ] = value; }
      }

      [ConfigurationProperty( "csName", IsRequired = true )]
      [StringValidator( InvalidCharacters = "*?\"<>|" )]
      public string ConnectionStringName
      {
         get { return (string) this[ "csName" ]; }
         set { this[ "csName" ] = value; }
      }

      [ConfigurationProperty( "LoadDefaultDatabaseOnly", IsRequired = false, DefaultValue = 0 )]
      [IntegerValidator( MinValue = 0, MaxValue = 1 )]
      public int LoadDefaultDatabaseOnly
      {
         get { return (int) this[ "LoadDefaultDatabaseOnly" ]; }
         set { this[ "LoadDefaultDatabaseOnly" ] = value; }
      }

      [ConfigurationProperty( "LoadSystemObjects", IsRequired = false, DefaultValue = 0 )]
      [IntegerValidator( MinValue = 0, MaxValue = 1 )]
      public int LoadSystemObjects
      {
         get { return (int) this[ "LoadSystemObjects" ]; }
         set { this[ "LoadSystemObjects" ] = value; }
      }

      [ConfigurationProperty( "WithFields", IsRequired = false, DefaultValue = 0 )]
      [IntegerValidator( MinValue = 0, MaxValue = 1 )]
      public int WithFields
      {
         get { return (int) this[ "WithFields" ]; }
         set { this[ "WithFields" ] = value; }
      }

      [ConfigurationProperty( "PathDir", IsRequired = false )]
      [StringValidator( InvalidCharacters = "*?\"<>|" )]
      public string PathDir
      {
         get { return (string) this[ "PathDir" ]; }
         set { this[ "PathDir" ] = value; }
      }
   }
}
