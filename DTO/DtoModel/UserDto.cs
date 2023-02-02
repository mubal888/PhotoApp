using System.ComponentModel.DataAnnotations;

namespace DTO.DtoModel
{
    public class UserDto
    {
        public class User
        {
            [Required(ErrorMessage = "Firma Boş Geçilemez")]
            public int FirmaID { get; set; }
            public bool Aktif { get; set; } 
            public string FirmaAdi { get; set; }
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
