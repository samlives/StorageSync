using StorageSync.IO.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSync.Watcher
{
    public class WinFileWatcher
    {
        private FileSystemWatcher _fileSystemWatcher;
        private string _folder=string.Empty;
        private string _filter=string.Empty;
        private Delegate _onChange;

        public WinFileWatcher(string folder,string filter)
        {
            this._folder = folder;
            this._filter = filter;
            this._fileSystemWatcher = new FileSystemWatcher();
        }

        public void StartWatching()
        {
            this._fileSystemWatcher.EnableRaisingEvents = true;
            this._fileSystemWatcher.Path = this._folder;
            this._fileSystemWatcher.Filter = this._filter;
            this._fileSystemWatcher.WaitForChanged(WatcherChangeTypes.All);
            this._fileSystemWatcher.Changed += new FileSystemEventHandler(TrackChanged);
            this._fileSystemWatcher.Created += new FileSystemEventHandler(TrackChanged);
            this._fileSystemWatcher.Deleted += new FileSystemEventHandler(TrackChanged);
            this._fileSystemWatcher.Renamed += new RenamedEventHandler(TrackRenamed);
        }

        void TrackRenamed(object sender, RenamedEventArgs e)
        {
            if (OnChange != null) {
                ChangeFileContext _changeFileContext = new ChangeFileContext
                {
                    ChangeType = (ChangeTypes)e.ChangeType,
                    FullPath=e.FullPath,
                    OldFullPath=e.OldFullPath,
                    Name=e.Name,
                    OldName=e.OldName
                };
                OnChange.DynamicInvoke(sender, _changeFileContext);
            }
        }

        void TrackChanged(object sender, FileSystemEventArgs e)
        {
            if (OnChange != null)
            {
                ChangeFileContext _changeFileContext = new ChangeFileContext
                {
                    ChangeType = (ChangeTypes)e.ChangeType,
                    FullPath = e.FullPath,                   
                    Name = e.Name
                };
                OnChange.DynamicInvoke(sender, _changeFileContext);
            }
        }
       
        public Delegate OnChange {
            get { return _onChange; }
            set { _onChange = value; }
        }





    }
}
