using System;

namespace FolderSyncTestApp
{
    public class ItemRenameNotification : ItemNotification
    {
        private ItemAction itemAction;

        private String newName;
        public String NewName
        {
            get 
            {
                return newName;
            }
        }

        private String newPath;
        public String NewPath
        {
            get
            {
                return newPath;
            }
        }


        public ItemRenameNotification(String BasePath, String NewName, String NewPath, String Name, String FullPath) : base(BasePath, Name, FullPath)
        {
            itemAction = ItemAction.RENAME;
            newName = NewName;
            newPath = NewPath;
        }
    }
}
