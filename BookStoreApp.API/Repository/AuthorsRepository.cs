using AutoMapper;
using BookStoreApp.API.Contracts;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;

namespace BookStoreApp.API.Repository
{
    public class AuthorsRepository : GenericRepository<Author>, IAuthorsRepository
    {
        public AuthorsRepository(BookStoreDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

       
    }
}
