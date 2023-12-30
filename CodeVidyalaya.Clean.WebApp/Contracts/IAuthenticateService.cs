using CodeVidyalaya.Clean.WebApp.Models;

namespace CodeVidyalaya.Clean.WebApp.Contracts
{
    public interface IAuthenticateService
    {
        Task<bool> Authenticate(AuthRequest request);
        Task<bool> Register(RegistrationRequest register);
        Task Logout();
    }
}
