using HRManager.data.Custom_Conventions;
using HRManager.domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace HRManager.data
{
    public class HRManagerContext : DbContext
    {
        public HRManagerContext() : base("name=Database")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<HRManagerContext>(null);
            modelBuilder.Conventions.Add(new DateTime2Convention());

        }


        public System.Data.Entity.DbSet<HRManager.domain.Entities.DayOff> DayOff { get; set; }

        public System.Data.Entity.DbSet<HRManager.domain.Entities.Survey> Survey { get; set; }
        public System.Data.Entity.DbSet<HRManager.domain.Entities.Response> Response { get; set; }
        public System.Data.Entity.DbSet<HRManager.domain.Entities.Criterion> Criterion { get; set; }


    }
}
