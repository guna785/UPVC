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
        
        public UpvcContext()
        {
            var appConfig = new ApplicationCofigaration();
            var client = new MongoClient(appConfig.connectionString);
            var database = client.GetDatabase(appConfig.DB);
            users = database.GetCollection<user>("user");
            admins = database.GetCollection<admin>("admin");
            clients = database.GetCollection<client>("client");
            supliers = database.GetCollection<suplier>("suplier");
            companyprofiles = database.GetCollection<companyprofile>("companyprofile");
            stocks = database.GetCollection<stock>("stock");
            MeterialTypes = database.GetCollection<MeterialType>("MeterialType");

        }

        public IMongoCollection<user> users { get; set; }
        public IMongoCollection<admin> admins { get; set; }
        public IMongoCollection<client> clients { get; set; }
        public IMongoCollection<suplier> supliers { get; set; }
        public IMongoCollection<companyprofile> companyprofiles { get; set; }
        public IMongoCollection<stock> stocks { get; set; }
        public IMongoCollection<MeterialType> MeterialTypes { get; set; }
    }
}
