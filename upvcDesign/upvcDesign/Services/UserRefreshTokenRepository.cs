using DAL.Madals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using upvcDesign.Helper;

namespace upvcDesign.Services
{
    public interface IUserRefreshTokenRepository
    {
        void SaveOrUpdateUserRefreshToken(UserRefreshToken refreshToken);
        bool CheckIfRefreshTokenIsValid(string username, string refreshToken);
    }
    public class UserRefreshTokenRepository : IUserRefreshTokenRepository
    {
        public static Dictionary<string, string> RefreshToken;
        public UserRefreshTokenRepository()
        {
            RefreshToken = new Dictionary<string, string>();
        }
        public bool CheckIfRefreshTokenIsValid(string username, string refreshToken)
        {
            string refToken = "";
            RefreshToken.TryGetValue(username, out refToken);
            return refToken.Equals(refreshToken);
        }

        public void SaveOrUpdateUserRefreshToken(UserRefreshToken refreshToken)
        {
            if (RefreshToken.ContainsKey(refreshToken.UserName))
            {
                RefreshToken[refreshToken.UserName]= refreshToken.RefreshToken;
            }
            else
            {
                RefreshToken.Add(refreshToken.UserName, refreshToken.RefreshToken);
            }
        }
    }
}
