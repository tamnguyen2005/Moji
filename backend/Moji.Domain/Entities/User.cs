using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash {  get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public virtual List<Post> Post {  get; set; }=new List<Post>();
        public int UniversityId {  get; set; }
        public University University { get; set; } = null!;
        public virtual List<RefreshToken> RefreshTokens { get; set; }= new List<RefreshToken>();
    }
}
