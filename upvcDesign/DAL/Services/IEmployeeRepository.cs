using DAL.Madals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public interface IEmployeeRepository
    {
        Task<user> GetEmployeeByID(string ID);
        Task<user> GetEmployeeByUsername(string uname);
        Task<IEnumerable<user>> GetEmployee();

        Task<bool> InserEmployee(user _emp);
        Task<bool> UpdateEmployee(user _emp);
        Task<bool> DeleteEmployee(string id);
    }
}
