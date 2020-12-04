using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcUowRepos.Repository
{
    public class MvcRepository<T> : IMvcRepository<T> where T : class
    {
        private readonly MvcUowReposEntities _context;
        private DbSet<T> _set;
        private bool _disposed;

        protected DbSet<T> Set
        {
            get { return _set ?? (_set = _context.Set<T>()); }
        }
        public MvcRepository(MvcUowReposEntities context)
        {
            _context = context;
        }
        public async Task<int> Add(T entity)
        {
            try
            {
                var result = Set.Add(entity);
                return await Task.FromResult(0);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(1);
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var entity = await Set.FindAsync(id);
                _set.Remove(entity);
                return await Task.FromResult(0);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(1);
            }
        }

        public async Task<T> Get(int id)
        {
            try
            {
                var entity = await Set.FindAsync(id);
                return await Task.FromResult(entity);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                var entity = await Set.ToListAsync();
                return await Task.FromResult(entity);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Update(T entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entity);
                entry = _context.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}
