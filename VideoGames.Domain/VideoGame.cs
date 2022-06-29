using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGames.Domain
{
    public class VideoGame
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime RelesesDate { get; set; }
        public double Rating { get; set; }
        public DeveloperStudio DeveloperStudio { get; set; }
        public ICollection<VideoGameGenre> Genres { get; set; }
    }
}
