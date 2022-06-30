using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGames.Application.Common.Exceptions
{
    public class GenreDoesNotExist : Exception
    {
        public GenreDoesNotExist(IEnumerable<string> genres)
    : base($"Жанр \"{String.Join(", ", genres)}\" не существует") { }
    }
}
