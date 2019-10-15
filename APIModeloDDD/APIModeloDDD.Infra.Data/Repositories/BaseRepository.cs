using APIModeloDDD.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIModeloDDD.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private DbSet<T> _entity;
        protected Context.Context context;

        public BaseRepository(Context.Context context)
        {
            this.context = context;
            _entity = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await _entity.ToListAsync();
        }

        public virtual async Task Delete(T entity)
        {
            _entity.Remove(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task<T> Save(T entity)
        {
            _entity.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Update(T entity)
        {
            _entity.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
