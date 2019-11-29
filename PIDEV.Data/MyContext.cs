using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIDEV.Data
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=User.Net")
        {

        }
        //les DbSet<> ....
        public DbSet<User> users { get; set; }
        //public DbSet<Producer> Producers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*modelBuilder.Configurations.Add(.....);
            modelBuilder.Conventions.Add(.....);*/
            modelBuilder.Configurations.Add(new ApplicationDbContext());
           

        }
    }
}
