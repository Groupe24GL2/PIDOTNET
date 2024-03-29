namespace PIDOTNET.DATA.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
      

        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<evaluation> evaluations { get; set; }
        public virtual DbSet<ficheevaluation> ficheevaluations { get; set; }
        public virtual DbSet<mission> missions { get; set; }
        public virtual DbSet<missionexpens> missionexpenses { get; set; }
        public virtual DbSet<repayment> repayments { get; set; }
        public virtual DbSet<task> tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<task>()
                .Property(e => e.task1)
                .IsUnicode(false);
        }
    }
}
