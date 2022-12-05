using System;
using System.IO;

namespace FolderSyncTestApp
{
    public enum ItemType
    {
        FILE, 
        FOLDER
    }


    public enum ItemAction
    {
        CREATE,
        CHANGE,
        DELETE,
        RENAME
    }


    public abstract class ItemNotification
    {
        public String Name { get; set; }
        public String FullPath { get; set; }

        private ItemType itemType;
        public ItemType ItemType
        {
            get 
            {
                return itemType;
            }
        }

        public ItemNotification(String Name, String FullPath)
        {
            this.Name = Name;
            this.FullPath = FullPath;

            if (IsDirectory(FullPath))
            {
                itemType = ItemType.FOLDER;
            }
            else
            {
                itemType = ItemType.FILE;
            }
        }

        private bool IsDirectory(String PathName)
        {
            try 
            {
                FileAttributes attributes = File.GetAttributes(PathName);
                return attributes.HasFlag(FileAttributes.Directory);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
