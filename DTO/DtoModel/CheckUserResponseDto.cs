using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DtoModel
{
    public class CheckUserResponseDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string KullaniciTipId { get; set; } = null!;
        public bool IsExist { get; set; }

    }
}
