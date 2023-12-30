using CodeVidyalaya.Clean.WebApp.Contracts;
using CodeVidyalaya.Clean.WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CodeVidyalaya.Clean.WebApp.Services
{
    public class AuthenticationService : IAuthenticateService
    {
        private JwtSecurityTokenHandler _tokenHandler;
        private readonly ILocalStorageService _localStorage;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _clientFactory;

        public AuthenticationService(ILocalStorageService localStorage, IHttpContextAccessor httpContextAccessor, IHttpClientFactory clientFactory)
        {
            this._localStorage = localStorage;
            this._httpContextAccessor = httpContextAccessor;
            this._clientFactory = clientFactory;
            this._tokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task<bool> Authenticate(AuthRequest request)
        {
            try
            {
                string inputParameter = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(inputParameter, Encoding.UTF8, "application/json");
                var client = _clientFactory.CreateClient("MyApi");
                var response = client.PostAsync("Auth/login", content).Result;

                if(response.IsSuccessStatusCode)
                {
                    AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(await response.Content.ReadAsStringAsync());
                    var tokenContent = _tokenHandler.ReadJwtToken(authResponse.Token);
                    var claims = ParseClaims(tokenContent);
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
                    var login = _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                    _localStorage.SetStorageValue("token", authResponse.Token);
                    return true;
                }
                return false;
            }
            catch
            {

                return false;
            }
        }

        private IList<Claim> ParseClaims(JwtSecurityToken tokenContent)
        {
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }

        public Task Logout()
        {
            _localStorage.ClearStorage(new List<string> { "token" });
            _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Task.FromResult(true);
        }

        public async Task<bool> Register(RegistrationRequest register)
        {
            try
            {
                string inputParameter = JsonConvert.SerializeObject(register);
                StringContent content = new StringContent(inputParameter, Encoding.UTF8, "application/json");
                var client = _clientFactory.CreateClient("MyApi");
                var response = client.PostAsync("Auth/register", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    RegistrationResponse registrationResponse = JsonConvert.DeserializeObject<RegistrationResponse>(await response.Content.ReadAsStringAsync());
                    if(!string.IsNullOrEmpty(registrationResponse.UserId))
                    {
                        AuthRequest authRequest = new AuthRequest() { Email = register.Email, Password = register.Password };
                        await Authenticate(authRequest);
                        return true;
                    }                       
                }
                return false;
            }
            catch
            {

                return false;
            }

        }
    }
}
