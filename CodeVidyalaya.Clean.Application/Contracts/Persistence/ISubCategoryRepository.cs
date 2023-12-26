using CodeVidyalaya.Clean.Domain;

namespace CodeVidyalaya.Clean.Application.Contracts.Persistence
{
    public interface ISubCategoryRepository : IGenericRepository<SubCategory>
    {
        void Update(SubCategory obj);
        Task<bool> IsSubCategoryUnique(string subCategoryName);
    }
}
