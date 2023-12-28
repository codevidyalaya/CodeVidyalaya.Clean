using CodeVidyalaya.Clean.WebApp.Models;

namespace CodeVidyalaya.Clean.WebApp.Contracts
{
    public interface ICategoryServices
    {
        Task<List<CategoryVM>> GetCategory();
        Task<CategoryDetailsVM> GetCategoryDetails(int id);
    }
}
