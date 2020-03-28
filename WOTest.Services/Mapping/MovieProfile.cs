using AutoMapper;
using OMDbApiNet.Model;
using System;
using System.Collections.Generic;
using System.Text;
using WOTest.Core.DTO;

namespace WOTest.Services.ObjectMapping
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<SearchItem, MovieSummaryDto>();

            CreateMap<SearchList, MovieSearchResultDto>()
                .ForMember(d => d.SearchResults, o => o.MapFrom(s => s.SearchResults))
                .ForMember(d => d.TotalResults, o => o.MapFrom(s => int.Parse(s.TotalResults)))
                .ForMember(d => d.Response, o => o.MapFrom(s => s.Response))
                .ForMember(d => d.Error, o => o.MapFrom(s => s.Error));

            CreateMap<Item, MovieDetailDto>();
        }
    }
}
