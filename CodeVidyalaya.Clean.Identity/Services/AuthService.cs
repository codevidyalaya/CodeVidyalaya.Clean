using CodeVidyalaya.Clean.Application.Identity;
using CodeVidyalaya.Clean.Application.Models.Identity;
using CodeVidyalaya.Clean.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CodeVidyalaya.Clean.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManger, IOptions<JwtSettings> jwtSettings, SignInManager<ApplicationUser> signInManager)
        {
            this._userManger = userManger;
            this._jwtSettings = jwtSettings.Value;
            this._signInManager = signInManager;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManger.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception($"User not found with {request.Email}");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new Exception($"Credential for {request.Email} are not valid");
            }

            JwtSecurityToken jwtSecurityToken = await GenrateToken(user);

            AuthResponse response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };

            return response;

        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existingUser = await _userManger.FindByNameAsync(request.UserName);

            if(existingUser !=null)
            {
                throw new Exception($"User {request.UserName} already exists");
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var existingEmail = await _userManger.FindByEmailAsync(request.Email);
            if (existingEmail == null)
            {
                var result = await _userManger.CreateAsync(user, request.Password);
                if(result.Succeeded)
                {
                    await _userManger.AddToRoleAsync(user, "Employee");
                    return new RegistrationResponse() { UserId = user.Id };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            else
            {
                throw new Exception($"Email {request.Email} already exists.");
            }

        }

        private async Task<JwtSecurityToken> GenrateToken(ApplicationUser user)
        {
            var userClaims = await _userManger.GetClaimsAsync(user);
            var roles = await _userManger.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricsSecurityKe = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricsSecurityKe, SecurityAlgorithms.HmacSha256);

            var jwrSecurityToken =new  JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials
                );

            return jwrSecurityToken;

        }

    }
}