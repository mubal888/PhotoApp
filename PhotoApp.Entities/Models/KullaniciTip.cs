using PhotoApp.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhotoApp.Entities.Models
{
    public class KullaniciTip : IEntity
    {
        [Key]
        public int ID { get; set; }
        public string Tip { get; set; }
        public List<User> Users { get; set; }
    }
}
