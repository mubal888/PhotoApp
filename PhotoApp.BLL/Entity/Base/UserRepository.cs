using PhotoApp.BLL.Entity.Abstract;
using PhotoApp.DAL.Abstract;
using PhotoApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PhotoApp.BLL.Entity.Base
{
    public class UserRepository : IUserRepository
    {
        IUserBaseRepository _repository;

        public UserRepository(IUserBaseRepository UserRepository)
        {
            this._repository = UserRepository;
        }

        public void Add(User entity)
        {
            _repository.Add(entity);
        }

        public void Delete(User entity)
        {
            _repository.Delete(entity);

        }

        public List<User> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public User GetByID(int Id)
        {
            return _repository.GetByID(Id);
        }

        public List<User> GetEx(Expression<Func<User, bool>> predicate)
        {
            return _repository.GetEx(predicate).ToList();
        }

        public void Update(User entity)
        {
            _repository.Update(entity);
        }
    }
}
