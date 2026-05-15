using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int PostId {  get; set; }
        public Post Post { get; set; }=null!;
    }
}
