using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Schema.NET;
using WOTest.Services.MovieSearch;
using WOTest.Web.Models;

namespace WOTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly OMDBMovieSearchService _searchService;

        public HomeController(IConfiguration config)
        {
            _searchService = new OMDBMovieSearchService(config["Settings:APIKey"]);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(SearchModel searchModel)
        {
            if (!string.IsNullOrEmpty(searchModel.SearchText))
            {
                var searchResults = _searchService.SearchByTitle(searchModel.SearchText).SearchResults;
                searchModel.SearchResults = new List<SearhResultModel>();
                var schemaList = new ItemList();
                var movieItemList = new List<IListItem>();
                int position = 1;

                foreach (var result in searchResults)
                {
                    searchModel.SearchResults.Add(new SearhResultModel
                    {
                        Title = result.Title,
                        ImdbId = result.ImdbId,
                        Year = result.Year,
                        Type = result.Type,
                        PosterUrl = result.Poster
                    });

                    var movieDetailsUrl = Url.Action("MovieDetails", "Home", new { result.ImdbId }, Url.ActionContext.HttpContext.Request.Scheme);

                    movieItemList.Add(new ListItem
                    {
                        Position = position++,
                        Item = new Schema.NET.Movie
                        {
                            Id = new Uri(movieDetailsUrl),
                            Name = result.Title,
                            Image = new Values<IImageObject, Uri>(new Uri(result.Poster)),
                            Url = new Uri(movieDetailsUrl)
                        }
                    });
                }

                schemaList.ItemListElement = new Values<IListItem, string, IThing>(movieItemList);
                searchModel.JsonLdSchema = schemaList.ToHtmlEscapedString();
            }

            return View("Index", searchModel);
        }

        public IActionResult MovieDetails(string imdbId)
        {
            var item = _searchService.SearchByImdbId(imdbId);
            var movieSchema = new Movie { Name = item.Title,
                                          Genre = item.Genre, Image = new Values<IImageObject, Uri>(new Uri(item.Poster)) };
            
            return View(new MovieDetailsModel
            {
                ImdbId = item.ImdbId,
                Genre = item.Genre,
                Title = item.Title,
                Plot = item.Plot,
                PosterUrl = item.Poster,
                Year = item.Year,
                ParentalRating = item.Rated,
                ImdbRating = item.ImdbRating,
                Runtime = item.Runtime,
                ReleaseDate = DateTime.Parse(item.Released),
                ReleaseCountry = item.Country,
                JsonLdSchema = movieSchema.ToHtmlEscapedString()
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
