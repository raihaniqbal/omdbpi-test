using System;
using System.Collections.Generic;
using System.Text;

namespace WOTest.Core.DTO
{
    public class MovieSearchResultDto
    {
        public List<MovieSummaryDto> SearchResults { get; set; }
        
        public int TotalResults { get; set; }
        
        public string Response { get; set; }
        
        public string Error { get; set; }
    }
}
