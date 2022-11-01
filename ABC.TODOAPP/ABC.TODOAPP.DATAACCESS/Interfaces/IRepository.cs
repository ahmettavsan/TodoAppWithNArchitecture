using ABC.TODOAPP.ENTITIES.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ABC.TODOAPP.DATAACCESS.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);//----->ef coreun find metodunu kullancaz
        //find metodu vermiş olduğumuz primary key ile data arıyor
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> expression,bool asNoTracking=false);
        Task CreateAsync(T entity);
        void Update(T entity,T unchanged);
        void Remove(T entity);

    }
}
