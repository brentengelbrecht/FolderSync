using System;
using System.IO;

namespace FolderSyncTestApp
{
    class ItemNotificationFactory
    {
        static public ItemNotification GetNotification(ItemAction Action, String BasePath, FileSystemEventArgs e) 
        {
            switch (Action) 
            {
                case ItemAction.CREATE:
                    return new ItemCreateNotification(BasePath, e.Name, e.FullPath);
                case ItemAction.CHANGE:
                    return new ItemChangeNotification(BasePath, e.Name, e.FullPath);
                case ItemAction.DELETE:
                    return new ItemDeleteNotification(BasePath, e.Name, e.FullPath);
            }

            throw new NotImplementedException("No implementation for ItemAction");
        }

        static public ItemNotification GetNotification(ItemAction Action, String BasePath, RenamedEventArgs e)
        {
            return new ItemRenameNotification(BasePath, e.Name, e.FullPath, e.OldName, e.OldFullPath);
        }
    }
}
