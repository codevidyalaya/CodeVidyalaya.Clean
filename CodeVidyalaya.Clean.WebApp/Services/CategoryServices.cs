using CodeVidyalaya.Clean.WebApp.Contracts;
using CodeVidyalaya.Clean.WebApp.Models;
using CodeVidyalaya.Clean.WebApp.Services.Base;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CodeVidyalaya.Clean.WebApp.Services
{
    public class CategoryServices : BaseHttpService, ICategoryServices
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

        public async Task<SuccessResponse<string>> CreateCategory(CreateCategoryRequest createCategoryRequest)
        {
            string inputParameter = JsonConvert.SerializeObject(createCategoryRequest);
            StringContent content = new StringContent(inputParameter, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient("MyApi");

            var apiResponse = await client.PostAsync("Category", content);

            if (apiResponse.IsSuccessStatusCode)
            {
                var responseData = await apiResponse.Content.ReadAsStringAsync();
                return new SuccessResponse<string> { Success = true, Data = responseData };
            }
            else
            {
                var jsonContent = await apiResponse.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<FailureResponse>(jsonContent);
                return new SuccessResponse<string> { Success = false, ValidationErrors = errorResponse.Errors };
            }
        }

        public async Task<SuccessResponse<string>> DeleteCategory(int id)
        {
            
            var client = _httpClientFactory.CreateClient("MyApi");

            var apiResponse = await client.DeleteAsync($"Category/{id}");

            if (apiResponse.IsSuccessStatusCode)
            {
                var responseData = await apiResponse.Content.ReadAsStringAsync();
                return new SuccessResponse<string> { Success = true, Data = responseData };
            }
            else
            {
                var jsonContent = await apiResponse.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<FailureResponse>(jsonContent);
                return new SuccessResponse<string> { Success = false, ValidationErrors = errorResponse.Errors };
            }
        }

        public  Task<SuccessResponse<string>> UpdateCategory(int id, UpdateCategoryRequest updateCategoryRequest)
        {
            throw new NotImplementedException();
        }
    }



}
