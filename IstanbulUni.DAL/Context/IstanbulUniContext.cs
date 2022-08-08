using IstanbulUni.DAL.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
           
            
        }
        public DbSet<WebMaster> WebMasters { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<WebMasterHistory> WebMasterHistories{ get; set; }
    }
}
