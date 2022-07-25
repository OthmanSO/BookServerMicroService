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
        public BooksController(BooksRepository br, IMapper mapper)
        {
            _bookRepo = br ?? throw new ArgumentNullException(nameof(BooksRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookRepo.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookAsInfoDto>(book));
        }

        [HttpGet("category/{category}")]
        public IActionResult GetBookByCategory(string? category)
        {
            var books = _bookRepo.GetBookByCategory(category);
            if (!books.Any())
                return NotFound("No books found in this category");

            return Ok(_mapper.Map<IEnumerable<BookAsItemDto>>(books));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookAsInfoDto>> modifyBook(int id, [FromBody]BookAsInfoDto book)
        {
            var bookfromDb = _bookRepo.GetBook(id);
            if (bookfromDb == null)
                return NotFound();

            bookfromDb.quantity = book.quantity;
            _bookRepo.UpdateBook(bookfromDb);
            return Accepted();
        }
    }
}