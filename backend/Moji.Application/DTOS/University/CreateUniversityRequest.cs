using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Moji.Application.DTOS.University
{
    public class CreateUniversityRequest
    {
        [Required]
        public string Name {  get; set; }=string.Empty;
        [Required]
        public string ShortName {  get; set; }=string.Empty;
    }
}
