using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Schema.NET;
using WOTest.Core.Extensions;
using WOTest.Core.Interfaces;
using WOTest.Services.MovieSearch;
using WOTest.Web.Models;

namespace WOTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieSearchService _movieSearchService;

        public HomeController(IConfiguration config, IMovieSearchService movieSearchService)
        {
            _movieSearchService = movieSearchService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string searchText, int? pageNum)
        {
            SearchModel searchModel = new SearchModel();

            if (!string.IsNullOrEmpty(searchText))
            {
                var response = _movieSearchService.SearchByTitle(searchText, pageNum);
                var searchResults = response.SearchResults;
                var searchResultList = new List<SearchResultModel>();
                var schemaList = new ItemList();
                var movieItemList = new List<IListItem>();
                int position = 1;

                foreach (var result in searchResults)
                {
                    searchResultList.Add(new SearchResultModel
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
                            Url = new Uri(movieDetailsUrl),
                            Image = new Values<IImageObject, Uri>(result.Poster.ToUri())
                        }
                    });
                }

                int pageSize = 10;

                searchModel.SearchText = searchText;
                searchModel.SearchResults = new PaginatedList<SearchResultModel>(searchResultList, response.TotalResults, pageNum ?? 1, pageSize);
                schemaList.ItemListElement = new Values<IListItem, string, IThing>(movieItemList);
                searchModel.JsonLdSchema = schemaList.ToHtmlEscapedString();
            }

            return View("Index", searchModel);
        }

        public IActionResult QuickSearch(string searchText)
        {
            return Json(_movieSearchService.SearchByTitle(searchText, null));
        }

        public IActionResult MovieDetails(string imdbId)
        {
            var item = _movieSearchService.SearchByImdbId(imdbId);
            var movieSchema = new Movie { Name = item.Title,
                                          Genre = item.Genre, Image = new Values<IImageObject, Uri>(item.Poster.ToUri()) };
            
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
                ReleaseDate = item.Released,
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
