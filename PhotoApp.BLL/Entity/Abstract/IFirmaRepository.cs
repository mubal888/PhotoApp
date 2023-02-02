using PhotoApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApp.BLL.Entity.Abstract
{
    public interface IFirmaRepository
    {
        List<Firma> GetAll();
        List<Firma> GetEx(Expression<Func<Firma, bool>> predicate);
        Firma GetByID(int Id);
        void Add(Firma entity);
        void Update(Firma entity);
        void Delete(Firma entity); 
    }
}
