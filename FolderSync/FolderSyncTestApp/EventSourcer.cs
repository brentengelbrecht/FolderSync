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
            if (myFolder.EndsWith("\\"))
            {
                myFolder = myFolder.Remove(myFolder.Length);
            }

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
            EventNotifier?.Invoke(ItemNotificationFactory.GetNotification(ItemAction.CREATE, myFolder + "\\", e));
        }

        private void ItemChanged(object sender, FileSystemEventArgs e)
        {
            EventNotifier?.Invoke(ItemNotificationFactory.GetNotification(ItemAction.CHANGE, myFolder + "\\", e));
        }

        private void ItemDeleted(object sender, FileSystemEventArgs e)
        {
            EventNotifier?.Invoke(ItemNotificationFactory.GetNotification(ItemAction.DELETE, myFolder + "\\", e));
        }

        private void ItemRenamed(object sender, RenamedEventArgs e)
        {
            EventNotifier?.Invoke(ItemNotificationFactory.GetNotification(ItemAction.RENAME, myFolder + "\\", e));
        }
    }
}
