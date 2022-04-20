namespace BookStoreApp.Blazor.Server.UI.Services.Base
{
    // partial allows us to extend the IClient class from ServiceClient
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
