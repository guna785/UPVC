using DAL.Madals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
     public interface IAdminRepo
    {

        Task<admin> GetAdminByID(string ID);
        Task<admin> GetAdminByUsername(string uname);
        Task<IEnumerable<admin>> GetAdmin();

        Task<string> InserAdmin(admin _admin);
    }
}
