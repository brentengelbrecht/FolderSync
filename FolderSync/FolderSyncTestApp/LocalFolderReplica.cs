using System;
using System.IO;

namespace FolderSyncTestApp
{
    public class LocalFolderReplica : IReplica
    {
        private String myFolder;
        public String MyFolder
        {
            get
            {
                return myFolder;
            }
        }

        public LocalFolderReplica(String Folder)
        {
            myFolder = Folder;
            if (myFolder.EndsWith("\\"))
            {
                myFolder = myFolder.Remove(myFolder.Length);
            }
        }

        public void HandleCreate(ItemCreateNotification item)
        {
            String targetPath = BuildTargetPath(item.RelativePath, item.Name);

            if (item.ItemType.Equals(ItemType.FILE))
            {
                if (File.Exists(targetPath))
                {
                    File.Delete(targetPath);
                }

                File.Copy(item.FullPath, targetPath);
            }
            else
            {
                Directory.CreateDirectory(targetPath);
            }
        }

        public void HandleChange(ItemChangeNotification item)
        {
            String targetPath = BuildTargetPath(item.RelativePath, item.Name);

            if (item.ItemType.Equals(ItemType.FILE))
            {
                if (File.Exists(targetPath))
                {
                    File.Delete(targetPath);
                }

                File.Copy(item.FullPath, targetPath);
            }
        }

        public void HandleDelete(ItemDeleteNotification item)
        {
            String targetPath = BuildTargetPath(item.RelativePath, item.Name);

            if (Directory.Exists(targetPath))
            {
                Directory.Delete(targetPath, true);
                return;
            }

            if (File.Exists(targetPath))
            {
                File.Delete(targetPath);
            }
        }

        public void HandleRename(ItemRenameNotification item)
        {
            String fromFile = BuildTargetPath(item.RelativePath, item.Name);
            String toFile = BuildTargetPath(item.RelativePath, item.NewName);

            if (item.ItemType.Equals(ItemType.FILE))
            {
                if (!File.Exists(toFile))
                {
                    File.Move(fromFile, toFile);
                }
            }
            else
            {
                if (!Directory.Exists(toFile))
                {
                    Directory.Move(fromFile, toFile);
                }
            }
        }

        private String BuildTargetPath(String RelativePath, String Name)
        {
            if (String.IsNullOrEmpty(RelativePath))
            {
                return myFolder + "\\" + Name;
            }
            return myFolder + "\\" + RelativePath + "\\" + Name;
        }
    }
}
