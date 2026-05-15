using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Moji.Application.DTOS.Post
{
    public class CreatePostRequest
    {
        [Required]
        public string Title {  get; set; }=string.Empty;
        [Required]
        public string Description {  get; set; }=string.Empty;
        [Required]
        [Range(0,double.MaxValue)]
        public decimal Price {  get; set; }
        [Required]
        public int CategoryId {  get; set; }
        [Required]
        public List<IFormFile> Images { get; set; }=new List<IFormFile>();
    }
}
