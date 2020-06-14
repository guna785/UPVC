using DAL.Madals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public interface ISuplierRepo
    {
        Task<suplier> GetSuplierID(string ID);
        Task<suplier> GetSuplierByPan(string pan);
        Task<IEnumerable<suplier>> GetSuplier();

        Task<string> InserSuplier(suplier _suplier);
    }
}
