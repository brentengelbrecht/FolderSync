using System;
using System.IO;

namespace FolderSyncTestApp
{
    class ItemNotificationFactory
    {
        static public ItemNotification GetNotification(ItemAction Action, FileSystemEventArgs e) 
        {
            switch (Action) 
            {
                case ItemAction.CREATE:
                    return new ItemCreateNotification(e.Name, e.FullPath);
                case ItemAction.CHANGE:
                    return new ItemChangeNotification(e.Name, e.FullPath);
                case ItemAction.DELETE:
                    return new ItemDeleteNotification(e.Name, e.FullPath);
            }

            throw new NotImplementedException("No implementation for ItemAction");
        }

        static public ItemNotification GetNotification(ItemAction Action, RenamedEventArgs e)
        {
            return new ItemRenameNotification(e.Name, e.FullPath, e.OldName, e.OldFullPath);
        }
    }
}
