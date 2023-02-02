using PhotoApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PhotoApp.BLL.Entity.Abstract
{
    public interface IKullaniciTipRepository
    {
        List<KullaniciTip> GetAll();
        List<KullaniciTip> GetEx(Expression<Func<KullaniciTip, bool>> predicate);
        KullaniciTip GetByID(int Id);
        void Add(KullaniciTip entity);
        void Update(KullaniciTip entity);
        void Delete(KullaniciTip entity); 
    }
}
