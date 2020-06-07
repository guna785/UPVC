using DAL.DbContexts;
using DAL.Helper;
using DAL.Madals;
using DAL.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Athenticate : IAthenticate
    {
        UpvcContext context;
        public Athenticate()
        {
            context = new UpvcContext();
        }

        public async Task<AunthenticatedModel> authenticateuser(string uname, string password)
        {
            var adm =await context.admins.Find<admin>(x => x.uname.Equals(uname) && x.password.Equals(password)).FirstOrDefaultAsync();
            if (adm != null)
            {
                return new AunthenticatedModel() { role = Role.Admin, uname = adm.uname };

            }
            else
            {
                var usr= await context.users.Find<user>(x => x.uname.Equals(uname) && x.password.Equals(password)).FirstOrDefaultAsync();
                if (usr != null)
                {
                    return new AunthenticatedModel() { role = Role.User, uname = adm.uname };
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
