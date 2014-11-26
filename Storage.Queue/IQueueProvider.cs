using StorageSync.IO.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageSync.Watcher
{
    public interface IQueueProvider
    {
        bool AddToQueue(ChangeFileContext fileContext);
        bool UpdateToQueue(ChangeFileContext fileContext);
    }
}
