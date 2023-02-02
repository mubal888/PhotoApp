using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.PhotoAPI.Models
{
    public abstract class BaseResponse
    {
        public List<string> ErrorsAndWarnings { get; set; } 
        public bool HasError { get; set; }
        public bool IsSuccessFul { get; set; }
    }
}
