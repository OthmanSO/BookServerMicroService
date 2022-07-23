using System;

namespace BooksServer.API.Models
{
    public class BookAsInfoDto
    {
        public String title { get; set; }
        public int? quantity { get; set; }
        public int? price { get; set; }
    }
}