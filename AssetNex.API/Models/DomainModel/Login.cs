namespace AssetNex.API.Models.DomainModel
{
    public class Login
    {


        public required string Email { get; set; } = "";
        public required string Password { get; set; } = "";
        public required string Token { get; set; }
        public DateTime Expiration { get; set; }
        public bool Success { get; set; }
        public required string Message { get; set; }
        public IEnumerable<string>? Errors { get; set; }

    }
}
