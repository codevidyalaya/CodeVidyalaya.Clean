using CodeVidyalaya.Clean.Domain;

namespace CodeVidyalaya.Clean.Application.Contracts.Persistence
{
    public interface ICategoryRepository :IGenericRepository<Category>
    {
        void Update(Category obj);
        Task<bool> IsCategoryUnique(string categoryName);
    }
}
