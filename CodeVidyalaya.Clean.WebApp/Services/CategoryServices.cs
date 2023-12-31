using CodeVidyalaya.Clean.WebApp.Contracts;
using CodeVidyalaya.Clean.WebApp.Models;
using CodeVidyalaya.Clean.WebApp.Services.Base;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CodeVidyalaya.Clean.WebApp.Services
{
    public class CategoryServices : BaseHttpService, ICategoryServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILocalStorageService _localStorageService;

        public CategoryServices(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._httpClientFactory = httpClientFactory;
            this._localStorageService = localStorageService;
        }

        public async Task<List<CategoryVM>> GetCategory()
        {
            var token = _localStorageService.GetStorageValue<string>("token");
            var client = _httpClientFactory.CreateClient("MyApi");

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

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
            var token = _localStorageService.GetStorageValue<string>("token");
            var client = _httpClientFactory.CreateClient("MyApi");
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = client.GetAsync($"Category/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                CategoryDetailsVM categoryDetailsVM = JsonConvert.DeserializeObject<CategoryDetailsVM>(await response.Content.ReadAsStringAsync());
                return categoryDetailsVM;
            }

            return new CategoryDetailsVM();
        }

        public async Task<SuccessResponse<string>> CreateCategory(CreateCategoryRequest createCategoryRequest)
        {
            var token = _localStorageService.GetStorageValue<string>("token");
            string inputParameter = JsonConvert.SerializeObject(createCategoryRequest);
            StringContent content = new StringContent(inputParameter, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient("MyApi");
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var apiResponse = await client.PostAsync("Category", content);

            if (apiResponse.IsSuccessStatusCode)
            {
                var responseData = await apiResponse.Content.ReadAsStringAsync();
                return new SuccessResponse<string> { Success = true, Data = responseData };
            }
            else
            {
                var jsonContent = await apiResponse.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(jsonContent))
                {
                    var errorResponse = JsonConvert.DeserializeObject<FailureResponse>(jsonContent);
                    return new SuccessResponse<string> { Success = false, ValidationErrors = errorResponse.Errors };
                }
                else
                {
                    var errorData = new Dictionary<string, string[]>
                    {
                        { "", new string[] { apiResponse.StatusCode.ToString() } }
                    };
                    return new SuccessResponse<string> { Success = false, ValidationErrors = errorData };
                }
            }
        }

        public async Task<SuccessResponse<string>> DeleteCategory(int id)
        {
            var token = _localStorageService.GetStorageValue<string>("token");
            var client = _httpClientFactory.CreateClient("MyApi");
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var apiResponse = await client.DeleteAsync($"Category/{id}");

            if (apiResponse.IsSuccessStatusCode)
            {
                var responseData = await apiResponse.Content.ReadAsStringAsync();
                return new SuccessResponse<string> { Success = true, Data = responseData };
            }
            else
            {
                var jsonContent = await apiResponse.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(jsonContent))
                {
                    var errorResponse = JsonConvert.DeserializeObject<FailureResponse>(jsonContent);
                    return new SuccessResponse<string> { Success = false, ValidationErrors = errorResponse.Errors };
                }
                else
                {
                    var errorData = new Dictionary<string, string[]>
                    {
                        { "", new string[] { apiResponse.StatusCode.ToString() } }
                    };
                    return new SuccessResponse<string> { Success = false, ValidationErrors = errorData };
                }
            }
        }

        public async Task<SuccessResponse<string>> UpdateCategory(int id, UpdateCategoryRequest updateCategoryRequest)
        {
            var token = _localStorageService.GetStorageValue<string>("token");
            string inputParameter = JsonConvert.SerializeObject(updateCategoryRequest);
            StringContent content = new StringContent(inputParameter, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient("MyApi");
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var apiResponse = await client.PutAsJsonAsync("Category/{id}", content);

            if (apiResponse.IsSuccessStatusCode)
            {
                var responseData = await apiResponse.Content.ReadAsStringAsync();
                return new SuccessResponse<string> { Success = true, Data = responseData };
            }
            else
            {
                var jsonContent = await apiResponse.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(jsonContent))
                {
                    var errorResponse = JsonConvert.DeserializeObject<FailureResponse>(jsonContent);
                    return new SuccessResponse<string> { Success = false, ValidationErrors = errorResponse.Errors };
                }
                else
                {
                    var errorData = new Dictionary<string, string[]>
                    {
                        { "", new string[] { apiResponse.StatusCode.ToString() } }
                    };
                    return new SuccessResponse<string> { Success = false, ValidationErrors = errorData };
                }
            }
        }
    }
}
