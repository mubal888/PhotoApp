using PhotoApp.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace PhotoApp.Entities.Models
{
    public class User : IEntity
    {
        [Key]
        public int ID { get; set; }
        public bool Aktif { get; set; }
        public int ParentID { get; set; }
        public int FirmaID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } 
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string EMail { get; set; }
        public string Adres { get; set; }
        public int KullaniciTipID { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public KullaniciTip KullaniciTip { get; set; }
        public Firma Firma { get; set; }
    }
}
