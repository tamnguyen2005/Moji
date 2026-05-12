using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.DTOS.Post
{
    public class CreatePostRequest
    {
        public string Title {  get; set; }=string.Empty;
        public string Description {  get; set; }=string.Empty;
        public decimal Price {  get; set; }
        public int CategoryId {  get; set; }
        public List<IFormFile> Images { get; set; }=new List<IFormFile>();
    }
}
