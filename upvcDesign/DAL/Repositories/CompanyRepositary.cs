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
    public class CompanyRepositary : ICompanyRepositary
    {
        private readonly UpvcContext context;
        public CompanyRepositary()
        {
            context = new UpvcContext();
        }
        public async Task<bool> DeleteCompany(string id)
        {
            FilterDefinition<companyprofile> filter = Builders<companyprofile>.Filter.Eq(m => m.Id, id);

            DeleteResult deleteResult = await context
                                                .companyprofiles
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<companyprofile> GetCompany(string ID)
        {
            return await context.companyprofiles.Find<companyprofile>(a => a.Id.Equals(ID)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<companyprofile>> GetCompany()
        {
            return await context.companyprofiles.Find(x => true).ToListAsync();
        }

        public async Task<companyprofile> GetCompanyPan(string pan)
        {
            return await context.companyprofiles.Find<companyprofile>(a => a.pan.Equals(pan)).FirstOrDefaultAsync();
        }

        public async Task<bool> InserCompany(companyprofile _profile)
        {
            try
            {
                await context.companyprofiles.InsertOneAsync(_profile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateCompany(companyprofile _profile)
        {
            try
            {
                ReplaceOneResult updateResult = await context.companyprofiles.ReplaceOneAsync(g => g.Id == _profile.Id, replacement: _profile);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
