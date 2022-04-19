namespace BookStoreApp.API.Models.User
{
    public class AuthResponseDto
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
    }
}