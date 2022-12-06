using System;
using System.ServiceProcess;
using FolderSyncTestApp;

namespace FolderSync
{
    public partial class FolderSyncService : ServiceBase
    {
        private Configuration configuration;
        private EventSourcer eventSourcer;
        private Propagator propagator;
        private WindowsEventLog windowsEventLog;

        public FolderSyncService()
        {
            InitializeComponent();

            windowsEventLog = new WindowsEventLog("Application");
            configuration = new Configuration(windowsEventLog);
            propagator = new Propagator(new LocalFolderReplica(configuration.TargetPath));
            eventSourcer = new EventSourcer(configuration.SourcePath);
            eventSourcer.EventNotifier += new EventSourcerObserver(EventNotifier);
        }

        protected override void OnStart(string[] args)
        {
            windowsEventLog.LogToInfo("Started monitoring path " + configuration.SourcePath);
            eventSourcer.Start();
        }

        protected override void OnStop()
        {
            eventSourcer.Stop();
            windowsEventLog.LogToInfo("Stopped monitoring path " + configuration.SourcePath);
        }

        private void EventNotifier(ItemNotification item)
        {
            windowsEventLog.LogToInfo("Filesystem Event: " + item.ItemType.ToString() + " " + item.Name + " (" + item.FullPath + ")");
            propagator.Accept(item);
        }
    }
}
