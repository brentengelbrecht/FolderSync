using System;

namespace FolderSyncTestApp
{
    public class ItemCreateNotification : ItemNotification
    {
        private ItemAction itemAction; 

        public ItemCreateNotification(String Name, String FullPath) : base(Name, FullPath)
        {
            itemAction = ItemAction.CREATE;
        }
    }
}
