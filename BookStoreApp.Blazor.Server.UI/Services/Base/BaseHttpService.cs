using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace BookStoreApp.Blazor.Server.UI.Services.Base
{
    public class BaseHttpService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IClient _client;

        public BaseHttpService(ILocalStorageService localStorage, IClient client)
        {
            this._localStorage = localStorage;
            this._client = client;
        }

        // convert api exceptions for each component because ServiceClient returns 200
        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException apiException)
        {
            if(apiException.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "There are validation errors", ValidationErrors = apiException.Response, Success = false };
            }
            if (apiException.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "The requested item has not been found", Success = false };
            }
            if (apiException.StatusCode >= 200 && apiException.StatusCode <= 299)
            {
                return new Response<Guid>() { Message = "The operation was a  success", Success = true };
            }

            return new Response<Guid>() { Message = "Something went wrong, please try again", Success = false };

        }

        // add the token
        protected async Task GetBearerToken()
        {
            var token = await _localStorage.GetItemAsync<string>("accessToken");
            if(token != null)
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
        }

    }
}
