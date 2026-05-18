using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.DTOS.Post
{
    public class PostResponse
    {
        public int Id {  get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price {  get; set; }
        public string Image {  get; set; }=string.Empty;
        public string Status {  get; set; }= string.Empty;
        public string CategoryName {  get; set; } = string.Empty;
        public string Location {  get; set; } = string.Empty;
    }
}
