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
    public class MeterialTypeRepository : IMeterialTypeRepository
    {
        private readonly UpvcContext context;
        public MeterialTypeRepository()
        {
            context = new UpvcContext();
        }
        public async Task<bool> DeleteMaterialType(string id)
        {
            FilterDefinition<MeterialType> filter = Builders<MeterialType>.Filter.Eq(m => m.Id, id);

            DeleteResult deleteResult = await context
                                                .MeterialTypes
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<MeterialType>> GetMaterialType()
        {
            return await context.MeterialTypes.Find(x => true).ToListAsync();
        }

        public async Task<MeterialType> GetMaterialTypeByName(string name)
        {
            return await context.MeterialTypes.Find<MeterialType>(a => a.name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<MeterialType> GetMaterialTypeID(string ID)
        {
            return await context.MeterialTypes.Find<MeterialType>(a => a.Id.Equals(ID)).FirstOrDefaultAsync();
        }

        public async Task<bool> InserMaterialType(MeterialType _typ)
        {
            try
            {
                await context.MeterialTypes.InsertOneAsync(_typ);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> UpdateMaterialType(MeterialType _typ)
        {
            try
            {
                ReplaceOneResult updateResult = await context.MeterialTypes.ReplaceOneAsync(g => g.Id == _typ.Id, replacement: _typ);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
