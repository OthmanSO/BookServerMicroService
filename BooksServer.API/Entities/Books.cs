using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BooksServer.API.Entities
{
    [Table("Books")]
    public class Books 
    {
        [Key]
        public int bookId { get; set; }
        [Required]
        [MaxLength(200)]
        [Column("title")]
        public string? title{ get; set; }
        [Required]
        public int? price { get; set; }
        [Required]
        public int? quantity { get; set; }
        [Required]
        public string? category { get; set; }
    }
}