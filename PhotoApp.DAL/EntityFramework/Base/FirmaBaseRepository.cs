using PhotoApp.Core.Base;
using PhotoApp.DAL.Abstract;
using PhotoApp.DAL.EntityFramework;
using PhotoApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApp.DAL.Base
{
    public class FirmaBaseRepository : Repository<Firma, PhotoDbContext>, IFirmaBaseRepository
    {
        public FirmaBaseRepository(PhotoDbContext context) : base(context)
        {
        }
    } 
}
