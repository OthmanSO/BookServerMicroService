using BooksServer.API.Repository;
using BooksServer.API.Entities;
using BooksServer.API.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksServer.API.Controllers
{
    [ApiController]
    [Route("api/Books")]
    public class BooksController : ControllerBase
    {
        private readonly BooksRepository _bookRepo;
        private readonly IMapper _mapper;
        private readonly IBookSyncRepository _bookSync;
        public BooksController(BooksRepository br, IBookSyncRepository bs, IMapper mapper)
        {
            _bookRepo = br ?? throw new ArgumentNullException(nameof(BooksRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
            _bookSync = bs ?? throw new ArgumentNullException(nameof(IBookSyncRepository));
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookRepo.GetBook(id);
            if (book == null)
            {
                var err = new ErrorCode();
                err.MessageError = "No books found";
                return NotFound(err);
            }
            return Ok(_mapper.Map<BookAsInfoDto>(book));
        }

        [HttpGet("category/{category}")]
        public IActionResult GetBookByCategory(string? category)
        {
            var books = _bookRepo.GetBookByCategory(category);
            if (!books.Any())
            {
                var err = new ErrorCode();
                err.MessageError = "No books found in this category";
                return NotFound(err);
            }
            return Ok(_mapper.Map<IEnumerable<BookAsItemDto>>(books));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookAsInfoDto>> modifyBook(int id, [FromBody]BookAsInfoDto book)
        {
            var bookfromDb = _bookRepo.GetBook(id);
            if (bookfromDb == null)
            {
                var err = new ErrorCode();
                err.MessageError = "No books found";
                return NotFound(err);
            }
            bookfromDb.quantity = book.quantity;
            _bookRepo.UpdateBook(bookfromDb);
            _bookSync.SyncOut(bookfromDb);
            return Accepted();
        }

        [HttpPost()]
        public async Task<ActionResult<BookAsInfoDto>> SyncBook([FromBody]Books book)
        {
            var bookfromDb = _bookRepo.GetBook(book.bookId);
            bookfromDb.quantity = book.quantity;
            _bookRepo.UpdateBook(bookfromDb);
            return Accepted();
        }
    }
}