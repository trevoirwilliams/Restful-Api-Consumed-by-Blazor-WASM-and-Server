using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStoreApp.API.Contracts;
using BookStoreApp.API.Data;
using BookStoreApp.API.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenericRepository(BookStoreDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }


        public async Task<TResult> AddAsync<TSource, TResult>(TSource source)
        {
            //automapper at this point doesnt know if it's author/book,
            // it's mapping to entity type
            var entity = _mapper.Map<T>(source);

            //save
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            // map back to DTO that we want
            return _mapper.Map<TResult>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity is null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<TResult>> GetAllAsync<TResult>()
        {
            return await _context.Set<T>()
               .ProjectTo<TResult>(_mapper.ConfigurationProvider)
               .ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }

            return await _context.Set<T>().FindAsync(id);
        }


        public async Task<TResult> GetAsync<TResult>(int? id)
        {
            var result = await _context.Set<T>().FindAsync(id);

            if (result is null)
            {
                // if id is null return no key provided
                throw new NotFoundException(typeof(T).Name, id.HasValue ? id : "No key provided.");
            }

            return _mapper.Map<TResult>(result);
        }

        public async Task UpdateAsync<TSource>(int id, TSource source)
        {
            var entity = await GetAsync(id);

            if (entity == null)
            {
                //throw new NotFoundException(typeof(T).Name, id);
            }

            _mapper.Map(source, entity);
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
