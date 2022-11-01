using ABC.TODOAPP.ENTITIES.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.TODOAPP.DATAACCESS.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<T> GetRepository<T>() where T : BaseEntity;

        Task SaveChanges();
    }
}
