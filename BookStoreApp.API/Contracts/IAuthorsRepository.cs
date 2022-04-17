using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;

namespace BookStoreApp.API.Contracts
{
    public interface IAuthorsRepository : IGenericRepository<Author>
    {
        Task<AuthorReadOnlyDto> GetDetails(int id);

    
    }
}
