using DAL.Madals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public interface IClientRepository
    {
        Task<client> GetClientID(string ID);
        Task<client> GetClientByPan(string pan);
        Task<IEnumerable<client>> GetClient();

        Task<bool> InserClient(client _client);
    }
}
