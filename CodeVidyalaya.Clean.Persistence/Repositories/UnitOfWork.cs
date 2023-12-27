using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Persistence.DatabaseContext;

namespace CodeVidyalaya.Clean.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SampleApplicationDatabaseContext _db;
        private bool _disposed = false;

        public ICategoryRepository Category { get; private set; }

        public ISubCategoryRepository SubCategory { get; private set; }

        public UnitOfWork(SampleApplicationDatabaseContext db)
        {
            this._db = db;
            Category = new CategoryRepository(_db);
            SubCategory = new SubCategoryRepository(_db);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
