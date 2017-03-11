using MediaParser.BusinessLogic.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExtractor;

namespace MediaParser.BusinessLogic.YoutubeBL
{
    public class YoutubeLogic
    {
        public InfoUnit GetDownloadUrls(string link)
        {
            if (link == string.Empty)
                return null;

            InfoUnit infoUnit = new InfoUnit();

            IEnumerable<YoutubeExtractor.VideoInfo> infoList = DownloadUrlResolver.GetDownloadUrls(link);
            foreach (var item in infoList.Where(p => p.Resolution >= 144 && p.AudioExtension != null))
            {
                if(item.RequiresDecryption)
                {
                    DownloadUrlResolver.DecryptDownloadUrl(item);
                }
                infoUnit.VideoInfoList.Add(
                    new Types.VideoInfo { Title = item.Title, Format = item.VideoExtension.ToString(), Resolution = item.Resolution, DownloadURL = item.DownloadUrl + "&title=" + item.Title}
                    );
            }

            var audioMaxBitrate = infoList.Where(p => p.CanExtractAudio).OrderByDescending(p => p.AudioBitrate).FirstOrDefault();

            if (audioMaxBitrate != null)
            {
                if (audioMaxBitrate.RequiresDecryption)
                {
                    DownloadUrlResolver.DecryptDownloadUrl(audioMaxBitrate);
                }
                infoUnit.AudioInfo = new AudioInfo { Title = audioMaxBitrate.Title, Format = audioMaxBitrate.AudioType.ToString(), BitRate = audioMaxBitrate.AudioBitrate, DownloadURL = audioMaxBitrate.DownloadUrl };
            }
            return infoUnit;
        }
    }
}
