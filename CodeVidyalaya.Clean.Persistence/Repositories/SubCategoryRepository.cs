using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Domain;
using CodeVidyalaya.Clean.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CodeVidyalaya.Clean.Persistence.Repositories
{
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        private readonly SampleApplicationDatabaseContext _db;

        public SubCategoryRepository(SampleApplicationDatabaseContext db):base(db)
        {
            this._db = db;
        }
        public async Task<bool> IsSubCategoryUnique(string subCategoryName)
        {
            return await _db.SubCategories.AnyAsync(u => u.SubCategoryName == subCategoryName) == false;
        }

        public void Update(SubCategory obj)
        {
            _db.Update(obj);
        }
    }
}
