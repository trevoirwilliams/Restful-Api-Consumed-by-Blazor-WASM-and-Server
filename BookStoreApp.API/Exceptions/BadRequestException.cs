namespace BookStoreApp.API.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string name, object key) : base($"{name} ({key}) was not found.")
        {

        }
    }
}
