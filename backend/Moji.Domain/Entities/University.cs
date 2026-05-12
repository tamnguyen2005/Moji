using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Domain.Entities
{
    public class University
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string ShortName {  get; set; }= string.Empty;
        public virtual List<User> Users { get; set; }= new List<User>();
        public virtual List<Post> Posts { get; set; }=new List<Post>();
    }
}
