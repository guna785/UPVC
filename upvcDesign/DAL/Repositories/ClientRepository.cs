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
    public class ClientRepository : IClientRepository
    {
        private readonly UpvcContext context;
        public ClientRepository()
        {
            context = new UpvcContext();
        }
        public async Task<IEnumerable<client>> GetClient()
        {
            return await context.clients.Find(x => true).ToListAsync();
        }

        public async Task<client> GetClientByPan(string pan)
        {
            return await context.clients.Find<client>(a => a.pan.Equals(pan)).FirstOrDefaultAsync();
        }

        public async Task<client> GetClientID(string ID)
        {
            return await context.clients.Find<client>(a => a.Id.Equals(ID)).FirstOrDefaultAsync();
        }

        public async Task<bool> InserClient(client _client)
        {
            try
            {
                await context.clients.InsertOneAsync(_client);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
