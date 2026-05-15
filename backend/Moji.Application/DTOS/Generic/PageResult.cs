using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.DTOS.Generic
{
    public class PageResult<T> where T : class
    {
        public List<T> Items { get; set; } = [];
        public int TotalCount {  get; set; }
        public int PageNumber {  get; set; }
        public int PageSize {  get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
