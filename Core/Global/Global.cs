namespace DataPhilosophiae.Core
{
   [System.Xml.Serialization.XmlRootAttribute( "Global" )]
   public static class Global
   {
      private static System.Configuration.Configuration cm = System.Configuration.ConfigurationManager.OpenExeConfiguration( System.Configuration.ConfigurationUserLevel.None );
      private static System.Configuration.KeyValueConfigurationCollection confColl = cm.AppSettings.Settings;
      #region --- TS_STR ---
      public const string TS_MASK_FORMAT = "{0:yyyyMMdd-HHmmss-fffffffzzz}";
      public static string TS_STR
      {
         [System.Diagnostics.DebuggerStepThrough]
         get
         {
            return string.Format( TS_MASK_FORMAT, System.DateTime.Now ).Replace( ":", "" );
         }
      }
      #endregion

      public static string FileExtensionSQLite = @".db";
      public static string FileExtensionXml = @".xml";
      public static string FileExtensionXmlAqbQb = @".AqbQb" + Global.FileExtensionXml;
      public static string FileExtensionXmlMiFqn = @".MiFqn" + Global.FileExtensionXml;
      //
      private const string TEMP_PATH_DIR_CONFIG_KEY_NAME = "TEMP_PATHDIR";
      public static string TempPathName
      {
         //[System.Diagnostics.DebuggerStepThrough]
         get
         {
            try
            {
               return confColl[ TEMP_PATH_DIR_CONFIG_KEY_NAME ].Value;
            }
            catch( System.Exception ex )
            {
               confColl.Add( TEMP_PATH_DIR_CONFIG_KEY_NAME, System.IO.Path.GetTempPath( ) );
               cm.Save( System.Configuration.ConfigurationSaveMode.Minimal );
               return confColl[ TEMP_PATH_DIR_CONFIG_KEY_NAME ].Value;
            }
         }
      }
      private const string DATASTORECOLL_PATH_DIR_CONFIG_KEY_NAME = "DSCOLL_PATHDIR";
      public static string DataStoreCollectionPathName
      {
         //[System.Diagnostics.DebuggerStepThrough]
         get
         {
            try
            {
               return confColl[ DATASTORECOLL_PATH_DIR_CONFIG_KEY_NAME ].Value;
            }
            catch( System.Exception ex )
            {
               confColl.Add( DATASTORECOLL_PATH_DIR_CONFIG_KEY_NAME, System.IO.Path.GetTempPath( ) );
               cm.Save( System.Configuration.ConfigurationSaveMode.Minimal );
               return confColl[ DATASTORECOLL_PATH_DIR_CONFIG_KEY_NAME ].Value;
            }
         }
      }
      //
      public static string DataStoreCollectionBaseName = @"DataStoreCollection";
      public static string DataStoreCollectionSQLiteFileName = DataStoreCollectionBaseName + FileExtensionSQLite;
      public static string DataStoreCollectionXmlFileName = DataStoreCollectionBaseName + FileExtensionXml;
      public static string DataStoreCollectionXmlFilePathName = DataStoreCollectionPathName + DataStoreCollectionXmlFileName;

      public static string GetTempFilePathWithExtension( string extension )
      {
         var path = System.IO.Path.GetTempPath( );
         var fileName = System.Guid.NewGuid( ).ToString( ) + extension;
         return System.IO.Path.Combine( path, fileName );
      }

      public static System.IO.FileInfo GetLastWrittenXmlFileInfo()
      {
         string s = "*." + Global.DataStoreCollectionBaseName + Global.FileExtensionXml;
         System.IO.DirectoryInfo di = new System.IO.DirectoryInfo( Global.DataStoreCollectionPathName );
         System.IO.FileInfo[ ] fis = di.GetFiles( s, System.IO.SearchOption.TopDirectoryOnly );
         if( fis.Length == 0 )
         {
            return null;
         }
         System.IO.FileInfo fi = fis[ 0 ];
         for( int i = 1; i < fis.Length; i++ )
         {
            if( fi.LastWriteTimeUtc <= fis[ i ].LastWriteTimeUtc )
            {
               fi = fis[ i ];
            }
         }
         return fi;
      }

      public static System.IO.FileInfo GetLastWrittenSQLiteFileInfo()
      {
         string s = "*." + Global.DataStoreCollectionBaseName + Global.FileExtensionSQLite;
         System.IO.DirectoryInfo di = new System.IO.DirectoryInfo( Global.DataStoreCollectionPathName );
         System.IO.FileInfo[ ] fis = di.GetFiles( s, System.IO.SearchOption.TopDirectoryOnly );
         if( fis.Length == 0 )
         {
            return null;
         }
         System.IO.FileInfo fi = fis[ 0 ];
         for( int i = 1; i < fis.Length; i++ )
         {
            if( fi.LastWriteTimeUtc <= fis[ i ].LastWriteTimeUtc )
            {
               fi = fis[ i ];
            }
         }
         return fi;
      }
   }
}
