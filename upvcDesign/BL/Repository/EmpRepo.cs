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

        public async Task<string> DeleteEmployee(string id)
        {
            var adm = await _repo.GetEmployeeByUsername(id);
            if (adm != null)
            {
                var res = await _repo.DeleteEmployee(adm.Id);
                if (res)
                {
                    return "Employee data Deletion successfull";
                }
                else
                {
                    return "Employee data Deletion Fails";
                }

            }
            else
            {
                return "Employee does Not exists";
            }
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
                    return "Employee data insertion successfull";
                }
                else
                {
                    return "Employee data insertion Fails";
                }

            }
            else
            {
                return "Employee User name already exists";
            }
        }

        public async Task<string> UpdateEmployee(user _emp)
        {
            var adm = await _repo.GetEmployeeByUsername(_emp.uname);
            if (adm != null)
            {
                _emp.Id = adm.Id;
                var res = await _repo.UpdateEmployee(_emp);
                if (res)
                {
                    return "Employee data Updation successfull";
                }
                else
                {
                    return "Employee data Updation Fails";
                }

            }
            else
            {
                return "Employee User name Not exists";
            }
        }
    }
}
