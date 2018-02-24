using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceTestShell
{
   public class AppConfig
   {
      private System.Configuration.Configuration cm;
      private System.Configuration.KeyValueConfigurationCollection confColl;
      public AppConfig( Configuration cm1, KeyValueConfigurationCollection confColl1 )
      {
         this.cm = cm1;
         this.confColl = confColl1;
      }

      public const string TEMP_PATH_DIR_CONFIG_KEY_NAME = "TEMP_PATHDIR";
      public string TempPathName
      {
         //[System.Diagnostics.DebuggerStepThrough]
         get
         {
            try
            {
               return this.confColl[ TEMP_PATH_DIR_CONFIG_KEY_NAME ].Value;
            }
            catch( System.Exception ex )
            {
               this.confColl.Add( TEMP_PATH_DIR_CONFIG_KEY_NAME, System.IO.Path.GetTempPath( ) );
               this.cm.Save( System.Configuration.ConfigurationSaveMode.Minimal );
               return this.confColl[ TEMP_PATH_DIR_CONFIG_KEY_NAME ].Value;
            }
         }
      }

      public const string DATASTORECOLL_PATH_DIR_CONFIG_KEY_NAME = "DSCOLL_PATHDIR";
      public string DataStoreCollectionPathName
      {
         //[System.Diagnostics.DebuggerStepThrough]
         get
         {
            try
            {
               return this.confColl[ DATASTORECOLL_PATH_DIR_CONFIG_KEY_NAME ].Value;
            }
            catch( System.Exception ex )
            {
               this.confColl.Add( DATASTORECOLL_PATH_DIR_CONFIG_KEY_NAME, System.IO.Path.GetTempPath( ) );
               this.cm.Save( System.Configuration.ConfigurationSaveMode.Minimal );
               return this.confColl[ DATASTORECOLL_PATH_DIR_CONFIG_KEY_NAME ].Value;
            }
         }
      }

      public static string ServiceInstallerServiceName
      {
         //[System.Diagnostics.DebuggerStepThrough]
         get
         {
            return "WindowServiceNamePlaceHolder";
         }
      }
      public static string ServiceInstallerDisplayName
      {
         //[System.Diagnostics.DebuggerStepThrough]
         get
         {
            return "WindowServiceDisplayNamePlaceHolder";
         }
      }
      public static string ServiceLoggerName
      {
         //[System.Diagnostics.DebuggerStepThrough]
         get
         {
            return AppConfig.ServiceInstallerServiceName + "Logger";
         }
      }
      public static string ServiceLoggerSourceName
      {
         //[System.Diagnostics.DebuggerStepThrough]
         get
         {
            return AppConfig.ServiceLoggerName + "Service";
         }
      }
      public static int ServiceInstallerHeartBeat
      {
         //[System.Diagnostics.DebuggerStepThrough]
         get
         {
            return 60 * 60 * 1000;
         }
      }

      public System.ServiceProcess.ServiceStartMode ServiceInstallerStartType
      {
         //[System.Diagnostics.DebuggerStepThrough]
         get
         {
            return System.ServiceProcess.ServiceStartMode.Automatic;
         }
      }

   }
}
