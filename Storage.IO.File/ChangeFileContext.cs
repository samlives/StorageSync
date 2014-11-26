using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageSync.IO.File
{
    public class ChangeFileContext:IDisposable
    {
        private ChangeTypes _changeType;
        
        public ChangeTypes ChangeType 
        {             
            get {return _changeType;}
            set { _changeType = value;}
        }
        private string _name;

        public string  Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _oldName;

        public string OldName
        {
            get { return _oldName; }
            set { _oldName = value; }
        }
        private string _fullPath;

        public string FullPath
        {
            get { return _fullPath; }
            set { _fullPath = value; }
        }

        private string _oldfullPath;

        public string OldFullPath
        {
            get { return _oldfullPath; }
            set { _oldfullPath = value; }
        }

        public void Dispose()
        {
            
        }
    }
  
}
