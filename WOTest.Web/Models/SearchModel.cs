using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WOTest.Core.Extensions;

namespace WOTest.Web.Models
{
    public class SearchModel
    {
        public string SearchText { get; set; }
        public PaginatedList<SearchResultModel> SearchResults { get; set; }
        public string JsonLdSchema { get; set; }

        public SearchModel()
        {
        }
    }

    public class SearchResultModel
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string ImdbId { get; set; }
        public string Type { get; set; }
        public string PosterUrl { get; set; }
    }
}
