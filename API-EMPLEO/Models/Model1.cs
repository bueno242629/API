using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace API_EMPLEO.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<APPLYJOB> APPLYJOB { get; set; }
        public virtual DbSet<GRADUATEPLUS> GRADUATEPLUS { get; set; }
        public virtual DbSet<JOB> JOB { get; set; }
        public virtual DbSet<MAILBOX> MAILBOX { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }
        public virtual DbSet<CAREERS> CAREERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GRADUATEPLUS>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<GRADUATEPLUS>()
                .Property(e => e.career)
                .IsUnicode(false);

            modelBuilder.Entity<GRADUATEPLUS>()
                .Property(e => e.photo);

            modelBuilder.Entity<JOB>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.requirements)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.companyName)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.companyAdress)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.schedule)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.contractJob)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.modality)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.userPass)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.cv);

            modelBuilder.Entity<USERS>()
                .Property(e => e.rol)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.career)
                .IsUnicode(false);
        }
    }
}
