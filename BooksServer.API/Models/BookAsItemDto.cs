using System;

namespace BooksServer.API.Models
{
    public class BookAsItemDto
    {
        public Guid id { get; set; }
        public String? name { get; set; }
    }
}