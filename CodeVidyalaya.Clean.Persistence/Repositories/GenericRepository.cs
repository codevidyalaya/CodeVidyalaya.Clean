using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Domain.Common;
using CodeVidyalaya.Clean.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CodeVidyalaya.Clean.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly SampleApplicationDatabaseContext _db;
        internal DbSet<T> dbset;
        public GenericRepository(SampleApplicationDatabaseContext db)
        {
            _db = db;
            dbset = _db.Set<T>();
        }

        public async Task Add(T entity)
        {
            await dbset.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await dbset.AddRangeAsync(entities);
        }

        public async Task<List<T>> GetAllAsync(string? includePrperties = null)
        {
            IQueryable<T> query = dbset;
            if(includePrperties !=null)
            {
                foreach (var item in includePrperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter, string? includePrperties = null)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            if (includePrperties != null)
            {
                foreach (var item in includePrperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }

        public  Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string? includePrperties = null)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            if (includePrperties != null)
            {
                foreach (var item in includePrperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return  query.FirstOrDefaultAsync();
        }

        public Task Remove(T entity)
        {
            dbset.Remove(entity);
            return Task.CompletedTask;
        }

        public Task RemoveRange(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
            return Task.CompletedTask;
        }
    }
}
