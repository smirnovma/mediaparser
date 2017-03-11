using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaParser.BusinessLogic.Types
{
    public class InfoUnit
    {
        public ICollection<VideoInfo> VideoInfoList { get; set; }
        public AudioInfo AudioInfo { get; set; }

        public InfoUnit()
        {
            VideoInfoList = new List<VideoInfo>();
        }
    }
}
