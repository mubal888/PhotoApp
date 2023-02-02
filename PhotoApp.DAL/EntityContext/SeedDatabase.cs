using Microsoft.Extensions.DependencyInjection;
using PhotoApp.DAL.EntityFramework;
using PhotoApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApp.DAL.EntityContext
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<PhotoDbContext>();
            Firma firma = new()
            {
                Aktif = true,
                FirmaAdi = "BaL Foto"
            };
            if (!context.Firmalar.Any())
            {
                context.Firmalar.Add(firma);
                if (context.SaveChanges() > 0)
                {
                    KullaniciTip kullaniciTip = new()
                    {
                        Tip = "Firma"
                    };
                    context.KullaniciTipler.Add(kullaniciTip);
                    if (context.SaveChanges()>0)
                    {

                    }
                    User user = new()
                    {
                        Aktif = true,
                        UserName = "BalFoto",
                        Password = "12345",
                        Ad = "Muhammed",
                        Soyad = "BAL",
                        Telefon = "5058777",
                        EMail = "muhammed@hotmail",
                        Adres = "Aydın",
                        KullaniciTipID = kullaniciTip.ID,
                        KullaniciTip = kullaniciTip,
                        FirmaID = firma.ID,
                        Firma = firma
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                }

            }


        }
    }
}
