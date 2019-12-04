namespace PIDOTNET.DATA.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model4 : DbContext
    {
        public Model4()
            : base("name=Model4")
        {
        }

        public virtual DbSet<C__migrationhistory> C__migrationhistory { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<evaluation> evaluations { get; set; }
        public virtual DbSet<evaluation360> evaluation360 { get; set; }
        public virtual DbSet<ficheevaluation> ficheevaluations { get; set; }
        public virtual DbSet<mission> missions { get; set; }
        public virtual DbSet<missionexpens> missionexpenses { get; set; }
        public virtual DbSet<pi4gl_employee> pi4gl_employee { get; set; }
        public virtual DbSet<pi4gl_evaluation> pi4gl_evaluation { get; set; }
        public virtual DbSet<pi4gl_evaluation360> pi4gl_evaluation360 { get; set; }
        public virtual DbSet<pi4gl_ficheevaluation> pi4gl_ficheevaluation { get; set; }
        public virtual DbSet<pi4gl_mission> pi4gl_mission { get; set; }
        public virtual DbSet<pi4gl_missionexpenses> pi4gl_missionexpenses { get; set; }
        public virtual DbSet<pi4gl_repayment> pi4gl_repayment { get; set; }
        public virtual DbSet<repayment> repayments { get; set; }
        public virtual DbSet<task> tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<C__migrationhistory>()
                .Property(e => e.MigrationId)
                .IsUnicode(false);

            modelBuilder.Entity<C__migrationhistory>()
                .Property(e => e.ContextKey)
                .IsUnicode(false);

            modelBuilder.Entity<C__migrationhistory>()
                .Property(e => e.ProductVersion)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.ficheevaluations)
                .WithRequired(e => e.employee)
                .HasForeignKey(e => e.idEmployee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.evaluations)
                .WithMany(e => e.employees)
                .Map(m => m.ToTable("employee_evaluation").MapRightKey("evaluations_id"));

            modelBuilder.Entity<evaluation>()
                .Property(e => e.nameEvaluation)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation>()
                .Property(e => e.typeEvaluation)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation>()
                .HasMany(e => e.ficheevaluations)
                .WithRequired(e => e.evaluation)
                .HasForeignKey(e => e.idEvaluation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<evaluation360>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation360>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation360>()
                .Property(e => e.avis)
                .IsUnicode(false);

            modelBuilder.Entity<ficheevaluation>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<ficheevaluation>()
                .Property(e => e.desription)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.place)
                .IsUnicode(false);

            modelBuilder.Entity<pi4gl_employee>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<pi4gl_employee>()
                .HasMany(e => e.pi4gl_ficheevaluation)
                .WithRequired(e => e.pi4gl_employee)
                .HasForeignKey(e => e.idEmployee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pi4gl_evaluation>()
                .Property(e => e.nameEvaluation)
                .IsUnicode(false);

            modelBuilder.Entity<pi4gl_evaluation>()
                .Property(e => e.typeEvaluation)
                .IsUnicode(false);

            modelBuilder.Entity<pi4gl_evaluation>()
                .HasMany(e => e.pi4gl_ficheevaluation)
                .WithRequired(e => e.pi4gl_evaluation)
                .HasForeignKey(e => e.idEvaluation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pi4gl_evaluation360>()
                .Property(e => e.nameEvaluation)
                .IsUnicode(false);

            modelBuilder.Entity<pi4gl_evaluation360>()
                .Property(e => e.avisEvaluation)
                .IsUnicode(false);

            modelBuilder.Entity<pi4gl_ficheevaluation>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<pi4gl_ficheevaluation>()
                .Property(e => e.desription)
                .IsUnicode(false);

            modelBuilder.Entity<pi4gl_mission>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<pi4gl_mission>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<pi4gl_mission>()
                .Property(e => e.place)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.task1)
                .IsUnicode(false);
        }
    }
}
