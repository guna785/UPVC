using DAL.Madals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public interface IEmpRepo
    {
        Task<user> GetEmployeeByID(string ID);
        Task<user> GetEmployeeByUsername(string uname);
        Task<IEnumerable<user>> GetEmployee();

        Task<string> InserEmployee(user _emp);
    }
}
