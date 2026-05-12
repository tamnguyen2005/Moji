using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Moji.Application.DTOS.User
{
    public class RegisterRequest
    {
        [Required]
        public string Name {  get; set; }=string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(12)]
        public string Password {  get; set; } = string.Empty;
        [Required]
        public int UniversityId {  get; set; }
    }
}
