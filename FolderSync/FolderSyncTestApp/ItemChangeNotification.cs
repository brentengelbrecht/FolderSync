using System;

namespace FolderSyncTestApp
{
    public class ItemChangeNotification : ItemNotification
    {
        private ItemAction itemAction;

        public ItemChangeNotification(String Name, String FullPath) : base(Name, FullPath)
        {
            itemAction = ItemAction.CHANGE;
        }
    }
}
