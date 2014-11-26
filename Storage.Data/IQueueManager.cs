
using StorageSync.IO.File;
using System.Collections.Generic;
namespace StorageSync.Watcher
{
    public class QueueManager : IQueueManager
    {
        private IQueueProvider _queueProvider;
        public QueueManager(IQueueProvider queueProvider)
        {
            _queueProvider = queueProvider;
        }
        public ChangeFileContext AddToQueue(ChangeFileContext fileContext)
        {            
            return null;    
        }
        public ChangeFileContext UpdateQueue(ChangeFileContext fileContext)
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
