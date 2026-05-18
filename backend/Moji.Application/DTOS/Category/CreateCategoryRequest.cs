using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Moji.Application.DTOS.Category
{
    public class CreateCategoryRequest
    {
        [Required]
        public string Name {  get; set; }=string.Empty;
        [Required]
        public IFormFile Image {  get; set; }
    }
}
