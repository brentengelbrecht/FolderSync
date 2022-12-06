namespace FolderSyncTestApp
{
    public interface IReplica
    {
        void HandleCreate(ItemCreateNotification item);
        void HandleChange(ItemChangeNotification item);
        void HandleDelete(ItemDeleteNotification item);
        void HandleRename(ItemRenameNotification item);
    }
}
