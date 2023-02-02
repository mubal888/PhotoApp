using Microsoft.EntityFrameworkCore;
using PhotoApp.Entities.Models;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApp.DAL.EntityFramework
{
    public class PhotoDbContext : DbContext
    { 
        public PhotoDbContext(DbContextOptions<PhotoDbContext> options) : base(options)
        {
        }
       
        public DbSet<Firma> Firmalar{ get; set; } // veritabanına oluşacak tablolar yazılıyor
        public DbSet<KullaniciTip> KullaniciTipler { get; set; } // veritabanına oluşacak tablolar yazılıyor

        public DbSet<User> Users { get; set; } // veritabanına oluşacak tablolar yazılıyor

    }
}
