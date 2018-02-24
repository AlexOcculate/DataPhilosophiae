using SSHTunnelWF;

namespace ConfigurationSetting
{
   static partial class Program
   {
      private static System.Configuration.Configuration cm = System.Configuration.ConfigurationManager.OpenExeConfiguration( System.Configuration.ConfigurationUserLevel.None );
      private static System.Configuration.KeyValueConfigurationCollection confColl = cm.AppSettings.Settings;
      private static System.Collections.Specialized.NameValueCollection appSettings = System.Configuration.ConfigurationManager.GetSection( "ApplicationSettings" ) as System.Collections.Specialized.NameValueCollection;

      [System.STAThread]
      static void Main()
      {
         try
         {
            DataPhilosophiaeSection dps = cm.GetSection( "DataPhilosophiaeSection" ) as DataPhilosophiaeSection;
            if( dps != null )
            {
               System.Console.WriteLine( dps.Stage.PathDir );
               foreach( DataStoreElement ds in dps.DataStores )
               {
                  System.Console.WriteLine( ds.Name );
                  System.Console.WriteLine( ds.LoadDefaultDatabaseOnly );
                  System.Console.WriteLine( ds.LoadSystemObjects );
                  System.Console.WriteLine( ds.WithFields );
                  if( string.IsNullOrWhiteSpace( ds.PathDir ) )
                  {
                     ds.PathDir = System.IO.Path.Combine( dps.Stage.PathDir, ds.Name );
                     cm.Save( System.Configuration.ConfigurationSaveMode.Minimal, true );
                  }
                  System.Console.WriteLine( ds.PathDir );
               }
            }
            //DataStoreElement dse = new DataStoreElement(  );
            //cm.Save( System.Configuration.ConfigurationSaveMode.Minimal, false );
         }
         catch( System.Configuration.ConfigurationErrorsException ex )
         {
            System.Console.WriteLine( ex.Message );
         }
         try
         {
            System.Configuration.ConnectionStringSettingsCollection settings = System.Configuration.ConfigurationManager.ConnectionStrings;
            if( settings != null )
            {
               foreach( System.Configuration.ConnectionStringSettings cs in settings )
               {
                  System.Console.WriteLine( "            Name:" + cs.Name );
                  System.Console.WriteLine( "    ProviderName:" + cs.ProviderName );
                  System.Console.WriteLine( "ConnectionString:" + cs.ConnectionString );
               }
            }
         }
         catch( System.Configuration.ConfigurationErrorsException ex )
         {
            System.Console.WriteLine( ex.Message );
         }
         {
            DataPhilosophiaeSection dps = cm.GetSection( "DataPhilosophiaeSection" ) as DataPhilosophiaeSection;
            DataStoreElement ds = dps.DataStores[ 0 ];
            System.Configuration.ConnectionStringSettingsCollection settings = System.Configuration.ConfigurationManager.ConnectionStrings;
            System.Configuration.ConnectionStringSettings cs = settings[ ds.ConnectionStringName ];
            //

            ActiveQueryBuilder.Core.SyntaxProviderList syntaxProviderList = new ActiveQueryBuilder.Core.SyntaxProviderList( );
            ActiveQueryBuilder.Core.SQLContext sc = new ActiveQueryBuilder.Core.SQLContext( )
            {
               SyntaxProvider = new ActiveQueryBuilder.Core.AutoSyntaxProvider( ),
               MetadataProvider = new ActiveQueryBuilder.Core.OLEDBMetadataProvider
               {
                  Connection = new System.Data.OleDb.OleDbConnection( )
                  {
                     ConnectionString = cs.ConnectionString
                  }
               }
            };
         }
         {
            DataPhilosophiaeSection dps = cm.GetSection( "DataPhilosophiaeSection" ) as DataPhilosophiaeSection;
            DataStoreElement ds = dps.DataStores[ 0 ];
            System.Configuration.ConnectionStringSettingsCollection settings = System.Configuration.ConfigurationManager.ConnectionStrings;
            System.Configuration.ConnectionStringSettings cs = settings[ ds.ConnectionStringName ];
            //
            ActiveQueryBuilder.Core.SyntaxProviderList syntaxProviderList = new ActiveQueryBuilder.Core.SyntaxProviderList( );
            ActiveQueryBuilder.Core.SQLContext sc = new ActiveQueryBuilder.Core.SQLContext( )
            {
               SyntaxProvider = new ActiveQueryBuilder.Core.SQLiteSyntaxProvider( ),
               MetadataProvider = new ActiveQueryBuilder.Core.SQLiteMetadataProvider( )
               {
                  Connection = new System.Data.SQLite.SQLiteConnection( )
                  {
                     ConnectionString = cs.ConnectionString
                  }
               }
            };
            ActiveQueryBuilder.Core.MetadataLoadingOptions loadingOptions = sc.MetadataContainer.LoadingOptions;
            loadingOptions.LoadDefaultDatabaseOnly = ds.LoadDefaultDatabaseOnly == 1 ? true : false;
            loadingOptions.LoadSystemObjects = ds.LoadSystemObjects == 1 ? true : false;
            //loadingOptions.IncludeFilter.Types = MetadataType.Field;
            //loadingOptions.ExcludeFilter.Schemas.Add(“dbo”);
            sc.MetadataContainer.LoadAll( ds.WithFields == 1 ? true : false );
         }

         //TunnelSection ts = System.Configuration.ConfigurationManager.GetSection( "TunnelSection" ) as TunnelSection;
         TunnelSection ts = cm.GetSection( "TunnelSection" ) as TunnelSection;
         int count1 = ts.Tunnels.Count;
         HostConfigElement hc = ts.Tunnels[ 0 ];
         string sSHServerHostname = hc.SSHServerHostname;
         string username = hc.Username;
         TunnelCollection tunnels = hc.Tunnels;
         int count2 = tunnels.Count;
         TunnelConfigElement tce = tunnels[ 0 ];
         string name = tce.Name;
         int localPort = tce.LocalPort;

         //ProductSettings productSettings = System.Configuration.ConfigurationManager.GetSection( "ProductSettings" ) as ProductSettings;
         //ConfigurationClassLoader x = System.Configuration.ConfigurationManager.GetSection( "Plugins" ) as ConfigurationClassLoader;

         //
         System.Configuration.ConfigurationSectionGroup a = cm.GetSectionGroup( "DataStoreGroup" );
         System.Configuration.ConfigurationSectionCollection sections = a.Sections;
         int count = sections.Count;
         System.Configuration.ConfigurationSection get = sections.Get( 0 );

         //         NewMethod( );
         //
         System.Windows.Forms.Application.EnableVisualStyles( );
         System.Windows.Forms.Application.SetCompatibleTextRenderingDefault( false );
         System.Windows.Forms.Application.Run( new Form1( ) );
      }

      private static void NewMethod()
      {
         // Approach Zero
         System.Collections.IDictionary x = (System.Collections.IDictionary) System.Configuration.ConfigurationManager.GetSection( "sampleSection" );
         if( x.Count > 0 )
         {
            foreach( string key in x.Keys )
            {
               System.Console.WriteLine( key + " = " + x[ key ] );
            }
         }
         /////////////////////////////////////////////////////////////////////

         var qqq = System.Configuration.ConfigurationManager.GetSection( "MySectionGroup" );


         System.Collections.IDictionary stsh = (System.Collections.IDictionary) System.Configuration.ConfigurationSettings.GetConfig( "MySingleTagSection" );
         System.Collections.Specialized.NameValueCollection nvsh = (System.Collections.Specialized.NameValueCollection) System.Configuration.ConfigurationSettings.GetConfig( "MyNameValueSection" );
         System.Collections.Hashtable dsh = (System.Collections.Hashtable) System.Configuration.ConfigurationSettings.GetConfig( "MyDictionarySection" );
         System.Collections.Specialized.NameValueCollection sgnvsh = (System.Collections.Specialized.NameValueCollection) System.Configuration.ConfigurationSettings.GetConfig( "MySectionGroup/MySection1" );

         System.Diagnostics.Debug.WriteLine( (string) stsh[ "sample1" ] );
         System.Diagnostics.Debug.WriteLine( nvsh[ "key1" ] );
         System.Diagnostics.Debug.WriteLine( (string) dsh[ "key1" ] );
         System.Diagnostics.Debug.WriteLine( sgnvsh[ "key1" ] );

         ////////////////////////////////////////////////////////////////////

         // Approach One
         const string DATASTORECOLL_PATH_DIR_CONFIG_KEY_NAME = "DSCOLL_PATHDIR";
         string v;
         try
         {
            v = confColl[ DATASTORECOLL_PATH_DIR_CONFIG_KEY_NAME ].Value;
         }
         catch( System.Exception ex )
         {
            v = System.IO.Path.GetTempPath( );
            confColl.Add( DATASTORECOLL_PATH_DIR_CONFIG_KEY_NAME, v );
            cm.Save( System.Configuration.ConfigurationSaveMode.Minimal );
         }
         // Approach Two
         if( appSettings.Count > 0 )
         {
            foreach( var key in appSettings.AllKeys )
            {
               System.Console.WriteLine( key + " = " + appSettings[ key ] );
            }
         }
         // Approach Three
         var PostSetting = System.Configuration.ConfigurationManager.GetSection( "BlogGroup/PostSetting" ) as System.Collections.Specialized.NameValueCollection;
         if( PostSetting.Count == 0 )
         {
            System.Console.WriteLine( "Post Settings are not defined" );
         }
         else
         {
            foreach( var key in PostSetting.AllKeys )
            {
               System.Console.WriteLine( key + " = " + PostSetting[ key ] );
            }
         }
         // Approach Four
         var productSettings = System.Configuration.ConfigurationManager.GetSection( "ProductSettings" ) as ProductSettings;
         if( productSettings == null )
         {
            System.Console.WriteLine( "Product Settings are not defined" );
         }
         else
         {
            var productNumber = productSettings.DellFeatures.ProductNumber;
            var productName = productSettings.DellFeatures.ProductName;
            var color = productSettings.DellFeatures.Color;
            var warranty = productSettings.DellFeatures.Warranty;

            System.Console.WriteLine( "Product Number = " + productNumber );
            System.Console.WriteLine( "Product Name = " + productName );
            System.Console.WriteLine( "Product Color = " + color );
            System.Console.WriteLine( "Product Warranty = " + warranty );
         }
      }
   }
   /*
   */
}
