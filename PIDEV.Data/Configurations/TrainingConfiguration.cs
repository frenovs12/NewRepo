using PIDEV.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIDEV.Data.Configurations
{
    public class TrainingConfiguration : EntityTypeConfiguration<training>
    {
        public TrainingConfiguration()
        {
            ToTable("training");
            HasKey(t => t.id);
            HasOptional(f => f.user).WithMany(t => t.trainings).HasForeignKey(f => f.trainer_id).WillCascadeOnDelete(false);
                
        }

    }
}
