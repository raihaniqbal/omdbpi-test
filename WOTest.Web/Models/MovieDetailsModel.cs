using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WOTest.Web.Models
{
    public class MovieDetailsModel
    {
        public string ImdbId { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string PosterUrl { get; set; }
        public string ImdbRating { get; set; }
        public string ParentalRating { get; set; }
        public string Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ReleaseCountry { get; set; }
        public string JsonLdSchema { get; set; }
    }
}
