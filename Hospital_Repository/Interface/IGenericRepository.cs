using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Repository.Interface
{
    public interface IGenericRepository<T>:IDisposable
    {
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>>? filter= null, Func<IQueryable<T>, IOrderedQueryable<T>>? order = null, string includePropertios = "");
            T GetbyId(int id);
        Task<T> GetbyIdAsync(int id);
        void add(T entity);
        Task<T> addAsync(T entity);
        void update(T entity);
        Task updateAsync(T entity);
        void delete(T entity);
        Task deleteAsync(T entity);
    }
}
