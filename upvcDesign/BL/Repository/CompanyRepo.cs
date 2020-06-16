using BL.Services;
using DAL.Madals;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repository
{
    public class CompanyRepo : ICompanyRepo
    {
        ICompanyRepositary _repo;
        public CompanyRepo(ICompanyRepositary repo)
        {
            _repo = repo;
        }
        public async Task<string> DeleteCompany(string id)
        {
            var clt = await _repo.GetCompany(id);
            if (clt != null)
            {
                var res = await _repo.DeleteCompany(clt.Id);
                if (res)
                {
                    return "Company Profile data Deletion successfull";
                }
                else
                {
                    return "Company Profile data Deletion Fails";
                }

            }
            else
            {
                return "Company Profile does Not exists";
            }
        }

        public async Task<companyprofile> GetCompany(string ID)
        {
            return await _repo.GetCompany(ID);
        }

        public async Task<IEnumerable<companyprofile>> GetCompany()
        {
            return await _repo.GetCompany();
        }

        public async Task<companyprofile> GetCompanyPan(string pan)
        {
            return await _repo.GetCompanyPan(pan);
        }

        public async Task<string> InserCompany(companyprofile _profile)
        {
            var adm = await _repo.GetCompanyPan(_profile.pan);
            if (adm == null)
            {
                var res = await _repo.InserCompany(_profile);
                if (res)
                {
                    return "Company Profile insertion successfull";
                }
                else
                {
                    return "Company Profile insertion Fails";
                }

            }
            else
            {
                return "Company Profile Pan already exists";
            }
        }

        public async Task<string> UpdateCompany(companyprofile _profile)
        {
            var adm = await _repo.GetCompany();
            if (adm.FirstOrDefault()!=null)
            {
                _profile.Id = adm.FirstOrDefault().Id;
                var res = await _repo.UpdateCompany(_profile);
                if (res)
                {
                    return "Company Profile Updation successfull";
                }
                else
                {
                    return "Company Profile Updation Fails";
                }

            }
            else
            {
                return "Company Profile Not exists";
            }
        }
    }
}
