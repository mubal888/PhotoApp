using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DtoModel
{
    public class FirmaDto
    {
        public class Firma
        {
            public bool Aktif { get; set; }
            [Required(ErrorMessage = "Firma Adı Boş Geçilemez")]
            public string FirmaAdi { get; set; } 
        }
        public class FirmaUser
        {
            [Range(1, 2147483647, ErrorMessage = "Firma Seçiniz...")]
            public int FirmaID { get; set; }
            public bool Aktif { get; set; }
            [Required(ErrorMessage = "Firma Adı Boş Geçilemez")]
            public string FirmaAdi { get; set; }
            public int UserID { get; set; }
            [Required(ErrorMessage = "Kullanıcı adı giriniz")]
            public string UserName { get; set; }
            [Required(ErrorMessage = "Şifre giriniz")]
            public string Password { get; set; }
            [Compare("Password", ErrorMessage = "Şifre tekrarı şifre ile aynı değil giriniz")]
            public string Repassword { get; set; }
            [Required(ErrorMessage = "Adı giriniz")]
            public string Ad { get; set; }
            [Required(ErrorMessage = "Soyadı giriniz")]
            public string Soyad { get; set; }
            [Phone(ErrorMessage = "Hatalı Telefon numarası.")]
            public string Telefon { get; set; }
            [EmailAddress(ErrorMessage = "Hatalı mail adresi")]
            public string EMail { get; set; }
            public string Adres { get; set; }
            [Range(1, 10, ErrorMessage = "Kullanıcı Tipi Seçiniz.")]
            public int KullaniciTipID { get; set; }
        }
    }
}
