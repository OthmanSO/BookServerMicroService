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
            if (id == null)
            {
                return NotFound();
            }
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
            if (category == null)
            {
                return NotFound("category is null");
            }
            var books = _bookRepo.GetBookByCategory(category);
            if (books == null)
            {
                return NotFound("No Books U dumb!");
            }
            return Ok(_mapper.Map<IEnumerable<BookAsItemDto>>(books));
        }
        [HttpPut("{id}")]
        public IActionResult modifyBook(int id , BookAsInfoDto book)
        {
            if (id == null || book == null)
            {
                return NotFound();
            }
            var bookfromDb = _bookRepo.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            bookfromDb = _mapper.Map<Books>(book);
            _bookRepo.UpdateBook(bookfromDb);
            return Accepted();
        }
    }
}