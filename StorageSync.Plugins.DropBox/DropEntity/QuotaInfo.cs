using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSync.Plugins.DropBox.DropEntity
{
    public class QuotaInfo
    {
        public string Shared { get; set; }
        public string Quota { get; set; }
        public string Normal { get; set; }
    }
}
