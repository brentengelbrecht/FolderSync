using System;

namespace FolderSyncTestApp
{
    public class ItemChangeNotification : ItemNotification
    {
        private ItemAction itemAction;

        public ItemChangeNotification(String BasePath, String Name, String FullPath) : base(BasePath, Name, FullPath)
        {
            itemAction = ItemAction.CHANGE;
        }
    }
}
