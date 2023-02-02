using PhotoApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApp.Core.DAL
{
    public interface IRepository<T> where T :class, IEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetEx(Expression<Func<T, bool>> predicate);
        T GetByID(int Id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
