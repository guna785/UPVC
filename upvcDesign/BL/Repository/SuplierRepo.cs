using BL.Services;
using DAL.Madals;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repository
{
    public class SuplierRepo : ISuplierRepo
    {
        ISuplierRepository _repo;
        public SuplierRepo(ISuplierRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<suplier>> GetSuplier()
        {
            return await _repo.GetSuplier();
        }

        public async Task<suplier> GetSuplierByPan(string pan)
        {
            return await _repo.GetSuplierByPan(pan);
        }

        public async Task<suplier> GetSuplierID(string ID)
        {
            return await _repo.GetSuplierID(ID);
        }

        public async Task<string> InserSuplier(suplier _suplier)
        {

            var adm = await _repo.GetSuplierByPan(_suplier.pan);
            if (adm == null)
            {
                var res = await _repo.InserSuplier(_suplier);
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
