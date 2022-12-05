using System;
using System.IO;

namespace FolderSyncTestApp
{
    delegate void EventSourcerObserver(ItemNotification item);

    class EventSourcer
    {
        private FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
        private String myFolder;

        public EventSourcerObserver EventNotifier;


        public EventSourcer(String Folder)
        {
            myFolder = Folder;
            fileSystemWatcher.Created += new FileSystemEventHandler(ItemCreated);
            fileSystemWatcher.Changed += new FileSystemEventHandler(ItemChanged);
            fileSystemWatcher.Deleted += new FileSystemEventHandler(ItemDeleted);
            fileSystemWatcher.Renamed += new RenamedEventHandler(ItemRenamed);
        }

        public void Start()
        {
            fileSystemWatcher.Path = myFolder;
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            fileSystemWatcher.EnableRaisingEvents = false;
        }

        private void ItemCreated(object sender, FileSystemEventArgs e)
        {
            EventNotifier?.Invoke(ItemNotificationFactory.GetNotification(ItemAction.CREATE, e));
        }

        private void ItemChanged(object sender, FileSystemEventArgs e)
        {
            EventNotifier?.Invoke(ItemNotificationFactory.GetNotification(ItemAction.CHANGE, e));
        }

        private void ItemDeleted(object sender, FileSystemEventArgs e)
        {
            EventNotifier?.Invoke(ItemNotificationFactory.GetNotification(ItemAction.DELETE, e));
        }

        private void ItemRenamed(object sender, RenamedEventArgs e)
        {
            EventNotifier?.Invoke(ItemNotificationFactory.GetNotification(ItemAction.RENAME, e));
        }
    }
}
