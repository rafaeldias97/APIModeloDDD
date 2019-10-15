using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIModeloDDD.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        //Async Methods
        Task<IEnumerable<T>> All();
        Task<T> Save(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
