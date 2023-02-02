using PhotoApp.Core.Base;
using PhotoApp.DAL.Abstract;
using PhotoApp.DAL.EntityFramework;
using PhotoApp.Entities.Models;

namespace PhotoApp.DAL.Base
{
    public class UserBaseRepository : Repository<User, PhotoDbContext>, IUserBaseRepository
    {
        public UserBaseRepository(PhotoDbContext context) : base(context)
        {
        }
    }
}
