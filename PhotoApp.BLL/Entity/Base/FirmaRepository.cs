using DTO.DtoModel;
using PhotoApp.BLL.Entity.Abstract;
using PhotoApp.DAL.Abstract;
using PhotoApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApp.BLL.Entity.Base
{
    public class FirmaRepository : IFirmaRepository
    { 

        private readonly IFirmaBaseRepository _repository;

        public FirmaRepository(IFirmaBaseRepository entityRepository)
        { 
            _repository = entityRepository;
        }

        public void Add(Firma entity)
        {
            _repository.Add(entity);
        }

        public void Delete(Firma entity)
        {
            _repository.Delete(entity);

        }

        public List<Firma> GetAll()
        { 
            return _repository.GetAll().ToList();
        }

        public Firma GetByID(int Id)
        {
            return _repository.GetByID(Id);
        }

        public List<Firma> GetEx(Expression<Func<Firma, bool>> predicate)
        {
            return _repository.GetEx(predicate).ToList();
        }

        public void Update(Firma entity)
        {
            _repository.Update(entity);
        }
    }
}
