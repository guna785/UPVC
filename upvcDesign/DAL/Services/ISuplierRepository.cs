using DAL.Madals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public interface ISuplierRepository
    {
        Task<suplier> GetSuplierID(string ID);
        Task<suplier> GetSuplierByPan(string pan);
        Task<IEnumerable<suplier>> GetSuplier();

        Task<bool> InserSuplier(suplier _suplier);
    }
}
