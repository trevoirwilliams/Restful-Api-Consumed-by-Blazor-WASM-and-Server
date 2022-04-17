using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Book;

namespace BookStoreApp.API.Contracts
{
    public interface IBooksRepository : IGenericRepository<Book>
    {
        Task <BookReadOnlyDto> GetDetails(int id);

    }
}