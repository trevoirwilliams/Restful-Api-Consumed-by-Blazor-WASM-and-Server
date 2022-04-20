namespace BookStoreApp.Blazor.Server.UI.Services.Base
{
    public partial class Client : IClient
    {
        // return the _httpClient from Client in ServiceClient.cs 
        public HttpClient HttpClient
        {
            get { return _httpClient; }
        }
    }
}
