using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public class BookService : BaseHttpService, IBookService
    {
        private readonly IClient _client;
        private readonly IMapper _mapper;

        public BookService(ILocalStorageService localStorage, IClient client, IMapper mapper) : base(localStorage, client)
        {
            this._client = client;
            this._mapper = mapper;
        }

        public async Task<Response<int>> CreateBook(BookCreateDto book)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await _client.BooksPOSTAsync(book);
            }
            catch (ApiException exception)
            {

                response = ConvertApiExceptions<int>(exception); ;
            }
            return response;
        }

        public async Task<Response<int>> Delete(int id)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await _client.BooksDELETEAsync(id);
            }
            catch (ApiException exception)
            {

                response = ConvertApiExceptions<int>(exception); ;
            }
            return response;
        }

        public async Task<Response<int>> EditBook(int id, BookUpdateDto book)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await _client.BooksPUTAsync(id, book);
            }
            catch (ApiException exception)
            {

                response = ConvertApiExceptions<int>(exception); ;
            }
            return response;
        }

        public async Task<Response<BookReadOnlyDto>> GetBook(int id)
        {
            Response<BookReadOnlyDto> response;
            try
            {
                await GetBearerToken();
                var data = await _client.BooksGETAsync(id);
                response = new Response<BookReadOnlyDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<BookReadOnlyDto>(exception);
            }
            return response;
        }

        public async Task<Response<BookDetailsDto>> GetBookDetails(int id)
        {
            Response<BookDetailsDto> response;
            try
            {
                await GetBearerToken();
                var data = await _client.GetBookDetailsAsync(id);
                response = new Response<BookDetailsDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<BookDetailsDto>(exception);
            }
            return response;
        }

        public async Task<Response<BookUpdateDto>> GetBookForUpdate(int id)
        {
            // used for converting AuthorReadOnlyDto to AuthorUpdateDto
            Response<BookUpdateDto> response;
            try
            {
                await GetBearerToken();
                var data = await _client.BooksGETAsync(id);
                response = new Response<BookUpdateDto>
                {
                    Data = _mapper.Map<BookUpdateDto>(data),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<BookUpdateDto>(exception);
            }
            return response;
        }

        // declare response, try operation catch exceptions that may come back from api.
        public async Task<Response<List<BookReadOnlyDto>>> GetBooks()
        {
            Response<List<BookReadOnlyDto>> response;
            try
            {
                await GetBearerToken();
                var data = await _client.BooksAllAsync();
                response = new Response<List<BookReadOnlyDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<List<BookReadOnlyDto>>(exception);
            }
            return response;
        }
    }


}
