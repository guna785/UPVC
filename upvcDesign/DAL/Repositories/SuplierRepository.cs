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
    public class SuplierRepository : ISuplierRepository
    {
        private readonly UpvcContext context;
        public SuplierRepository()
        {
            context = new UpvcContext();
        }

        public async Task<bool> DeleteSuplier(string id)
        {
            FilterDefinition<suplier> filter = Builders<suplier>.Filter.Eq(m => m.Id, id);

            DeleteResult deleteResult = await context
                                                .supliers
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<suplier>> GetSuplier()
        {
            return await context.supliers.Find(x => true).ToListAsync();
        }

        public async Task<suplier> GetSuplierByPan(string pan)
        {
            return await context.supliers.Find<suplier>(a => a.pan.Equals(pan)).FirstOrDefaultAsync();
        }

        public async Task<suplier> GetSuplierID(string ID)
        {
            return await context.supliers.Find<suplier>(a => a.Id.Equals(ID)).FirstOrDefaultAsync();
        }

        public async Task<bool> InserSuplier(suplier _suplier)
        {
            try
            {
                await context.supliers.InsertOneAsync(_suplier);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateSuplier(suplier _sup)
        {
            try
            {
                ReplaceOneResult updateResult = await context.supliers.ReplaceOneAsync(g => g.pan == _sup.pan, replacement: _sup);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
