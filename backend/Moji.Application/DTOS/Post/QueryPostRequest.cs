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
        public int? PageSize { get; set; }
        public int? CategoryId { get; set; }
        public int? PageNumber { get; set; }
    }
}
