using DAL.DbContexts;
using DAL.Madals;
using DAL.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AdminRepositocry : IAdminRepositocry
    {
        private readonly UpvcContext context;
        public AdminRepositocry()
        {
            context = new UpvcContext();
        }

        public async Task<IEnumerable<admin>> GetAdmin()
        {
            return await context.admins.Find(x=>true).ToListAsync();
        }

        public async Task<admin> GetAdminByID(string ID)
        {
            return await context.admins.Find<admin>(a => a.ID.Equals(ID)).FirstOrDefaultAsync();
        }

        public async Task<admin> GetAdminByUsername(string uname)
        {
            return await context.admins.Find<admin>(a => a.uname.Equals(uname)).FirstOrDefaultAsync();
        }

        public async Task<bool> InserAdmin(admin _admin)
        {
            try
            {
                await context.admins.InsertOneAsync(_admin);
                return true;
            }
            catch
            {
                return false;
            }         

        }
    }
}
