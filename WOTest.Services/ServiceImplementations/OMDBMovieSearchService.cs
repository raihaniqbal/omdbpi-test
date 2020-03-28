using OMDbApiNet;
using OMDbApiNet.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace WOTest.Services.ServiceImplementations
{
    public class OMDBMovieSearchService
    {
        private OmdbClient _apiClient;

        public OMDBMovieSearchService(string key)
        {
            _apiClient = new OmdbClient(key);
        }

        public Item SearchByImdbId(string id)
        {
            return _apiClient.GetItemById(id);
        }

        public SearchList SearchByTitle(string query)
        {
            return _apiClient.GetSearchList(query);
        }
    }
}
