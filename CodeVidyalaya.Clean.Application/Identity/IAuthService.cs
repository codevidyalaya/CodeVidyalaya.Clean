using CodeVidyalaya.Clean.Application.Models.Identity;

namespace CodeVidyalaya.Clean.Application.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
