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

        public async Task<bool> DeleteEmployee(string id)
        {
            FilterDefinition<user> filter = Builders<user>.Filter.Eq(m => m.Id, id);

            DeleteResult deleteResult = await context
                                                .users
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<user>> GetEmployee()
        {
            return await context.users.Find(x => true).ToListAsync();
        }

        public async Task<user> GetEmployeeByID(string ID)
        {
            return await context.users.Find<user>(a => a.Id.Equals(ID)).FirstOrDefaultAsync();
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

        public async Task<bool> UpdateEmployee(user _emp)
        {
            try
            {
                ReplaceOneResult updateResult = await context.users.ReplaceOneAsync(g => g.uname == _emp.uname, replacement: _emp);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
