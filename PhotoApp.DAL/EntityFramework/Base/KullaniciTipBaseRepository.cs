using PhotoApp.Core.Base;
using PhotoApp.DAL.Abstract;
using PhotoApp.DAL.EntityFramework;
using PhotoApp.Entities.Models;

namespace PhotoApp.DAL.Base
{
    public class KullaniciTipBaseRepository : Repository<KullaniciTip, PhotoDbContext>, IKullaniciTipBaseRepository
    {
        public KullaniciTipBaseRepository(PhotoDbContext context) : base(context)
        {
        }
    }
}
