using System;
using System.IO;

namespace FolderSyncTestApp
{
    class LocalFolderReplica : IReplica
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
        }

        public void HandleCreate(ItemCreateNotification item)
        {
            HandleChange(new ItemChangeNotification(item.Name, item.FullPath));
        }

        public void HandleChange(ItemChangeNotification item)
        {
            String targetPath = buildTargetPath(item.FullPath);

            if (File.Exists(targetPath))
            {
                File.Delete(targetPath);
            }

            File.Copy(item.FullPath, targetPath);
        }

        public void HandleDelete(ItemDeleteNotification item)
        {
            String targetPath = buildTargetPath(item.FullPath);
            if (File.Exists(targetPath))
            {
                File.Delete(targetPath);
            }
        }

        public void HandleRename(ItemRenameNotification item)
        {
            FileInfo source = new FileInfo(item.FullPath);
            String fileToFind = myFolder + "\\" + item.Name;
/*
            if (!File.Exists(item.NewPath))
            {
                File.Move(fileToFind, item.NewPath);
            }*/
        }

        private String buildTargetPath(String sourcePath)
        {
            FileInfo source = new FileInfo(sourcePath);
            return myFolder + "\\" + source.Name;
        }
    }
}
