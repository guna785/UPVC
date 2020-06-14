using DAL.Madals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public interface IClientRepo
    {
        Task<client> GetClientID(string ID);
        Task<client> GetClientByPan(string pan);
        Task<IEnumerable<client>> GetClient();

        Task<string> InserClient(client _client);
    }
}
