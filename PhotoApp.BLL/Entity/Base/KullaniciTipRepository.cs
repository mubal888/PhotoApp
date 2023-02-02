using PhotoApp.BLL.Entity.Abstract;
using PhotoApp.DAL.Abstract;
using PhotoApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PhotoApp.BLL.Entity.Base
{
    public class KullaniciTipRepository : IKullaniciTipRepository
    {
        IKullaniciTipBaseRepository _repository;

        public KullaniciTipRepository(IKullaniciTipBaseRepository KullaniciTipRepository)
        {
            this._repository = KullaniciTipRepository;
        }

        public void Add(KullaniciTip entity)
        {
            _repository.Add(entity);
        }

        public void Delete(KullaniciTip entity)
        {
            _repository.Delete(entity);

        }
        public List<KullaniciTip> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public KullaniciTip GetByID(int Id)
        {
            return _repository.GetByID(Id);
        }

        public List<KullaniciTip> GetEx(Expression<Func<KullaniciTip, bool>> predicate)
        {
            return _repository.GetEx(predicate).ToList();
        }

        public void Update(KullaniciTip entity)
        {
            _repository.Update(entity);
        }
    }
}
