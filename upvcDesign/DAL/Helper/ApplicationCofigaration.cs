using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
namespace DAL.Helper
{
    public class ApplicationCofigaration
    {
        public ApplicationCofigaration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var conStrConfig = root.GetSection("UpvcDatabaseSettings:ConnectionString");
            var conDB = root.GetSection("UpvcDatabaseSettings:DatabaseName");
            connectionString = conStrConfig.Value;
            DB = conDB.Value;
        }
        public string connectionString { get; set; }
        public string DB { get; set; }
    }
}
