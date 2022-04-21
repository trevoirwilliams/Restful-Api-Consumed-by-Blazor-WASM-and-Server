#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;
using AutoMapper;
using BookStoreApp.API.Contracts;
using Microsoft.AspNetCore.Authorization;
using AutoMapper.QueryableExtensions;
using BookStoreApp.API.Static;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthorsRepository _repository;

        public AuthorsController(BookStoreDbContext context, IMapper mapper, IAuthorsRepository repository)
        {
            _context = context;
            this._mapper = mapper;
            this._repository = repository;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorReadOnlyDto>>> GetAuthors()
        {
            //var authors = _mapper.Map<IEnumerable<AuthorReadOnlyDto>>(await _context.Authors.ToListAsync());
            //return Ok(authors);

            var authors = await _repository.GetAllAsync<AuthorReadOnlyDto>();
            return Ok(authors);

        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorReadOnlyDto>> GetAuthor(int id)
        {
            var author = await _repository.GetAsync<AuthorReadOnlyDto>(id);
            return Ok(author);

         
        }
          
    
        [HttpGet("GetAuthorDetails/{id}")]  
        public async Task<ActionResult<AuthorDetailsDto>> GetAuthorDetails(int id)
        {
            try
            {
                var author = await _context.Authors
                    .Include(q => q.Books)
                    .ProjectTo<AuthorDetailsDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(q => q.Id == id);

                if (author == null)
                {
                    //_logger.LogWarning($"Record Not Found: {nameof(GetAuthor)} - ID: {id}");
                    return NotFound();
                }

                return Ok(author);
            }
            catch (Exception ex)
            {
               // _logger.LogError(ex, $"Error Performing GET in {nameof(GetAuthors)}");
                return StatusCode(500, Messages.Error500Message);
            }
        
        }



        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorUpdateDto authorUpdateDto)
        {
            try
            {
                await _repository.UpdateAsync(id, authorUpdateDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AuthorExists(id))
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

        // POST: api/Authors
        [HttpPost]
        public async Task<ActionResult<AuthorCreateDto>> PostAuthor(AuthorCreateDto authorDto)
        {
            var author = await _repository.AddAsync<AuthorCreateDto, AuthorReadOnlyDto>(authorDto);

            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);

        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _repository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> AuthorExists(int id)
        {
            return await _repository.Exists(id);
        }
    }
}
