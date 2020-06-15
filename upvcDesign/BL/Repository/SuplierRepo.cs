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

        public async Task<string> DeleteSuplier(string id)
        {
            var clt = await _repo.GetSuplierByPan(id);
            if (clt != null)
            {
                var res = await _repo.DeleteSuplier(clt.Id);
                if (res)
                {
                    return "Suplier data Deletion successfull";
                }
                else
                {
                    return "Suplier data Deletion Fails";
                }

            }
            else
            {
                return "Suplier does Not exists";
            }
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
                    return "Suplier data insertion successfull";
                }
                else
                {
                    return "Suplier data insertion Fails";
                }

            }
            else
            {
                return "Suplier User name already exists";
            }
        }

        public async Task<string> UpdateSuplier(suplier _sup)
        {
            var adm = await _repo.GetSuplierByPan(_sup.pan);
            if (adm != null)
            {
                _sup.Id = adm.Id;
                var res = await _repo.UpdateSuplier(_sup);
                if (res)
                {
                    return "Suplier data Updation successfull";
                }
                else
                {
                    return "Suplier data Updation Fails";
                }

            }
            else
            {
                return "Suplier User name Not exists";
            }
        }
    }
}
