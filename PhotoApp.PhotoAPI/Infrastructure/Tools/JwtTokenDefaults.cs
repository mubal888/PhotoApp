using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.PhotoAPI.Infrastructure.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidIssuer = "http://localhost";
        public const string ValidAudience = "http://localhost";
        public const string Key = "PhotoJwtxTokens.";
        public const int Expire = 1;
    }
}
