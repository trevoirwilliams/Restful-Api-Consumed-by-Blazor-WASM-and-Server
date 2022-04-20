using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public class AuthorService : BaseHttpService, IAuthorService 
    {
        public AuthorService(ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
        }

        public Task<Response<List<AuthorReadOnlyDto>>> GetAuthors()
        {
            throw new NotImplementedException();
        }
    }
}
