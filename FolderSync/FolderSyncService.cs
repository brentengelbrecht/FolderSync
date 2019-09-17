using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FolderSync
{
    public partial class FolderSyncService : ServiceBase
    {
        FolderNotification folderNotification;

        public FolderSyncService()
        {
            InitializeComponent();

            fileSystemWatcher.Changed += folderNotification.handleChanged;
            fileSystemWatcher.Created += folderNotification.handleCreated;
            fileSystemWatcher.Deleted += folderNotification.handleDeleted;
            fileSystemWatcher.Renamed += folderNotification.handleRenamed;
        }

        protected override void OnStart(string[] args)
        {
            if (fileSystemWatcher.Path != "")
            {
                fileSystemWatcher.EnableRaisingEvents = true;
            }
        }

        protected override void OnStop()
        {
            fileSystemWatcher.EnableRaisingEvents = false;
        }
    }
}
