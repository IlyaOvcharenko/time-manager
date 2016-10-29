using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace DAL.Repositories
{
    public interface IBaseRepository<T> : IDisposable where T: BaseEntity
    {
        T Create(T entity);

        IQueryable<T> GetAll();

        T GetById(int id);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);
    }

    
}
