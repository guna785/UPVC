﻿using BL.Services;
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

        public async Task<string> DeleteClient(string id)
        {
            var clt = await _repo.GetClientByPan(id);
            if (clt != null)
            {
                var res = await _repo.DeleteClient(clt.Id);
                if (res)
                {
                    return "Client data Deletion successfull";
                }
                else
                {
                    return "Client data Deletion Fails";
                }

            }
            else
            {
                return "Client does Not exists";
            }
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
                    return "Client data insertion successfull";
                }
                else
                {
                    return "Client data insertion Fails";
                }

            }
            else
            {
                return "Client User name already exists";
            }
        }

        public async Task<string> UpdateClient(client _emp)
        {
            var adm = await _repo.GetClientByPan(_emp.pan);
            if (adm != null)
            {
                _emp.Id = adm.Id;
                var res = await _repo.UpdateClient(_emp);
                if (res)
                {
                    return "Client data Updation successfull";
                }
                else
                {
                    return "Client data Updation Fails";
                }

            }
            else
            {
                return "Client User name Not exists";
            }
        }
    }
}
