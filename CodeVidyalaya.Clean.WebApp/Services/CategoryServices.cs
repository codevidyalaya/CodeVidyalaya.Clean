using CodeVidyalaya.Clean.WebApp.Contracts;
using CodeVidyalaya.Clean.WebApp.Models;

namespace CodeVidyalaya.Clean.WebApp.Services
{
    public class CategoryServices : ICategoryServices
    {
        public Task<List<CategoryVM>> GetCategory()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDetailsVM> GetCategoryDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
