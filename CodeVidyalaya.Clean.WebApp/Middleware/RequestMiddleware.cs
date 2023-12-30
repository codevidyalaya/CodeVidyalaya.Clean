using CodeVidyalaya.Clean.WebApp.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace CodeVidyalaya.Clean.WebApp.Middleware
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILocalStorageService _localStorageService;

        public RequestMiddleware(RequestDelegate next,ILocalStorageService localStorageService)
        {
            this._next = next;
            this._localStorageService = localStorageService;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {

                var ep = httpContext.Features.Get<IEndpointFeature>()?.Endpoint;
                var authAttr = ep?.Metadata?.GetMetadata<AuthorizeAttribute>();
                if(authAttr != null)
                {
                    var tokenExists = _localStorageService.Exits("token");
                    var tokenIsValid = true;
                    if(tokenExists)
                    {
                        var token = _localStorageService.GetStorageValue<string>("token");
                        JwtSecurityTokenHandler tokenhandler = new();
                        var tokencontent = tokenhandler.ReadJwtToken(token);
                        var expiry = tokencontent.ValidTo;
                        //if (expiry < DateTime.Now)
                        //{
                        //    tokenIsValid = false;
                        //}

                    }
                    if (tokenIsValid == false || tokenExists ==false)
                    {
                        await SignOutAndRedirect(httpContext);
                        return;
                    }

                    if(authAttr.Roles !=null)
                    {
                        var userRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
                        if(authAttr.Roles.Contains(userRole)==false)
                        {
                            var path = $"/home/notauthorized";
                            httpContext.Response.Redirect(path);
                            return;
                        }
                    }
                }
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);    
            }
        }

        private async static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            switch(ex)
            {
                default:
                    var path = $"Home/Error";
                    httpContext.Response.Redirect(path);
                    break;
            }
        }

        private static async Task SignOutAndRedirect(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var path = $"/user/login";
            httpContext.Response.Redirect(path);
        }
    }
}
