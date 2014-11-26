using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSync.IO.File
{
    public enum ChangeTypes
    {
        Created = 1,
        Deleted = 2,
        Changed = 4,
        Rename = 8,
        All = 15
    }
}
