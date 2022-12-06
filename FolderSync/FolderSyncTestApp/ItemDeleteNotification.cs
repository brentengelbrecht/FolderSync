using System;

namespace FolderSyncTestApp
{
    public class ItemDeleteNotification : ItemNotification
    {
        private ItemAction itemAction;

        public ItemDeleteNotification(String BasePath, String Name, String FullPath) : base(BasePath, Name, FullPath)
        {
            itemAction = ItemAction.DELETE;
        }
    }
}
