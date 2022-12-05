namespace FolderSync
{
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ServiceProcess.ServiceInstaller serviceInstaller;
            this.serviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            serviceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceInstaller
            // 
            serviceInstaller.Description = "Replicates file system directory tree at an alternate location";
            serviceInstaller.DisplayName = "Folder Synchronisation Service";
            serviceInstaller.ServiceName = "FolderSyncService";
            // 
            // serviceProcessInstaller
            // 
            this.serviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller.Password = null;
            this.serviceProcessInstaller.Username = null;
            this.serviceProcessInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceProcessInstaller_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller,
            serviceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller;
    }
}