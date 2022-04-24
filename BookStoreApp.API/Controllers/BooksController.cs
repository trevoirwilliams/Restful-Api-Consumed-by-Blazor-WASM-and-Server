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

    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _repository;
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BooksController(IBooksRepository Repository, IMapper mapper, BookStoreDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _repository = Repository;
            _mapper = mapper;
            this._context= context;
            this._webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReadOnlyDto>>>  GetBooks()
        {
            var books = await _repository.GetAllAsync<BookReadOnlyDto>();
            return Ok(books);
     
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookReadOnlyDto>> GetBook(int id)
        {
            var book = await _repository.GetAsync<BookDetailsDto>(id);
            return Ok(book);

        }


        [HttpGet("GetBookDetails/{id}")]
        public async Task<ActionResult<BookDetailsDto>> GetBookDetails(int id)
        {
            var book = await _repository.GetDetails(id);
            return Ok(book);

        }


        // PUT: api/Books/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BookCreateDto>> PostBook(BookCreateDto bookDto)
        {

    
           var  book = await _repository.AddAsync<BookCreateDto, BookReadOnlyDto>(bookDto);
            book.Image = CreateFile(bookDto.ImageData, bookDto.OriginalImageName);

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        private string CreateFile(string imageBase64, string imageName)
        {
            var url = HttpContext.Request.Host.Value;
            var ext = Path.GetExtension(imageName);
            var fileName = $"{ Guid.NewGuid()}.{ext}";
            var path = $"{_webHostEnvironment.WebRootPath}\\bookcoverimages\\{fileName}";
       
            byte[] image = Convert.FromBase64String(imageBase64);
            var fileStream = System.IO.File.Create(path);
            fileStream.Write(image, 0, image.Length);
            fileStream.Close();

            return $"http://{url}/bookcoverimages/{fileName}";
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
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
