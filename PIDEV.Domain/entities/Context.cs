using PIDEV.Domain;
using System.Data.Entity;

namespace PIDEV.Data
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<answer> answers { get; set; }
        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<competence> competences { get; set; }
        public virtual DbSet<domain> domains { get; set; }
        public virtual DbSet<evaluation> evaluations { get; set; }
        public virtual DbSet<evaluationsheet> evaluationsheets { get; set; }
        public virtual DbSet<goal> goals { get; set; }
        public virtual DbSet<hibernate_sequences> hibernate_sequences { get; set; }
        public virtual DbSet<mission> missions { get; set; }
        public virtual DbSet<missionrequest> missionrequests { get; set; }
        public virtual DbSet<notification> notifications { get; set; }
        public virtual DbSet<project> projects { get; set; }
        public virtual DbSet<question> questions { get; set; }
        public virtual DbSet<reclamation> reclamations { get; set; }
        public virtual DbSet<result> results { get; set; }
        public virtual DbSet<task> tasks { get; set; }
        public virtual DbSet<team> teams { get; set; }
        public virtual DbSet<ticket> tickets { get; set; }
        public virtual DbSet<topic> topics { get; set; }
        public virtual DbSet<training> trainings { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<answer>()
                .Property(e => e.type_reponse)
                .IsUnicode(false);

            modelBuilder.Entity<bill>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<bill>()
                .Property(e => e.matricule)
                .IsUnicode(false);

            modelBuilder.Entity<competence>()
                .Property(e => e.description_c)
                .IsUnicode(false);

            modelBuilder.Entity<competence>()
                .Property(e => e.Famille)
                .IsUnicode(false);

            modelBuilder.Entity<competence>()
                .Property(e => e.metier)
                .IsUnicode(false);

            modelBuilder.Entity<competence>()
                .Property(e => e.nom_c)
                .IsUnicode(false);

            modelBuilder.Entity<domain>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<domain>()
                .HasMany(e => e.topics)
                .WithOptional(e => e.domain)
                .HasForeignKey(e => e.domain_id);

            modelBuilder.Entity<evaluation>()
                .Property(e => e.evalname)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation>()
                .Property(e => e.evaltype)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation>()
                .HasMany(e => e.goals)
                .WithOptional(e => e.evaluation)
                .HasForeignKey(e => e.evaluation_id_evaluation);

            modelBuilder.Entity<evaluation>()
                .HasMany(e => e.users)
                .WithMany(e => e.evaluations)
                .Map(m => m.ToTable("user_evaluation").MapLeftKey("evaluations_id_evaluation").MapRightKey("User_id"));

            modelBuilder.Entity<evaluationsheet>()
                .Property(e => e.appreciation)
                .IsUnicode(false);

            modelBuilder.Entity<evaluationsheet>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<goal>()
                .Property(e => e.goalLevel)
                .IsUnicode(false);

            modelBuilder.Entity<goal>()
                .Property(e => e.goalType)
                .IsUnicode(false);

            modelBuilder.Entity<goal>()
                .Property(e => e.objectif_txt)
                .IsUnicode(false);

            modelBuilder.Entity<hibernate_sequences>()
                .Property(e => e.sequence_name)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.DateF)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.dateD)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.location)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .HasMany(e => e.bills)
                .WithOptional(e => e.mission)
                .HasForeignKey(e => e.idMission);

            modelBuilder.Entity<mission>()
                .HasMany(e => e.missionrequests)
                .WithOptional(e => e.mission)
                .HasForeignKey(e => e.mission_id);

            modelBuilder.Entity<missionrequest>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.contenu)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.titre)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .HasMany(e => e.missions)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.idProject);

            modelBuilder.Entity<project>()
                .HasMany(e => e.tasks)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.project_id);

            modelBuilder.Entity<project>()
                .HasMany(e => e.tickets)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.project_id);

            modelBuilder.Entity<project>()
                .HasMany(e => e.users)
                .WithMany(e => e.projects)
                .Map(m => m.ToTable("user_project").MapLeftKey("projects_id").MapRightKey("users_id"));

            modelBuilder.Entity<question>()
                .Property(e => e.complexity)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.enonce)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.indice)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.reponsejuste)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .HasMany(e => e.answers)
                .WithOptional(e => e.question)
                .HasForeignKey(e => e.question_id);

            modelBuilder.Entity<reclamation>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<reclamation>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<reclamation>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<reclamation>()
                .Property(e => e.objet)
                .IsUnicode(false);

            modelBuilder.Entity<result>()
                .Property(e => e.result1)
                .IsUnicode(false);

            modelBuilder.Entity<result>()
                .Property(e => e.statut)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<team>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<team>()
                .HasMany(e => e.users)
                .WithOptional(e => e.team)
                .HasForeignKey(e => e.team_id);

            modelBuilder.Entity<ticket>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<ticket>()
                .Property(e => e.place)
                .IsUnicode(false);

            modelBuilder.Entity<ticket>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<ticket>()
                .Property(e => e.typeTicket)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .HasMany(e => e.questions)
                .WithOptional(e => e.topic)
                .HasForeignKey(e => e.topic_id);

            modelBuilder.Entity<topic>()
                .HasMany(e => e.reclamations)
                .WithOptional(e => e.topic)
                .HasForeignKey(e => e.topic_id);

            modelBuilder.Entity<topic>()
                .HasMany(e => e.results)
                .WithOptional(e => e.topic)
                .HasForeignKey(e => e.idtopic);

            modelBuilder.Entity<training>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<training>()
                .Property(e => e.room)
                .IsUnicode(false);

            modelBuilder.Entity<training>()
                .Property(e => e.subject)
                .IsUnicode(false);

            modelBuilder.Entity<training>()
                .HasMany(e => e.users)
                .WithMany(e => e.trainings1)
                .Map(m => m.ToTable("user_training").MapLeftKey("employeesTrainings_id").MapRightKey("participants_id"));

            modelBuilder.Entity<user>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.work_departement)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.missionrequests)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.notifications)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.reclamations)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.results)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.iduser);

            modelBuilder.Entity<user>()
                .HasMany(e => e.tasks)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.tickets)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.trainings)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.trainer_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.missions)
                .WithMany(e => e.users)
                .Map(m => m.ToTable("user_mission"));
        }
    }
}
