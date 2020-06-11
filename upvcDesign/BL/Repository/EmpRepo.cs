using BL.Services;
using DAL.Madals;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repository
{
    public class EmpRepo : IEmpRepo
    {
        IEmployeeRepository _repo;
        public EmpRepo(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<user>> GetEmployee()
        {
            return await _repo.GetEmployee();
        }

        public async Task<user> GetEmployeeByID(string ID)
        {
            return await _repo.GetEmployeeByID(ID);
        }

        public async Task<user> GetEmployeeByUsername(string uname)
        {
            return await _repo.GetEmployeeByUsername(uname);
        }

        public async Task<string> InserEmployee(user _emp)
        {
            var adm = await _repo.GetEmployeeByUsername(_emp.uname);
            if (adm == null)
            {
                var res = await _repo.InserEmployee(_emp);
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
