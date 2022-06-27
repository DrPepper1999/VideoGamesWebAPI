using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGames.Domain
{
    public class VideoGameGenre
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<VideoGame> VideoGames { get; set; }
    }
}
