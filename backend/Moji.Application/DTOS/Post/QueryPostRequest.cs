using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.DTOS.Post
{
    public class QueryPostRequest
    {
        public string? Title {  get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? UniversityId {  get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
