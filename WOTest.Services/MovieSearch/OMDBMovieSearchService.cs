using OMDbApiNet;
using OMDbApiNet.Model;
using System;
using System.Collections.Generic;
using System.Text;
using WOTest.Core.DTO;
using WOTest.Core.Interfaces;
using WOTest.Services.ObjectMapping;

namespace WOTest.Services.MovieSearch
{
    public class OMDBMovieSearchService : IMovieSearchService
    {
        private OmdbClient _apiClient;

        public OMDBMovieSearchService(string key)
        {
            _apiClient = new OmdbClient(key);
        }

        public MovieDetailDto SearchByImdbId(string id)
        {
            var item = _apiClient.GetItemById(id);

            return Mapping.Mapper.Map<MovieDetailDto>(item);
        }

        public MovieSearchResultDto SearchByTitle(string query, int? page)
        {
            try
            {
                var result = _apiClient.GetSearchList(query, page ?? 1);

                return Mapping.Mapper.Map<MovieSearchResultDto>(result);
            }
            catch(Exception ex)
            {
                return new MovieSearchResultDto { Error = ex.Message };
            }
        }
    }
}
