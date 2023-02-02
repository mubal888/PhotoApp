using PhotoApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PhotoApp.BLL.Entity.Abstract
{
    public interface IUserRepository
    {
        List<User> GetAll();
        List<User> GetEx(Expression<Func<User, bool>> predicate);
        User GetByID(int Id);
        void Add(User entity);
        void Update(User entity);
        void Delete(User entity);
    }
}
