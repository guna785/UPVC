using DAL.Madals;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using MongoDB.Driver;
using DAL.Helper;

namespace DAL.DbContexts
{
    public class UpvcContext
    {
        public UpvcContext(IAppDB settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            users = database.GetCollection<user>("user");
        }

        private readonly IMongoCollection<user> users;
    }
}
