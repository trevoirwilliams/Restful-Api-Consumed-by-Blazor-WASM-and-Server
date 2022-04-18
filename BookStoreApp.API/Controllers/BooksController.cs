    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.API.Data;
using AutoMapper;
using BookStoreApp.API.Contracts;
using BookStoreApp.API.Models.Book;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _repository;
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext test;

        public BooksController(IBooksRepository Repository, IMapper mapper, BookStoreDbContext test)
        {
            _repository = Repository;
            _mapper = mapper;
            this.test = test;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<BookReadOnlyDto>> GetBooks()
        {
            var books = await _repository.GetAllAsync<BookReadOnlyDto>();
            return Ok(books);
     
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookReadOnlyDto>> GetBook(int id)
        {
            //var book = await _repository.GetAsync<BookDetailsDto>(id);
            //return Ok(book);

            var book = await _repository.GetDetails(id); 

            return Ok(book);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookUpdateDto updateBookDto)
        {
            try
            {
                await _repository.UpdateAsync(id, updateBookDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookCreateDto bookDto)
        {
            var book = await _repository.AddAsync<BookCreateDto, BookReadOnlyDto>(bookDto);

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);

        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _repository.DeleteAsync(id);

            return NoContent();
        }

        private async Task <bool> BookExists(int id)
        {
            return await _repository.Exists(id);
        }
    }
}
