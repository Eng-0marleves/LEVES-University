namespace LEVES_University.Interfaces
{
    public interface IAuthService
    {
        public Task<string> AuthenticateUserAsync(string id, string password);
        public string SaveImage(IFormFile image);
    }
}
