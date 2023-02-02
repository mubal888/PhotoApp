using Microsoft.EntityFrameworkCore;
using PhotoApp.Core.DAL;
using PhotoApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApp.Core.Base
{
    public class Repository<Tentity, Tcontext> : IRepository<Tentity>
        where Tentity : class, IEntity
        where Tcontext : DbContext
    {
        protected readonly Tcontext context;

        public Repository(Tcontext context)
        {
            this.context = context;
        }

        public void Add(Tentity entity)
        {
            context.Set<Tentity>().Add(entity);
            Save();
        }

        public void Delete(Tentity entity)
        {
            context.Set<Tentity>().Remove(entity);
            Save();
        }

        public IQueryable<Tentity> GetAll()
        {
            return context.Set<Tentity>();
        }

        public Tentity GetByID(int Id)
        {
            return context.Set<Tentity>().Find(Id);
        }

        public IQueryable<Tentity> GetEx(Expression<Func<Tentity, bool>> predicate)
        {
            return context.Set<Tentity>().Where(predicate);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update(Tentity entity)
        {
            context.Set<Tentity>().Update(entity);
            Save();
        }
    }
}
