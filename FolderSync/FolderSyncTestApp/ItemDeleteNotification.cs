using System;

namespace FolderSyncTestApp
{
    public class ItemDeleteNotification : ItemNotification
    {
        private ItemAction itemAction;

        public ItemDeleteNotification(String Name, String FullPath) : base(Name, FullPath)
        {
            itemAction = ItemAction.DELETE;
        }
    }
}
