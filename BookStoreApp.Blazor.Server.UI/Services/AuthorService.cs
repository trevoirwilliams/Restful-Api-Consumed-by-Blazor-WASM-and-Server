using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    // global error handling for blazor components
    public class AuthorService : BaseHttpService, IAuthorService
    {
        private readonly IClient _client;
        private readonly IMapper _mapper;

        public AuthorService(ILocalStorageService localStorage, IClient client, IMapper mapper) : base(localStorage, client)
        {
            this._client = client;
            this._mapper = mapper;
        }

        public async Task<Response<int>> CreateAuthor(AuthorCreateDto author)
        {
            Response<int>response = new();
            try
            {
                await GetBearerToken();
                await _client.AuthorsPOSTAsync(author);
            }
            catch (ApiException exception)
            {

                response = ConvertApiExceptions<int>(exception); ;
            }
            return response;
        }

        public async Task<Response<int>> EditAuthor(int id, AuthorUpdateDto author)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await _client.AuthorsPUTAsync(id, author);
            }
            catch (ApiException exception)
            {

                response = ConvertApiExceptions<int>(exception); ;
            }
            return response;
        }

        public async Task<Response<AuthorReadOnlyDto>> GetAuthor(int id)
        {
            Response<AuthorReadOnlyDto> response;
            try
            {
                await GetBearerToken();
                var data = await _client.AuthorsGETAsync(id);
                response = new Response<AuthorReadOnlyDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<AuthorReadOnlyDto>(exception);
            }
            return response;
        }

        public async Task<Response<AuthorDetailsDto>> GetAuthorDetails(int id)
        {
            Response<AuthorDetailsDto> response;
            try
            {
                await GetBearerToken();
                var data = await _client.GetAuthorDetailsAsync(id);
                response = new Response<AuthorDetailsDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<AuthorDetailsDto>(exception);
            }
            return response;
        }

        public async Task<Response<AuthorUpdateDto>> GetAuthorForUpdate(int id)
        {
            // used for converting AuthorReadOnlyDto to AuthorUpdateDto
            Response<AuthorUpdateDto> response;
            try
            {
                await GetBearerToken();
                var data = await _client.AuthorsGETAsync(id);
                response = new Response<AuthorUpdateDto>
                {
                    Data = _mapper.Map<AuthorUpdateDto>(data),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<AuthorUpdateDto>(exception);
            }
            return response;
        }

        // declare response, try operation catch exceptions that may come back from api.
        public async Task<Response<List<AuthorReadOnlyDto>>> GetAuthors()
        {
            Response<List<AuthorReadOnlyDto>> response;
            try
            {
                await GetBearerToken();
                var data = await _client.AuthorsAllAsync();
                response = new Response<List<AuthorReadOnlyDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<List<AuthorReadOnlyDto>>(exception);
            }
            return response;
        }
    }
}
