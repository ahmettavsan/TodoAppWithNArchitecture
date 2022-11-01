using ABC.TODOAPP.DATAACCESS.Interfaces;
using ABC.TODOAPP.ENTITIES.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ABC.TODOAPP.DATAACCESS.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TodoContext _context;

        public Repository(TodoContext todoContext)
        {
            _context = todoContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> expression, bool asNoTracking = false)
        {
            return asNoTracking ? await _context.Set<T>().SingleOrDefaultAsync(expression) :await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            //entity.IsDeleted = false;

            //_context.Entry(entity).State = EntityState.Modified;

            _context.Set<T>().Remove(entity);
        }
        //public void Remove(int id)
        //{
        //    //entity.IsDeleted = false;

        //    //_context.Entry(entity).State = EntityState.Modified;
        //   var deletedentity= _context.Set<T>().Find(id);

        //    _context.Set<T>().Remove(deletedentity);
        //}

        public async void Update(T entity,T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
            //_context.Set<T>().Update(entity);
        }
    }
}
