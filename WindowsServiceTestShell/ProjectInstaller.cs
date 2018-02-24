namespace WindowsServiceTestShell
{
   [System.ComponentModel.RunInstaller( true )]
   public partial class ProjectInstaller : System.Configuration.Install.Installer
   {
      public ProjectInstaller()
      {
         {
            InitializeComponent( );
            this.serviceInstaller1.DisplayName = AppConfig.ServiceInstallerDisplayName;
            this.serviceInstaller1.ServiceName = AppConfig.ServiceInstallerServiceName;
            this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
         }
      }
   }
}
