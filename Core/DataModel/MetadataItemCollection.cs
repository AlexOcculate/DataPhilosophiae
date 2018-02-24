namespace DataPhilosophiae.Core.DataModel
{
   [System.Xml.Serialization.XmlRootAttribute( "MIFQNColl" )]
   public partial class MetadataItemCollection
   {
      #region --- TS_STR ---
      public const string TS_MASK_FORMAT = "{0:yyyyMMdd-HHmmss-ffffzzz}";
      [System.ComponentModel.DataAnnotations.Display( AutoGenerateField = false )]
      [System.Xml.Serialization.XmlIgnore]
      public static string TS_STR
      {
         [System.Diagnostics.DebuggerStepThrough]
         get
         {
            return string.Format( TS_MASK_FORMAT, System.DateTime.Now );
         }
      }
      #endregion

      #region --- CREATION TIMESTAMP ----
      public const string CREATION_TS_FIELDNAME = "CreationTS";
      public const string CREATION_TS_DISPLAYNAME = "Creation TS";
      public const string CREATION_TS_DESCRIPTION = null;
      //[System.ComponentModel.DataAnnotations.Display( Name = CREATION_TS_DISPLAYNAME, Description = CREATION_TS_DESCRIPTION )]
      //[System.ComponentModel.DataAnnotations.DataType( System.ComponentModel.DataAnnotations.DataType.DateTime )]
      //[System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlAttribute( "cts" )]
      public System.DateTime CreationTS
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- LIST ---
      [System.Xml.Serialization.XmlArray( "MIFQNList" )]
      [System.Xml.Serialization.XmlArrayItem( typeof( MetadataItem ), ElementName = "MIFQN" )]
      public System.ComponentModel.BindingList<MetadataItem> List { get; set; }
      #endregion

      private static readonly System.ComponentModel.BindingList<MetadataItem> emptyList = new System.ComponentModel.BindingList<MetadataItem>( );

      #region --- CTOR() ---
      public MetadataItemCollection()
      {
         this.CreationTS = System.DateTime.Now;
         this.List = new System.ComponentModel.BindingList<MetadataItem>( );
      }
      #endregion

      #region --- SAVE and LOAD ---
      public void Save( string filepathname )
      {
         //if( !System.IO.Directory.Exists( filepathname ) )
         //{
         //   System.IO.Directory.CreateDirectory( filepathname );
         //}
         this.XmlSerialize( filepathname );
      }
      public static MetadataItemCollection Load( string filepathname )
      {
         MetadataItemCollection coll;
         if( System.IO.File.Exists( filepathname ) )
         {
            coll = MetadataItemCollection.XmlDeserialize( filepathname );
         }
         else
         {
            coll = new MetadataItemCollection( );
         }
         return coll;
      }
      #endregion

      #region --- XML Serialization ---
      public void XmlSerialize( string path )
      {
         System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer( typeof( MetadataItemCollection ) );
         using( System.IO.TextWriter tw = new System.IO.StreamWriter( path ) )
         {
            xs.Serialize( tw, this );
         }
      }
      public static MetadataItemCollection XmlDeserialize( string path )
      {
         System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer( typeof( MetadataItemCollection ) );
         using( System.IO.TextReader tr = new System.IO.StreamReader( path ) )
         {
            var o = xs.Deserialize( tr ) as MetadataItemCollection;
            return o;
         }
      }
      #endregion
   }
}
