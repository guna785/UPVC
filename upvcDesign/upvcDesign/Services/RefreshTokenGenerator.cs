using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MongoDB.Driver.Core.Operations;

namespace upvcDesign.Services
{
    public class RefreshTokenGenerator
    {
        public string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
        public string GenerateRefreshToken(int size=32)
        {
            var refToken = new byte[size];
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(refToken);
                return Convert.ToBase64String(refToken);
            }
            
        }
    }
}
