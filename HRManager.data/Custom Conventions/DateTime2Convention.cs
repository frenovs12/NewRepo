using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HRManager.data.Custom_Conventions
{
    public class DateTime2Convention : Convention
    {
        public DateTime2Convention()
        {
            Properties<DateTime>().Configure(c => c.HasColumnType("DateTime2"));
        }

    }
}
