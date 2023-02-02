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
            [Required(ErrorMessage = "Firma Boş Geçilemez")]
            public int FirmaID { get; set; }
            public bool Aktif { get; set; }
            [Required(ErrorMessage = "Firma Adı Boş Geçilemez")]
            public string FirmaAdi { get; set; }
            public int UserID { get; set; }
            [Required(ErrorMessage = "Kullanıcı adı giriniz")]
            public string UserName { get; set; }
            [Required(ErrorMessage = "Şifre giriniz")]
            public string Password { get; set; }
            [Required(ErrorMessage = "Adı giriniz")]
            public string Ad { get; set; }
            [Required(ErrorMessage = "Soyadı giriniz")]
            public string Soyad { get; set; }
            [Required(ErrorMessage = "Telefon numarasını giriniz.")]
            public string Telefon { get; set; }
            public string EMail { get; set; }
            public string Adres { get; set; }
            [Required(ErrorMessage = "Kullanıcı Tipi Seçiniz")]
            public int KullaniciTipID { get; set; }
        }
    }
}
