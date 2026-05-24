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
        public List<int> UniversityId {  get; set; }=new List<int>();
        public int? PageSize { get; set; }
        public List<int> CategoryId { get; set; } = new List<int>();
        public int? PageNumber { get; set; }
    }
}
