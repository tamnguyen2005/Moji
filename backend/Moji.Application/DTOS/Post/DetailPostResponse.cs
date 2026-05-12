using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.DTOS.Post
{
    public class DetailPostResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public List<string> Images { get; set; }= new List<string>();
        public int SellerId {  get; set; }
        public string SellerName {  get; set; }= string.Empty;
    }
}
