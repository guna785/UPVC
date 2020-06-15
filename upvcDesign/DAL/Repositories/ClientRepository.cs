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

        public async Task<bool> DeleteClient(string id)
        {
            FilterDefinition<client> filter = Builders<client>.Filter.Eq(m => m.Id, id);

            DeleteResult deleteResult = await context
                                                .clients
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
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

        public async Task<bool> UpdateClient(client _emp)
        {

            try
            {
                ReplaceOneResult updateResult = await context.clients.ReplaceOneAsync(g => g.pan == _emp.pan, replacement: _emp);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
