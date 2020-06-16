using DAL.Madals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public interface ICompanyRepositary
    {
        Task<companyprofile> GetCompany(string ID);
        Task<companyprofile> GetCompanyPan(string pan);
        Task<IEnumerable<companyprofile>> GetCompany();

        Task<bool> InserCompany(companyprofile _profile);
        Task<bool> UpdateCompany(companyprofile _profile);
        Task<bool> DeleteCompany(string id);
    }
}
