using PhotoApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApp.Entities.Models
{
    public class Firma : IEntity
    {
        [Key]
        public int ID { get; set; }
        public bool Aktif { get; set; } 
        public string FirmaAdi { get; set; } 
        public DateTime InsertDate { get; set; } 
        public DateTime UpdateDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public List<User> Users { get; set; }

    }
}
