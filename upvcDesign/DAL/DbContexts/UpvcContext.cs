using DAL.Madals;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DAL.DbContexts
{
    public class UpvcContext:DbContext
    {
        public UpvcContext(DbContextOptions<UpvcContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<admin>().ToTable("admin");
            modelBuilder.Entity<user>().ToTable("user");
            modelBuilder.Entity<companyprofile>().ToTable("companyprofile");
            modelBuilder.Entity<stock>().ToTable("stock");
            modelBuilder.Entity<client>().ToTable("client");
            modelBuilder.Entity<suplier>().ToTable("suplier");
        }
        public DbSet<user> users { get; set; }
        public DbSet<admin> admins { get; set; }
        public DbSet<companyprofile> companyprofiles { get; set; }
        public DbSet<stock> stocks { get; set; }
        public DbSet<client> clients { get; set; }
        public DbSet<suplier> supliers { get; set; }

    }
}
