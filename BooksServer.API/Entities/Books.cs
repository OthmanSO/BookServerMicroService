using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BooksServer.API.Entities
{
    public class Books 
    {
        [Key]
        public Guid bookId { get; set; }
        [Required]
        [MaxLength(200)]
        public string? bookName;
        [Required]
        public int? price { get; set; }
        [Required]
        public int? quantity { get; set; }
        [Required]
        public string? category { get; set; }
    }
}