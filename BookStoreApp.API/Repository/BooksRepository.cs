using AutoMapper;
using BookStoreApp.API.Contracts;
using BookStoreApp.API.Data;

namespace BookStoreApp.API.Repository
{
    public class BooksRepository : GenericRepository<Book>, IBooksRepository
    {
        public BooksRepository(BookStoreDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
