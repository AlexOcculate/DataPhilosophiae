namespace DataPhilosophiae.Core.DataModel
{
   [System.Xml.Serialization.XmlRootAttribute( "DSColl" )]
   [DevExpress.Xpo.Persistent( "DATASTORE_COLL" )]
   public partial class DataStoreCollection : DevExpress.Xpo.XPCustomObject
   {
      #region --- START TIMESTAMP ----
      public const string START_TS_FIELDNAME = "StartTS";
      public const string START_TS_XMLFIELDNAME = "sts";
      public const string START_TS_DBFIELDNAME = "sts";
      public const string START_TS_DISPLAYNAME = "Start TS";
      public const string START_TS_DESCRIPTION = null;
      //[System.ComponentModel.DataAnnotations.Display( Name = START_TS_DISPLAYNAME, Description = START_TS_DESCRIPTION )]
      //[System.ComponentModel.DataAnnotations.DataType( System.ComponentModel.DataAnnotations.DataType.DateTime )]
      //[System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlAttribute( START_TS_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( START_TS_DBFIELDNAME )]

      public System.DateTime StartTS
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- FINISH TIMESTAMP ----
      public const string FINISH_TS_FIELDNAME = "FinishTS";
      public const string FINISH_TS_XMLFIELDNAME = "fts";
      public const string FINISH_TS_DBFIELDNAME = "fts";
      public const string FINISH_TS_DISPLAYNAME = "Finish TS";
      public const string FINISH_TS_DESCRIPTION = null;
      //[System.ComponentModel.DataAnnotations.Display( Name = FINISH_TS_DISPLAYNAME, Description = FINISH_TS_DESCRIPTION )]
      //[System.ComponentModel.DataAnnotations.DataType( System.ComponentModel.DataAnnotations.DataType.DateTime )]
      //[System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlAttribute( FINISH_TS_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( FINISH_TS_DBFIELDNAME )]

      public System.DateTime FinishTS
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

      #region --- LIST SIZE ---
      public const string SIZE_FIELDNAME = "ListSize";
      public const string SIZE_XMLFIELDNAME = "lsz";
      public const string SIZE_DBFIELDNAME = "sz";
      public const string SIZE_DISPLAYNAME = "List Size";
      public const string SIZE_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = SIZE_DISPLAYNAME, Description = SIZE_DESCRIPTION )]
      [System.ComponentModel.ReadOnly( true )]
      [System.Xml.Serialization.XmlAttribute( SIZE_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( SIZE_DBFIELDNAME )]

      public int ListSize
      {
         [System.Diagnostics.DebuggerStepThrough]
         get { return this.List.Count; }
      }
      #endregion

      #region --- ORIGINAL FILE PATH NAME ---
      public const string ORIGFILEPATHNAME_FIELDNAME = "OrigFileFullPathName";
      public const string ORIGFILEPATHNAME_XMLFIELDNAME = "offpn";
      public const string ORIGFILEPATHNAME_DBFIELDNAME = "offpn";
      public const string ORIGFILEPATHNAME_DISPLAYNAME = "OrigFile";
      public const string ORIGFILEPATHNAME_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = ORIGFILEPATHNAME_DISPLAYNAME, Description = ORIGFILEPATHNAME_DESCRIPTION )]
      [System.Xml.Serialization.XmlElement( ORIGFILEPATHNAME_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( ORIGFILEPATHNAME_DBFIELDNAME )]

      public string OrigFileFullPathName
      {
         [System.Diagnostics.DebuggerStepThrough]
         get { return GetPropertyValue<string>( ORIGFILEPATHNAME_FIELDNAME ); }
         [System.Diagnostics.DebuggerStepThrough]
         set { SetPropertyValue<string>( ORIGFILEPATHNAME_FIELDNAME, value ); }
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

      #region --- SQLITE FILE PATH NAME ---
      public const string SQLITE_FILEPATHNAME_FIELDNAME = "SQLiteFileFullPathName";
      public const string SQLITE_FILEPATHNAME_XMLFIELDNAME = "sffpn";
      public const string SQLITE_FILEPATHNAME_DBFIELDNAME = "sffpn";
      public const string SQLITE_FILEPATHNAME_DISPLAYNAME = "SQLiteFile";
      public const string SQLITE_FILEPATHNAME_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = SQLITE_FILEPATHNAME_DISPLAYNAME, Description = SQLITE_FILEPATHNAME_DESCRIPTION )]
      [System.Xml.Serialization.XmlElement( SQLITE_FILEPATHNAME_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( SQLITE_FILEPATHNAME_DBFIELDNAME )]

      public string SQLiteFileFullPathName
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- XML FILE PATH NAME ---
      public const string XML_FILEPATHNAME_FIELDNAME = "XmlFileFullPathName";
      public const string XML_FILEPATHNAME_XMLFIELDNAME = "xffpn";
      public const string XML_FILEPATHNAME_DBFIELDNAME = "xffpn";
      public const string XML_FILEPATHNAME_DISPLAYNAME = "XMLFile";
      public const string XML_FILEPATHNAME_DESCRIPTION = null;
      [System.ComponentModel.DataAnnotations.Display( Name = XML_FILEPATHNAME_DISPLAYNAME, Description = XML_FILEPATHNAME_DESCRIPTION )]
      [System.Xml.Serialization.XmlElement( XML_FILEPATHNAME_XMLFIELDNAME )]
      [DevExpress.Xpo.Persistent( XML_FILEPATHNAME_DBFIELDNAME )]

      public string XmlFileFullPathName
      {
         [System.Diagnostics.DebuggerStepThrough]
         get;
         [System.Diagnostics.DebuggerStepThrough]
         set;
      }
      #endregion

      #region --- LIST ---
      [System.Xml.Serialization.XmlArray( "DSList" )]
      [System.Xml.Serialization.XmlArrayItem( typeof( DataStore ), ElementName = "DS" )]
      [DevExpress.Xpo.NonPersistent]
      public System.ComponentModel.BindingList<DataStore> List { get; set; }
      #endregion

      #region --- CTOR() ---
      public DataStoreCollection()
      {
         this.StartTS = System.DateTime.Now;
         this.List = new System.ComponentModel.BindingList<DataStore>( );
      }

      #endregion

      #region --- SAVE and LOAD --
      private void SaveXML( string filepathname )
      {
         //if( !System.IO.Directory.Exists( filepathname ) )
         //{
         //   System.IO.Directory.CreateDirectory( filepathname );
         //}
         this.XmlSerialize( filepathname );
      }
      private static DataStoreCollection LoadXML( string filepathname )
      {
         DataStoreCollection coll;
         if( System.IO.File.Exists( filepathname ) )
         {
            coll = DataStoreCollection.XmlDeserialize( filepathname );
         }
         else
         {
            coll = new DataStoreCollection( );
         }
         return coll;
      }
      #endregion

      #region --- XML Serialization ---
      private void XmlSerialize( string path )
      {
         System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer( typeof( DataStoreCollection ) );
         using( System.IO.TextWriter tw = new System.IO.StreamWriter( path ) )
         {
            xs.Serialize( tw, this );
         }
      }
      private static DataStoreCollection XmlDeserialize( string path )
      {
         System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer( typeof( DataStoreCollection ) );
         using( System.IO.TextReader tr = new System.IO.StreamReader( path ) )
         {
            var o = xs.Deserialize( tr ) as DataStoreCollection;
            return o;
         }
      }
      #endregion

      private DataStore NewDataStoreTemplate()
      {
         DataStore o = new DataStore( )
         {
            CreationTS = System.DateTime.Now,
            ID = this.List.Count,
            ParentID = -1,
            Name = "<Name-PlaceHolder>",
            Description = "<Description-PlaceHolder>",
            Preview = "<Preview-PlaceHolder>",
            IsActive = false,
            IsToPullRemotely = false,
            SyntaxProvider = (int) DataStore.SyntaxProviderEnum.AUTO,
            MetadataProvider = (int) DataStore.MetadataProviderEnum.AUTO,
            LoadDefaultDatabaseOnly = false,
            LoadSystemObjects = false,
            WithFields = false,
            ConnectionString = "<ConnectionString-PlaceHolder>",
            //AqbQbFilename = "AQFN",
            //MiFqnFilename = "MIFQNFN"
         };
         this.List.Add( o );
         o.CID = this.ID;
         //
         return o;
      }

      public void SaveDataStoreCollection()
      {
         string tsStr = Global.TS_STR;
         string path = Global.DataStoreCollectionPathName;
         string sqliteFn = System.IO.Path.Combine( path, tsStr + "." + Global.DataStoreCollectionSQLiteFileName );
         string xmlFn = System.IO.Path.Combine( path, tsStr + "." + Global.DataStoreCollectionXmlFileName );
         this.SQLiteFileFullPathName = sqliteFn;
         this.XmlFileFullPathName = xmlFn;
         this.FinishTS = System.DateTime.Now;
         //SaveDataStoreCollection( this );
         //// SQLite From TMP to "USER PATH"
         //System.IO.File.Copy( this.TempFileFullPathName, this.SQLiteFileFullPathName, true );
         // Save XML at "USER PATH"
         this.SaveXML( this.XmlFileFullPathName );
      }
      private static void SaveDataStoreCollection( DataStoreCollection dsColl )
      {
         // The session creation must be before the object creation!!!
         //DevExpress.Xpo.Session session = DevExpress.Xpo.XpoDefault.Session; // DevExpress.Xpo.Session.DefaultSession;
         //session.Save( dsColl );
         //foreach( DataStore ds in dsColl.List )
         //{
         //   session.Save( ds );
         //}
      }

      public static DataStoreCollection LoadDataStoreCollection()
      {
         DataStoreCollection dsColl = dsColl = DataStoreCollection.LoadLastWrittenXmlDataStoreCollection( );
         if( dsColl == null )
         {
            dsColl = DataStoreCollection.CreateBootstrapDataStoreCollection( );
         }
         return dsColl;
      }

      private static DataStoreCollection LoadLastWrittenXmlDataStoreCollection()
      {
         System.Diagnostics.Debug.Write( "[START]" + "LoadLastWrittenXmlDataStoreCollection" );
         System.Diagnostics.Trace.Write( "[START]" + "LoadLastWrittenXmlDataStoreCollection" );
         System.Console.WriteLine( "[START]" + "LoadLastWrittenXmlDataStoreCollection" );
         System.IO.FileInfo fi = Global.GetLastWrittenXmlFileInfo( );
         if( fi == null )
         {
            return null;
         }
         // The session creation must be before the object creation!!!
         string tffpn = CreateSession2TmpFs( );
         System.Diagnostics.Debug.Write( "[START]" + fi.FullName );
         System.Diagnostics.Trace.Write( "[START]" + fi.FullName );
         System.Console.WriteLine( "[START]" + fi.FullName );
         DataStoreCollection dsColl = DataStoreCollection.LoadXML( fi.FullName );
         System.Console.WriteLine( "[  END]" + fi.FullName );
         System.Diagnostics.Debug.Write( "[  END]" + fi.FullName );
         System.Diagnostics.Trace.Write( "[  END]" + fi.FullName );
         dsColl.ID = 0;
         dsColl.OrigFileFullPathName = fi.FullName;
         dsColl.TempFileFullPathName = tffpn;
         //SaveDataStoreCollection( dsColl );
         //
         return dsColl;
      }

      private static DataStoreCollection CreateBootstrapDataStoreCollection()
      {
         string tfn = CreateSession2TmpFs( );
         //
         DataStoreCollection dsColl = new DataStoreCollection( )
         {
            IsActive = true,
            OrigFileFullPathName = null,
            TempFileFullPathName = tfn,
            Name = "<Name-PlaceHolder>"
         };
         {
            SaveDataStoreCollection( dsColl );
            {
               DataStore o = dsColl.NewDataStoreTemplate( );
               o.CID = dsColl.ID;
               o.Name = "ChiNook";
               o.ConnectionString = @"Data Source=D:\TEMP\SQLite\chinook\chinook.db;";
               o.IsActive = true;
               o.IsToPullRemotely = false;
               o.Preview = o.Description = null;
               o.SyntaxProvider = (int) DataStore.SyntaxProviderEnum.SQLITE;
               o.WithFields = true;
            }
            {
               DataStore o = dsColl.NewDataStoreTemplate( );
               o.CID = dsColl.ID;
               o.Name = "MSSServer Test";
               o.ConnectionString = @"Data Source=DBSRV\QWERTY;Database=Sales;User Id=user02;Password=8a0IucJ@Nx1Qy5HfFrX0Ob3m;";
               o.IsActive = true;
               o.IsToPullRemotely = false;
               o.Preview = o.Description = null;
               o.SyntaxProvider = (int) DataStore.SyntaxProviderEnum.MS_SQL_SERVER_2014;
               o.WithFields = true;
            }
            {
               DataStore o = dsColl.NewDataStoreTemplate( );
               o.CID = dsColl.ID;
               o.Name = "SQLite DB1 Test";
               o.ConnectionString = @"Data Source=D:\TEMP\SQLite\SQLITEDB1.db3;";
               o.IsActive = true;
               o.IsToPullRemotely = false;
               o.Preview = o.Description = null;
               o.SyntaxProvider = (int) DataStore.SyntaxProviderEnum.SQLITE;
               o.WithFields = true;
            }
            {
               DataStore o = dsColl.NewDataStoreTemplate( );
               o.CID = dsColl.ID;
            }
            SaveDataStoreCollection( dsColl );
         }
         return dsColl;
      }

      private static string CreateSession2TmpFs()
      {
         // The session creation must be before the object creation!!!
         // create "original file" @ "TMP FS"...
         string tfn = Global.TempPathName + System.IO.Path.GetFileName( System.IO.Path.GetTempFileName( ) );
         //string tfn = System.AppDomain.CurrentDomain.BaseDirectory + System.IO.Path.GetFileName( System.IO.Path.GetTempFileName( ) );
         //string x = "Data Source=" + tfn + ";";
         //try
         //{
         //   string cs = DevExpress.Xpo.DB.SQLiteConnectionProvider.GetConnectionString( tfn );
         //   DevExpress.Xpo.IDataLayer dl = DevExpress.Xpo.XpoDefault.GetDataLayer( cs, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema );
         //   DevExpress.Xpo.XpoDefault.DataLayer = dl;
         //}
         //catch( System.Exception ex )
         //{
         //   var str = ex.ToString( );
         //   int i = 1 + 1;
         //}
         //
         return tfn;
      }
   }
}
