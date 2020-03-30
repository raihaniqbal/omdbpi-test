using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WOTest.Web.Models
{
    public class SearchModel
    {
        public string SearchText { get; set; }
        public List<SearhResultModel> SearchResults { get; set; }
        public string JsonLdSchema { get; set; }

        public SearchModel()
        {
            
        }
    }

    public class SearhResultModel
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string ImdbId { get; set; }
        public string Type { get; set; }
        public string PosterUrl { get; set; }
    }
}
