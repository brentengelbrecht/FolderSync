using System.Collections.Generic;

namespace FolderSyncTestApp
{
    public class Propagator
    {
        private IReplica replica;
        private Queue<ItemNotification> events;

        public int EventCount
        {
            get
            {
                return events.Count;
            }
        }

        public Propagator(IReplica replica)
        {
            this.replica = replica;
            events = new Queue<ItemNotification>();
        }

        public void Accept(ItemNotification Event)
        {
            events.Enqueue(Event);
            Delegate(Event);
        }

        private void Delegate(ItemNotification Event)
        {
            if (Event.GetType() == typeof(ItemCreateNotification))
                replica.HandleCreate(Event as ItemCreateNotification);
            else if (Event.GetType() == typeof(ItemChangeNotification))
                replica.HandleChange(Event as ItemChangeNotification);
            else if (Event.GetType() == typeof(ItemDeleteNotification))
                replica.HandleDelete(Event as ItemDeleteNotification);
            else
                replica.HandleRename(Event as ItemRenameNotification);
        }
    }
}
