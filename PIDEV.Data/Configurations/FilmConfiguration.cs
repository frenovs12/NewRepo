using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    public class FilmConfiguration:EntityTypeConfiguration<Film>
    {
        //ctor + double tab
        public FilmConfiguration()
        {
            HasOptional(f => f.Producer).
                WithMany(p => p.Films).
                HasForeignKey(f=>f.ProducerId).
                WillCascadeOnDelete(false);

        }
    }
}
