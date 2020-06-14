using BL.Services;
using DAL.Madals;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repository
{
    public class ClientRepo : IClientRepo
    {
        IClientRepository _repo;
        public ClientRepo(IClientRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<client>> GetClient()
        {
            return await _repo.GetClient();
        }

        public async Task<client> GetClientByPan(string pan)
        {
            return await _repo.GetClientByPan(pan);
        }

        public async Task<client> GetClientID(string ID)
        {
            return await _repo.GetClientID(ID);
        }

        public async Task<string> InserClient(client _client)
        {
            var adm = await _repo.GetClientByPan(_client.pan);
            if (adm == null)
            {
                var res = await _repo.InserClient(_client);
                if (res)
                {
                    return "Admin data insertion successfull";
                }
                else
                {
                    return "Admin data insertion Fails";
                }

            }
            else
            {
                return "Admin User name already exists";
            }
        }
    }
}
