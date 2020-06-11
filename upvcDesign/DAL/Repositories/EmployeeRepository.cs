using DAL.DbContexts;
using DAL.Madals;
using DAL.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly UpvcContext context;
        public EmployeeRepository()
        {
            context = new UpvcContext();
        }
        public async Task<IEnumerable<user>> GetEmployee()
        {
            return await context.users.Find(x => true).ToListAsync();
        }

        public async Task<user> GetEmployeeByID(string ID)
        {
            return await context.users.Find<user>(a => a.ID.Equals(ID)).FirstOrDefaultAsync();
        }

        public async Task<user> GetEmployeeByUsername(string uname)
        {
            return await context.users.Find<user>(a => a.uname.Equals(uname)).FirstOrDefaultAsync();
        }

        public async Task<bool> InserEmployee(user _emp)
        {
            try
            {
                await context.users.InsertOneAsync(_emp);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
