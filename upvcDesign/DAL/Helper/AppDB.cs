using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Helper
{
    public class AppDB : IAppDB
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IAppDB
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

}
