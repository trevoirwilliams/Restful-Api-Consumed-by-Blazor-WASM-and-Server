using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStoreApp.API.Contracts;
using BookStoreApp.API.Data;
using BookStoreApp.API.Exceptions;
using BookStoreApp.API.Models.Author;
using BookStoreApp.API.Models.Book;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Repository
{
    public class BooksRepository : GenericRepository<Book>, IBooksRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly HttpContextAccessor httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BooksRepository(BookStoreDbContext context, IMapper mapper, HttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this._webHostEnvironment = webHostEnvironment;
        }

        public async Task<BookReadOnlyDto> AddBook(BookCreateDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            book.Image = CreateFile(bookDto.ImageData, bookDto.OriginalImageName);
            var record = await AddAsync<Book, BookReadOnlyDto>(book);
            return record;
        }

        private string CreateFile(string imageBase64, string imageName)
        {
            var url = httpContextAccessor.HttpContext.Request.Host.Value;
            var ext = Path.GetExtension(imageName);
            var fileName = $"{ Guid.NewGuid()}.{ext}";
            var path = $"{_webHostEnvironment.WebRootPath}\\bookcoverimages\\{fileName}";

            byte[] image = Convert.FromBase64String(imageBase64);
            var fileStream = System.IO.File.Create(path);
            fileStream.Write(image, 0, image.Length);
            fileStream.Close();

            return $"http://{url}/bookcoverimages/{fileName}";
        }


        public async Task<BookDetailsDto> GetDetails(int id)
        {
            //include matching author for book
            var book = await _context.Books.Include(q => q.Author)
                .ProjectTo<BookDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (book == null)
            {
                throw new NotFoundException(nameof(GetDetails), id);
            }

            return book;

        }


    }
}