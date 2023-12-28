using CodeVidyalaya.Clean.WebApp.Models;
using CodeVidyalaya.Clean.WebApp.Services.Base;

namespace CodeVidyalaya.Clean.WebApp.Contracts
{
    public interface ICategoryServices
    {
        Task<List<CategoryVM>> GetCategory();
        Task<CategoryDetailsVM> GetCategoryDetails(int id);
        Task<SuccessResponse<string>> CreateCategory(CreateCategoryRequest createCategoryRequest);
        Task<SuccessResponse<string>> UpdateCategory(int id, UpdateCategoryRequest updateCategoryRequest);
        Task<SuccessResponse<string>> DeleteCategory(int id);
    }
}
