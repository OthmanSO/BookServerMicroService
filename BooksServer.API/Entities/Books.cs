using System;


namespace BooksServer.API.Entities
{
    public class Books 
    {
        [Key]
        public Guid BookId { get; set; }
        [Required]
        public int price { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public string category { get; set; }
    }
}