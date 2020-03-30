using System;
using System.Collections.Generic;
using System.Text;
using WOTest.Core.DTO;

namespace WOTest.Core.Interfaces
{
    public interface IMovieSearchService
    {
        MovieDetailDto SearchByImdbId(string id);
        MovieSearchResultDto SearchByTitle(string query, int? page);
    }
}
