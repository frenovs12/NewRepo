namespace HRManagerWeb.Models
{
    using System.Data.Entity;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=HRManager")
        {
        }

        public virtual DbSet<evaluation> evaluations { get; set; }
        public virtual DbSet<fiche_evaluation> fiche_evaluation { get; set; }
        public virtual DbSet<formation> formations { get; set; }
        public virtual DbSet<log> logs { get; set; }
        public virtual DbSet<mission> missions { get; set; }
        public virtual DbSet<report> reports { get; set; }
        public virtual DbSet<skillsheet> skillsheets { get; set; }
        public virtual DbSet<t_skill> t_skill { get; set; }
        public virtual DbSet<task> tasks { get; set; }
        public virtual DbSet<tasktime> tasktimes { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<evaluation>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation>()
                .Property(e => e.TypeE)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.Salle)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.Skillz)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.title)
                .IsUnicode(false);



            modelBuilder.Entity<log>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<log>()
                .Property(e => e.user)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.location)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .HasMany(e => e.reports)
                .WithOptional(e => e.mission)
                .HasForeignKey(e => e.id_mission);

            modelBuilder.Entity<report>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<report>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<report>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<skillsheet>()
                .Property(e => e.level)
                .IsUnicode(false);

            modelBuilder.Entity<t_skill>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<t_skill>()
                .HasMany(e => e.missions)
                .WithOptional(e => e.t_skill)
                .HasForeignKey(e => e.id_skill);

            modelBuilder.Entity<t_skill>()
                .HasMany(e => e.skillsheets)
                .WithRequired(e => e.t_skill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<task>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .HasMany(e => e.task1)
                .WithOptional(e => e.task2)
                .HasForeignKey(e => e.parent_id);

            modelBuilder.Entity<task>()
                .HasMany(e => e.logs)
                .WithMany(e => e.tasks)
                .Map(m => m.ToTable("task_log", "hrmanager").MapLeftKey("Task_id").MapRightKey("logs_id"));

            modelBuilder.Entity<tasktime>()
                .HasMany(e => e.tasks)
                .WithOptional(e => e.tasktime)
                .HasForeignKey(e => e.duration_id);

            modelBuilder.Entity<tasktime>()
                .HasMany(e => e.tasks1)
                .WithOptional(e => e.tasktime1)
                .HasForeignKey(e => e.remaining_id);

            modelBuilder.Entity<tasktime>()
                .HasMany(e => e.tasks2)
                .WithOptional(e => e.tasktime2)
                .HasForeignKey(e => e.estimate_id);



            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                ;


        }
    }
}
