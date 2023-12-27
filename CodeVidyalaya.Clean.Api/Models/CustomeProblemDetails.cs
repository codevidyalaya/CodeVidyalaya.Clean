using Microsoft.AspNetCore.Mvc;

namespace CodeVidyalaya.Clean.Api.Models
{
    public class CustomeProblemDetails :ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
