using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Domain.Common;
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
            foreach(var entry in _db.ChangeTracker.Entries<BaseEntity>())
            {
                switch(entry.State)
                {
                    case Microsoft.EntityFrameworkCore.EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.ModifiedDate =  DateTime.UtcNow;
                        break;
                    case Microsoft.EntityFrameworkCore.EntityState.Modified:                        
                        entry.Entity.ModifiedDate = DateTime.UtcNow;
                        break;

                }
            }

            await _db.SaveChangesAsync();
        }
    }
}
