using DAL.Madals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public interface ICompanyRepo
    {
        Task<companyprofile> GetCompany(string ID);
        Task<companyprofile> GetCompanyPan(string pan);
        Task<IEnumerable<companyprofile>> GetCompany();

        Task<string> InserCompany(companyprofile _profile);
        Task<string> UpdateCompany(companyprofile _profile);
        Task<string> DeleteCompany(string id);
    }
}
