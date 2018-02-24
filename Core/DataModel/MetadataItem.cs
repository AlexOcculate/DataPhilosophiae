namespace DataPhilosophiae.Core.DataModel
{
   public partial class MetadataItem
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

      #region --- METADATA PROVIDER ---
      public const string METADATA_PROVIDER_FIELDNAME = "MetadataProvider";
      public const string METADATA_PROVIDER_DISPLAYNAME = "Metadata Provider";
      public const string METADATA_PROVIDER_XMLNAME = "mp";
      [System.Xml.Serialization.XmlElement( METADATA_PROVIDER_XMLNAME )]
      public string MetadataProvider
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- SYNTAX PROVIDER ---
      public const string SYNTAX_PROVIDER_FIELDNAME = "SyntaxProvider";
      public const string SYNTAX_PROVIDER_DISPLAYNAME = "Syntax Provider";
      public const string SYNTAX_PROVIDER_XMLNAME = "sp";
      [System.Xml.Serialization.XmlElement( SYNTAX_PROVIDER_XMLNAME )]
      public string SyntaxProvider
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- ID ---
      public const string ID_FIELDNAME = "ID";
      public const string ID_DISPLAYNAME = "ID";
      public const string ID_DESCRIPTION = null;
      public const string ID_XMLNAME = "id";
      [System.ComponentModel.DataAnnotations.Display( Name = ID_DISPLAYNAME, Description = ID_DESCRIPTION )]
      [System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlAttribute( ID_XMLNAME )]
      public int ID
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- PARENT ID ---
      public const string PARENT_ID_FIELDNAME = "ParentID";
      public const string PARENT_ID_DISPLAYNAME = "Parent ID";
      public const string PARENT_ID_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = PARENT_ID_DISPLAYNAME, Description = PARENT_ID_DESCRIPTION )]
      [System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlAttribute( "pid" )]
      public int ParentID
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- IS SYSTEM ---
      public const string IS_SYSTEM_FIELDNAME = "IsSystem";
      public const string IS_SYSTEM_DISPLAYNAME = "Is System";
      [System.Xml.Serialization.XmlAttribute]
      public bool IsSystem
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      #endregion

      #region --- TYPE ---
      public const string TYPE_FIELDNAME = "Type";
      public const string TYPE_DISPLAYNAME = "Type";
      [System.Xml.Serialization.XmlAttribute]
      public string Type
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      #endregion

      #region --- PARENT TYPE ---
      public const string PARENT_TYPE_FIELDNAME = "ParentType";
      public const string PARENT_TYPE_DISPLAYNAME = "Parent Type";
      [System.Xml.Serialization.XmlAttribute( "pt" )]
      public string ParentType
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      #endregion

      public const string CARDINALYTY_FIELDNAME = "Cardinality";
      public const string CARDINALYTY_DISPLAYNAME = "FK Cardinality";
      public string Cardinality
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }


      public const string FIELDSCOUNT_FIELDNAME = "FieldsCount";
      public const string FIELDSCOUNT_DISPLAYNAME = "FK Fields Count";
      [System.Xml.Serialization.XmlElement( "fc" )]
      public int FieldsCount
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }


      public const string FIELDS_FIELDNAME = "Fields";
      public const string FIELDS_DISPLAYNAME = "FK Fields";
      public string Fields
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string REFERENCED_CARDINALYTY_NAME_FIELDNAME = "ReferencedCardinality";
      public const string REFERENCED_CARDINALYTY_NAME_DISPLAYNAME = "TK Cardinality";
      [System.Xml.Serialization.XmlElement( "rc" )]
      public string ReferencedCardinality
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }


      public const string REFERENCED_OBJECT_FIELDNAME = "ReferencedObject";
      public const string REFERENCED_OBJECT_DISPLAYNAME = "TK Object";
      [System.Xml.Serialization.XmlElement( "ro" )]
      public string ReferencedObject
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string REFERENCED_OBJECT_NAME_FIELDNAME = "ReferencedObjectName";
      public const string REFERENCED_OBJECT_NAME_DISPLAYNAME = "TK Object Name";
      [System.Xml.Serialization.XmlElement( "ron" )]
      public string ReferencedObjectName
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string REFERENCED_FIELDS_COUNT_FIELDNAME = "ReferencedFieldsCount";
      public const string REFERENCED_FIELDS_COUNT_DISPLAYNAME = "TK Fields Count";
      [System.Xml.Serialization.XmlElement( "rfc" )]
      public int ReferencedFieldsCount
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string REFERENCED_FIELDS_FIELDNAME = "ReferencedFields";
      public const string REFERENCED_FIELDS_DISPLAYNAME = "TK Fields";
      [System.Xml.Serialization.XmlElement( "rf" )]
      public string ReferencedFields
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string SERVER_FIELDNAME = "Server";
      [System.Xml.Serialization.XmlElement( "svr" )]
      public string Server
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string DATABASE_FIELDNAME = "Database";
      [System.Xml.Serialization.XmlElement( "db" )]
      public string Database
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string SCHEMA_FIELDNAME = "Schema";
      [System.Xml.Serialization.XmlElement( "sch" )]
      public string Schema
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string OBJECT_FIELDNAME = "ObjectName";
      public const string OBJECT_DISPLAYNAME = "Parent Name";
      [System.Xml.Serialization.XmlElement( "on" )]
      public string ObjectName
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string NAMEFULLQUALIFIED_FIELDNAME = "NameFullQualified";
      public const string NAMEFULLQUALIFIED_DISPLAYNAME = "Name Full Qualified";
      [System.Xml.Serialization.XmlElement( "nfq" )]
      public string NameFullQualified
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string NAMEQUOTED_FIELDNAME = "NameQuoted";
      [System.Xml.Serialization.XmlElement( "nq" )]
      public string NameQuoted
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string ALTNAME_FIELDNAME = "AltName";
      [System.Xml.Serialization.XmlElement( "an" )]
      public string AltName
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string FIELD_FIELDNAME = "Field";
      public const string FIELD_DISPLAYNAME = "Name";
      [System.Xml.Serialization.XmlElement( "fld" )]
      public string Field
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      [System.Xml.Serialization.XmlAttribute]
      public bool HasDefault
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string EXPRESSION_FIELDNAME = "Expression";
      [System.Xml.Serialization.XmlElement( "xpr" )]
      public string Expression
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string FIELD_TYPE_FIELDNAME = "FieldType";
      public const string FIELD_TYPE_DISPLAYNAME = ".Net Type Name";
      [System.Xml.Serialization.XmlElement( "ft" )]
      public string FieldType
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string FIELD_TYPE_NAME_FIELDNAME = "FieldTypeName";
      public const string FIELD_TYPE_NAME_DISPLAYNAME = "Database Type Name";
      [System.Xml.Serialization.XmlElement( "ftn" )]
      public string FieldTypeName
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      [System.Xml.Serialization.XmlAttribute]
      public bool IsNullable
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      [System.Xml.Serialization.XmlElement( "prec" )]
      public int Precision
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      [System.Xml.Serialization.XmlElement( "sc" )]
      public int Scale
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      [System.Xml.Serialization.XmlElement( "sz" )]
      public long Size
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string IS_PK_FIELDNAME = "IsPK";
      [System.Xml.Serialization.XmlAttribute]
      public bool IsPK
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string IS_READONLY_FIELDNAME = "IsRO";
      [System.Xml.Serialization.XmlAttribute]
      public bool IsRO
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string DESCRIPTION_FIELDNAME = "Description";
      [System.Xml.Serialization.XmlElement( "dscr" )]
      public string Description
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string TAG_FIELDNAME = "Tag";
      public object Tag
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public const string USERDATA_FIELDNAME = "UserData";
      [System.Xml.Serialization.XmlElement( "ud" )]
      public string UserData
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }

      public override string ToString()
      {
         return string.Format( "0:{1}", this.Type, this.NameFullQualified );
      }

      public MetadataItem()
      {
      }

   }
}
