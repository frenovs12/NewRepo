using Solution.Data.Configurations;
using Solution.Data.CustomConventions;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.Domain.Entities;

namespace Solution.Data
{
    public class MyContext:DbContext
    {
        public MyContext():base("name=MaChaine")
        {

        }
        //les DbSet<> ....
        public DbSet<Film> Films { get; set; }
        public DbSet<Producer> Producers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*modelBuilder.Configurations.Add(.....);
            modelBuilder.Conventions.Add(.....);*/
            modelBuilder.Configurations.Add(new FilmConfiguration());
            modelBuilder.Conventions.Add(new DateTime2Convention());

        }
    }
}
