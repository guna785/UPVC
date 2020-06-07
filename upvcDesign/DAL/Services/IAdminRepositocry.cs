using DAL.Madals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public interface IAdminRepositocry
    {
        Task<admin> GetAdminByID(string ID);
        Task<admin> GetAdminByUsername(string uname);
        Task<IEnumerable<admin>> GetAdmin();

        Task<bool> InserAdmin(admin _admin);
    }
}
