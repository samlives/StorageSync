
using StorageSync.IO.File;
using System.Collections.Generic;
using Storage.Queue;

namespace StorageSync.Watcher
{
    public class QueueManager : IQueueManager
    {
        private IQueueProvider _queueProvider;
        public QueueManager(IQueueProvider queueProvider)
        {
            _queueProvider = queueProvider;
        }
        public QueueFileContext AddToQueue(QueueFileContext fileContext)
        {            
            return null;    
        }
        public QueueFileContext UpdateQueue(QueueFileContext fileContext)
        {
            return null;
        }
        public IList<ChangeFileContext> ReadQueue()
        {
            return null;
        }
    }

    public interface IQueueManager
    {
        ChangeFileContext AddToQueue(ChangeFileContext fileContext);
        ChangeFileContext UpdateQueue(ChangeFileContext fileContext);
        IList<ChangeFileContext> ReadQueue();
    }
}
