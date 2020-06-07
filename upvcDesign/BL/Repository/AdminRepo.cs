using BL.Services;
using DAL.Madals;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repository
{
    public class AdminRepo : IAdminRepo
    {
        IAdminRepositocry _repo;
        public AdminRepo(IAdminRepositocry repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<admin>> GetAdmin()
        {
            return await _repo.GetAdmin();
        }

        public async Task<admin> GetAdminByID(string ID)
        {
            return await _repo.GetAdminByID(ID);
        }

        public async Task<admin> GetAdminByUsername(string uname)
        {
            return await _repo.GetAdminByUsername(uname);
        }

        public async Task<string> InserAdmin(admin _admin)
        {
            var adm = await _repo.GetAdminByUsername(_admin.uname);
            if (adm == null)
            {
                var res= await _repo.InserAdmin(_admin);
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
