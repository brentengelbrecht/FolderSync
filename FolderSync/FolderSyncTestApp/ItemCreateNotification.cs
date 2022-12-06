using System;

namespace FolderSyncTestApp
{
    public class ItemCreateNotification : ItemNotification
    {
        private ItemAction itemAction; 

        public ItemCreateNotification(String BasePath, String Name, String FullPath) : base(BasePath, Name, FullPath)
        {
            itemAction = ItemAction.CREATE;
        }
    }
}
