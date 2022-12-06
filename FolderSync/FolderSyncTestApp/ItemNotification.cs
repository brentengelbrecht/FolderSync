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

        private String basePath;
        private String relativePath;
        public String RelativePath
        {
            get
            {
                return relativePath;
            } 
        }

        private ItemType itemType;
        public ItemType ItemType
        {
            get 
            {
                return itemType;
            }
        }

        public ItemNotification(String BasePath, String Name, String FullPath)
        {
            basePath = BasePath;
            this.Name = Name;
            this.FullPath = FullPath;

            BuildRelativePath();

            if (IsDirectory(FullPath))
            {
                itemType = ItemType.FOLDER;
            }
            else
            {
                itemType = ItemType.FILE;
            }
        }

        private void BuildRelativePath()
        {
            if (FullPath.Length > basePath.Length && FullPath.StartsWith(basePath))
            {
                relativePath = FullPath.Remove(FullPath.Length - Name.Length).Substring(basePath.Length);
                return;
            }
            relativePath = "";
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
