using CodeVidyalaya.Clean.WebApp.Contracts;
using CodeVidyalaya.Clean.WebApp.Models;
using Newtonsoft.Json;

namespace CodeVidyalaya.Clean.WebApp.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryServices(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._httpClientFactory = httpClientFactory;
        }

        public async Task<List<CategoryVM>> GetCategory()
        {
            
            var client = _httpClientFactory.CreateClient("MyApi");
            var response = client.GetAsync("Category").Result;

            if (response.IsSuccessStatusCode)
            {
                List<CategoryVM> categoryList = JsonConvert.DeserializeObject<List<CategoryVM>>(await response.Content.ReadAsStringAsync());
                return categoryList;
            }

            return new List<CategoryVM>();
        }

        public async Task<CategoryDetailsVM> GetCategoryDetails(int id)
        {
            var client = _httpClientFactory.CreateClient("MyApi");
            var response = client.GetAsync($"Category/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                CategoryDetailsVM categoryDetailsVM = JsonConvert.DeserializeObject<CategoryDetailsVM>(await response.Content.ReadAsStringAsync());
                return categoryDetailsVM;
            }

            return new CategoryDetailsVM();
        }
    }
}
