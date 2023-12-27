using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Domain;
using CodeVidyalaya.Clean.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CodeVidyalaya.Clean.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly SampleApplicationDatabaseContext _db;

        public CategoryRepository(SampleApplicationDatabaseContext db) :base(db)
        {
            this._db = db;
        }

        public async Task<bool> IsCategoryUnique(string categoryName)
        {
            return await _db.Categories.AnyAsync(u => u.CategoryName == categoryName) == false;
        }

        public void Update(Category obj)
        {
            _db.Update(obj);
        }
    }
}
