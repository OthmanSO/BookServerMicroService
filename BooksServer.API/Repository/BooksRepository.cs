using System;
using System.Linq;
using BooksServer.API.DbContexts;
using BooksServer.API.Entities;
using System.Collections.Generic;

namespace BooksServer.API.Repository
{
    public class BooksRepository
    {
        private readonly BooksDbContexst _context;
        public BooksRepository(BooksDbContexst context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Books GetBook(int book)
        {
            return _context.Books
                .Where(b => b.bookId == book).FirstOrDefault();
        }
        public IEnumerable<Books> GetBookByCategory(string? category)
        {
            return _context.Books
                .Where(b => b.category == category).ToList();
        }
        public void UpdateBook(Books book)
        {
            var b = GetBook(book.bookId);
            if(b!=null)
            {
                b.quantity = book.quantity;
                _context.SaveChanges();
            }
        }
    }
}