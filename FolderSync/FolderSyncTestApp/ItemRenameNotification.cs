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


        public ItemRenameNotification(String Name, String FullPath, String NewName, String NewPath) : base(Name, FullPath)
        {
            itemAction = ItemAction.RENAME;
            newName = NewName;
            newPath = NewPath;
        }
    }
}
