namespace DataPhilosophiae.Core.DataModel
{
   [DevExpress.Xpo.Persistent( "DATASTORE" )]
   public partial class DataStore : DevExpress.Xpo.XPCustomObject
   {
      #region --- Enums... ---
      public enum MetadataProviderEnum
      {
         AUTO = 0,
         GENERIC,
         MS_SQL_SERVER,
      }
      public enum SyntaxProviderEnum
      {
         AUTO = 0,
         GENERIC,
         ANSI_SQL_2003,
         ANSI_SQL_89,
         ANSI_SQL_92,
         // 05
         FIREBIRD_1_0,
         FIREBIRD_1_5,
         FIREBIRD_2_0,
         FIREBIRD_2_5,
         IBM_DB2,
         // 10
         IBM_INFORMIX_10,
         IBM_INFORMIX_8,
         IBM_INFORMIX_9,
         MS_ACCESS_2000,
         MS_ACCESS_2003,
         // 15
         MS_ACCESS_97,
         MS_ACCESS_XP,
         MS_SQL_SERVER_2000,
         MS_SQL_SERVER_2005,
         MS_SQL_SERVER_2008,
         // 20
         MS_SQL_SERVER_2012,
         MS_SQL_SERVER_2014,
         MS_SQL_SERVER_7,
         MS_SQL_SERVER_COMPACT_EDITION,
         MYSQL_3_XX,
         // 25
         MYSQL_4_0,
         MYSQL_4_1,
         MYSQL_5_0,
         ORACLE_10,
         ORACLE_11,
         // 30
         ORACLE_7,
         ORACLE_8,
         ORACLE_9,
         POSTGRESQL,
         SQLITE,
         // 35
         SYBASE_ASE,
         SYBASE_SQL_ANYWHERE,
         TERADATA,
         VISTADB,
      }
      #endregion

      #region --- CREATION TIMESTAMP ----
      public const string CREATION_TS_FIELDNAME = "CreationTS";
      public const string CREATION_TS_XMLFIELDNAME = "cts";
      public const string CREATION_TS_DBFIELDNAME = "cts";
      public const string CREATION_TS_DISPLAYNAME = "Creation TS";
      public const string CREATION_TS_DESCRIPTION = null;
      //[System.ComponentModel.DataAnnotations.Display( Name = CREATION_TS_DISPLAYNAME, Description = CREATION_TS_DESCRIPTION )]
      //[System.ComponentModel.DataAnnotations.DataType( System.ComponentModel.DataAnnotations.DataType.DateTime )]
      //[System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlAttribute( CREATION_TS_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( CREATION_TS_DBFIELDNAME )]

      public System.DateTime CreationTS
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- PULL TIMESTAMP ----
      public const string PULL_TS_FIELDNAME = "PullTS";
      public const string PULL_TS_XMLFIELDNAME = "pts";
      public const string PULL_TS_DBFIELDNAME = "pts";
      public const string PULL_TS_DISPLAYNAME = "Pull TS";
      public const string PULL_TS_DESCRIPTION = null;
      //[System.ComponentModel.DataAnnotations.Display( Name = PULL_TS_DISPLAYNAME, Description = PULL_TS_DESCRIPTION )]
      //[System.ComponentModel.DataAnnotations.DataType( System.ComponentModel.DataAnnotations.DataType.DateTime )]
      //[System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlAttribute( PULL_TS_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( PULL_TS_DBFIELDNAME )]

      public System.DateTime PullTS
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- ID ---
      public const string ID_FIELDNAME = "ID";
      public const string ID_XMLFIELDNAME = "id";
      public const string ID_DBFIELDNAME = "id";
      public const string ID_DISPLAYNAME = "ID";
      public const string ID_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = ID_DISPLAYNAME, Description = ID_DESCRIPTION )]
      [System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlAttribute( ID_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( ID_DBFIELDNAME )]
      [DevExpress.Xpo.Key( true )]

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
      public const string PARENT_ID_XMLFIELDNAME = "pid";
      public const string PARENT_ID_DBFIELDNAME = "pid";
      public const string PARENT_ID_DISPLAYNAME = "Parent ID";
      public const string PARENT_ID_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = PARENT_ID_DISPLAYNAME, Description = PARENT_ID_DESCRIPTION )]
      [System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlAttribute( PARENT_ID_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( PARENT_ID_DBFIELDNAME )]

      public int ParentID
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- COLL ID ---
      public const string CID_FIELDNAME = "CID";
      public const string CID_XMLFIELDNAME = "cid";
      public const string CID_DBFIELDNAME = "cid";
      public const string CID_DISPLAYNAME = "CID";
      public const string CID_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = CID_DISPLAYNAME, Description = CID_DESCRIPTION )]
      [System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlAttribute( CID_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( CID_DBFIELDNAME )]
      public int CID
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- IS ACTIVE ? ---
      public const string IS_ACTIVE_FIELDNAME = "IsActive";
      public const string IS_ACTIVE_XMLFIELDNAME = "actv";
      public const string IS_ACTIVE_DBFIELDNAME = "actv";
      public const string IS_ACTIVE_DISPLAYNAME = "Is Active?";
      public const string IS_ACTIVE_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = IS_ACTIVE_DISPLAYNAME, Description = IS_ACTIVE_DESCRIPTION )]
      [System.Xml.Serialization.XmlAttribute( IS_ACTIVE_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( IS_ACTIVE_DBFIELDNAME )]

      public bool IsActive
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- NAME ---
      public const string NAME_FIELDNAME = "Name";
      public const string NAME_XMLFIELDNAME = "name";
      public const string NAME_DBFIELDNAME = "name";
      public const string NAME_DISPLAYNAME = "Name";
      public const string NAME_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = NAME_DISPLAYNAME, Description = NAME_DESCRIPTION )]
      [System.Xml.Serialization.XmlAttribute( NAME_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( NAME_DBFIELDNAME )]

      public string Name
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- DESCRIPTION ---
      public const string DESCRIPTION_FIELDNAME = "Description";
      public const string DESCRIPTION_XMLFIELDNAME = "dscr";
      public const string DESCRIPTION_DBFIELDNAME = "dscr";
      public const string DESCRIPTION_DISPLAYNAME = "Description";
      public const string DESCRIPTION_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = DESCRIPTION_DISPLAYNAME, Description = DESCRIPTION_DESCRIPTION )]
      [System.Xml.Serialization.XmlElement( DESCRIPTION_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( DESCRIPTION_DBFIELDNAME )]

      public string Description
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- PREVIEW ---
      public const string PREVIEW_FIELDNAME = "Preview";
      public const string PREVIEW_DISPLAYNAME = "Preview";
      public const string PREVIEW_XMLFIELDNAME = "prvw";
      public const string PREVIEW_DBFIELDNAME = "prvw";
      public const string PREVIEW_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = PREVIEW_DISPLAYNAME, Description = PREVIEW_DESCRIPTION )]
      [System.Xml.Serialization.XmlElement( PREVIEW_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( PREVIEW_DBFIELDNAME )]

      public string Preview
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- IS TO PULL REMOTELY ? ---
      public const string IS_PULL_REMOTELY_FIELDNAME = "IsToPullRemotely";
      public const string IS_PULL_REMOTELY_DISPLAYNAME = "Is To Pull Remotely?";
      public const string IS_PULL_REMOTELY_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = IS_PULL_REMOTELY_DISPLAYNAME, Description = IS_PULL_REMOTELY_DESCRIPTION )]
      [System.Xml.Serialization.XmlIgnore]
      [DevExpress.Xpo.NonPersistent]

      public bool IsToPullRemotely
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- NOTIFICATION WHEN STARTED ? ---
      public const string NOTIFICATION_WHEN_STARTED_FIELDNAME = "NotificationWhenStarted";
      public const string NOTIFICATION_WHEN_STARTED_XMLFIELDNAME = "nws";
      public const string NOTIFICATION_WHEN_STARTED_DBFIELDNAME = "nws";
      public const string NOTIFICATION_WHEN_STARTED_DISPLAYNAME = "Notification When Started?";
      public const string NOTIFICATION_WHEN_STARTED_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = NOTIFICATION_WHEN_STARTED_DISPLAYNAME, Description = NOTIFICATION_WHEN_STARTED_DESCRIPTION )]
      [System.Xml.Serialization.XmlAttribute( NOTIFICATION_WHEN_STARTED_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( NOTIFICATION_WHEN_STARTED_DBFIELDNAME )]

      public bool NotificationWhenStarted
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- NOTIFICATION WHEN FINISHED ? ---
      public const string NOTIFICATION_WHEN_FINISHED_FIELDNAME = "NotificationWhenFinished";
      public const string NOTIFICATION_WHEN_FINISHED_XMLFIELDNAME = "nwf";
      public const string NOTIFICATION_WHEN_FINISHED_DBFIELDNAME = "nwf";
      public const string NOTIFICATION_WHEN_FINISHED_DISPLAYNAME = "Notification When Finished?";
      public const string NOTIFICATION_WHEN_FINISHED_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = NOTIFICATION_WHEN_FINISHED_DISPLAYNAME, Description = NOTIFICATION_WHEN_FINISHED_DESCRIPTION )]
      [System.Xml.Serialization.XmlAttribute( NOTIFICATION_WHEN_FINISHED_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( NOTIFICATION_WHEN_FINISHED_DBFIELDNAME )]

      public bool NotificationWhenFinished
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- SYNTAX PROVIDER ---
      public const string SYNTAX_PROVIDER_FIELDNAME = "SyntaxProvider";
      public const string SYNTAX_PROVIDER_XMLFIELDNAME = "sp";
      public const string SYNTAX_PROVIDER_DBFIELDNAME = "sp";
      public const string SYNTAX_PROVIDER_DISPLAYNAME = "Syntax Provider";
      public const string SYNTAX_PROVIDER_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = SYNTAX_PROVIDER_DISPLAYNAME, Description = SYNTAX_PROVIDER_DESCRIPTION )]
      [System.Xml.Serialization.XmlAttribute( SYNTAX_PROVIDER_XMLFIELDNAME )]
      [System.ComponentModel.DataAnnotations.EnumDataType( typeof( SyntaxProviderEnum ) )]
      [System.ComponentModel.DataAnnotations.Required]
      [DevExpress.Xpo.Persistent( SYNTAX_PROVIDER_DBFIELDNAME )]

      public int SyntaxProvider
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- METADATA PROVIDER ---
      public const string METADATA_PROVIDER_FIELDNAME = "MetadataProvider";
      public const string METADATA_PROVIDER_DISPLAYNAME = "Metadata Provider";
      public const string METADATA_PROVIDER_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = METADATA_PROVIDER_DISPLAYNAME, Description = METADATA_PROVIDER_DESCRIPTION )]
      [System.Xml.Serialization.XmlAttribute]
      [System.ComponentModel.DataAnnotations.EnumDataType( typeof( MetadataProviderEnum ) )]
      [System.ComponentModel.DataAnnotations.Required]
      [System.Xml.Serialization.XmlIgnore]
      [DevExpress.Xpo.NonPersistent]

      public int MetadataProvider
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- LOAD DEFAULT DATABASE ONLY ? ---
      public const string LOAD_DEFAULT_DATABASE_ONLY_FIELDNAME = "LoadDefaultDatabaseOnly";
      public const string LOAD_DEFAULT_DATABASE_ONLY_XMLFIELDNAME = "lddo";
      public const string LOAD_DEFAULT_DATABASE_ONLY_DBFIELDNAME = "lddo";
      public const string LOAD_DEFAULT_DATABASE_ONLY_DISPLAYNAME = "Load Default Database Only?";
      public const string LOAD_DEFAULT_DATABASE_ONLY_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = LOAD_DEFAULT_DATABASE_ONLY_DISPLAYNAME, Description = LOAD_DEFAULT_DATABASE_ONLY_DESCRIPTION )]
      [System.Xml.Serialization.XmlAttribute( LOAD_DEFAULT_DATABASE_ONLY_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( LOAD_DEFAULT_DATABASE_ONLY_DBFIELDNAME )]

      public bool LoadDefaultDatabaseOnly
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- LOAD SYSTEM OBJECTS ? ---
      public const string LOAD_SYSTEM_OBJECTS_FIELDNAME = "LoadSystemObjects";
      public const string LOAD_SYSTEM_OBJECTS_XMLFIELDNAME = "lso";
      public const string LOAD_SYSTEM_OBJECTS_DBFIELDNAME = "lso";
      public const string LOAD_SYSTEM_OBJECTS_DISPLAYNAME = "Load System Objects?";
      public const string LOAD_SYSTEM_OBJECTS_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = LOAD_SYSTEM_OBJECTS_DISPLAYNAME, Description = LOAD_SYSTEM_OBJECTS_DESCRIPTION )]
      [System.Xml.Serialization.XmlAttribute( LOAD_SYSTEM_OBJECTS_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( LOAD_SYSTEM_OBJECTS_DBFIELDNAME )]

      public bool LoadSystemObjects
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- WITH FIELDS ? ---
      public const string WITH_FIELDS_FIELDNAME = "WithFields";
      public const string WITH_FIELDS_XMLFIELDNAME = "wf";
      public const string WITH_FIELDS_DBFIELDNAME = "wf";
      public const string WITH_FIELDS_DISPLAYNAME = "With Fields?";
      public const string WITH_FIELDS_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = WITH_FIELDS_DISPLAYNAME, Description = WITH_FIELDS_DESCRIPTION )]
      [System.Xml.Serialization.XmlAttribute( WITH_FIELDS_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( WITH_FIELDS_DBFIELDNAME )]

      public bool WithFields
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- CONNECTION STRING ---
      public const string CONNECTION_STRING_FIELDNAME = "ConnectionString";
      public const string CONNECTION_STRING_XMLFIELDNAME = "cs";
      public const string CONNECTION_STRING_DBFIELDNAME = "cs";
      public const string CONNECTION_STRING_DISPLAYNAME = "Connection String";
      public const string CONNECTION_STRING_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = CONNECTION_STRING_DISPLAYNAME, Description = CONNECTION_STRING_DESCRIPTION )]
      [System.Xml.Serialization.XmlElement( CONNECTION_STRING_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( CONNECTION_STRING_DBFIELDNAME )]

      public string ConnectionString
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- TEMP FILE PATH NAME ---
      public const string TEMPFILEPATHNAME_FIELDNAME = "TempFileFullPathName";
      public const string TEMPFILEPATHNAME_XMLFIELDNAME = "tffpn";
      public const string TEMPFILEPATHNAME_DBFIELDNAME = "tffpn";
      public const string TEMPFILEPATHNAME_DISPLAYNAME = "TempFile";
      public const string TEMPFILEPATHNAME_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = TEMPFILEPATHNAME_DISPLAYNAME, Description = TEMPFILEPATHNAME_DESCRIPTION )]
      [System.Xml.Serialization.XmlElement( TEMPFILEPATHNAME_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( TEMPFILEPATHNAME_DBFIELDNAME )]

      public string TempFileFullPathName
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- AQB QB XML FILENAME ---
      public const string AQB_QB_XML_FILENAME_FIELDNAME = "AqbQbFilename";
      public const string AQB_QB_XML_FILENAME_XMLFIELDNAME = "affpn";
      public const string AQB_QB_XML_FILENAME_DISPLAYNAME = "AqbQb Filename";
      public const string AQB_QB_XML_FILENAME_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = AQB_QB_XML_FILENAME_DISPLAYNAME, Description = AQB_QB_XML_FILENAME_DESCRIPTION )]
      [System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlElement( AQB_QB_XML_FILENAME_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent]

      public string AqbQbFilename
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- MI FQN XML FILENAME ---
      public const string MI_FQN_XML_FILENAME_FIELDNAME = "MiFqnFilename";
      public const string MI_FQN_XML_FILENAME_XMLFIELDNAME = "mffpn";
      public const string MI_FQN_XML_FILENAME_DISPLAYNAME = "MiFqn Filename";
      public const string MI_FQN_XML_FILENAME_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = MI_FQN_XML_FILENAME_DISPLAYNAME, Description = MI_FQN_XML_FILENAME_DESCRIPTION )]
      [System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlElement( MI_FQN_XML_FILENAME_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent]

      public string MiFqnFilename
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- Ctors() ---
      public DataStore()
      {
         this.CreationTS = System.DateTime.Now;
      }
      #endregion

      public override string ToString()
      {
         string s = string.Format(
            "ID: {0}, IsActive: {1}, IsToPullRemotely: {2}, SyntaxProvider: {3}",
            this.ID, this.IsActive,
            this.IsToPullRemotely,
            ((SyntaxProviderEnum) this.SyntaxProvider).ToString( )
         );
         return s;
      }
   }
}
