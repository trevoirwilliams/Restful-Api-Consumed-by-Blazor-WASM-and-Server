namespace BookStoreApp.API.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<TResult> GetAsync<TResult>(int? id);

        Task<List<TResult>> GetAllAsync<TResult>();

        Task<TResult> AddAsync<TSource, TResult>(TSource source);

        Task UpdateAsync<TSource>(int id, TSource source);

        Task DeleteAsync(int id);

        Task<bool> Exists(int id);
    }
}
