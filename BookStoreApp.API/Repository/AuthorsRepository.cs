using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStoreApp.API.Contracts;
using BookStoreApp.API.Data;
using BookStoreApp.API.Exceptions;
using BookStoreApp.API.Models.Author;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Repository
{
    public class AuthorsRepository : GenericRepository<Author>, IAuthorsRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsRepository(BookStoreDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<AuthorReadOnlyDto> GetDetails(int id)
        {
            // include matching hotels for this country
            var author = await _context.Authors.Include(q => q.Books)
                .ProjectTo<AuthorReadOnlyDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (author == null)
            {
                throw new NotFoundException(nameof(GetDetails), id);
            }

            return author;
        }


    }
}