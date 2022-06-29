using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGames.Application.VideoGames.Queries.GetVideoGameList
{
    public class VideoGameListVm
    {
        public IList<VideoGameLookupDto> VideoGames { get; set; }

    }
}
