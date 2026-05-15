using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price {  get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        // User who create this post
        public int CreatorId {  get; set; }
        public User Creator { get; set; } = null!;
        // University which this post belong to
        public int UniversityId {  get; set; }
        public University University { get; set; } = null!;
        // Category which this post belong to
        public int CategoryId {  get; set; }
        public Category Category { get; set; }=null!;
        // Images of the product in this post
        public List<Image> Images { get; set; }=new List<Image>();
    }
}
