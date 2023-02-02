using Newtonsoft.Json;
using System.Collections.Generic;

namespace PhotoApp.PhotoAPI.Models
{
    public class ServiceResponse<T> : BaseResponse
    {
        [JsonProperty]
        public T Entity { get; set; }
        [JsonProperty]
        public List<T> Entities { get; set; }
        public int EntitiesCount { get; set; }

        public ServiceResponse()
        {
            ErrorsAndWarnings = new List<string>(); 
            Entities = new List<T>();
        }
    }
}
