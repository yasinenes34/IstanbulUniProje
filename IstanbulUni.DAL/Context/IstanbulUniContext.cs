using IstanbulUni.DAL.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace IstanbulUni.DAL.Context
{
    public partial class IstanbulUniContext : DbContext
    {
        public IstanbulUniContext()
            : base("name=IstanbulUniContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
        public DbSet<WebMaster> WebMasters { get; set; }
        public DbSet<User> Users{ get; set; }
    }
}
