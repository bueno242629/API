using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_JOB.Models
{
    public partial class EmploymentDBContext : DbContext
    {
        public EmploymentDBContext()
        {
        }

        public EmploymentDBContext(DbContextOptions<EmploymentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Applyjob> Applyjob { get; set; }
        public virtual DbSet<Careers> Careers { get; set; }
        public virtual DbSet<Graduateplus> Graduateplus { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Mailbox> Mailbox { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applyjob>(entity =>
            {
                entity.HasKey(e => e.ApplyId)
                    .HasName("PK__APPLYJOB__A95A27EEC1B9A7B9");

                entity.ToTable("APPLYJOB");

                entity.Property(e => e.ApplyId).HasColumnName("applyId");

                entity.Property(e => e.JobId).HasColumnName("jobId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Applyjob)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__APPLYJOB__jobId__1A14E395");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Applyjob)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__APPLYJOB__userId__1920BF5C");
            });

            modelBuilder.Entity<Careers>(entity =>
            {
                entity.HasKey(e => e.CareerId)
                    .HasName("PK__CAREERS__B87545E89F05C45C");

                entity.ToTable("CAREERS");

                entity.Property(e => e.CareerId).HasColumnName("careerId");

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Career)
                    .HasColumnName("career")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Graduateplus>(entity =>
            {
                entity.HasKey(e => e.GradId)
                    .HasName("PK__GRADUATE__4813B895C4FE5C4E");

                entity.ToTable("GRADUATEPLUS");

                entity.Property(e => e.GradId).HasColumnName("gradId");

                entity.Property(e => e.Career)
                    .IsRequired()
                    .HasColumnName("career")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionGrad)
                    .IsRequired()
                    .HasColumnName("descriptionGrad");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Photo).HasColumnName("photo");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("JOB");

                entity.Property(e => e.JobId).HasColumnName("jobId");

                entity.Property(e => e.Career)
                    .HasColumnName("career")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyAdress)
                    .IsRequired()
                    .HasColumnName("companyAdress")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("companyName")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ContractJob)
                    .HasColumnName("contractJob")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateStart)
                    .HasColumnName("dateStart")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionJob)
                    .IsRequired()
                    .HasColumnName("descriptionJob");

                entity.Property(e => e.Modality)
                    .HasColumnName("modality")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Requirements)
                    .IsRequired()
                    .HasColumnName("requirements")
                    .IsUnicode(false);

                entity.Property(e => e.Schedule)
                    .IsRequired()
                    .HasColumnName("schedule")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mailbox>(entity =>
            {
                entity.HasKey(e => e.MailId)
                    .HasName("PK__MAILBOX__F5CD78A8A5FF461F");

                entity.ToTable("MAILBOX");

                entity.Property(e => e.MailId).HasColumnName("mailId");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment");

                entity.Property(e => e.dateStart)
                    .HasColumnName("dateStart")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                

                entity.Property(e => e.name)
                    .HasColumnName("name")
                    .HasMaxLength(500)
                    .IsUnicode(false);


                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Mailbox)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__MAILBOX__userId__164452B1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__USERS__CB9A1CFFC4EA7A07");

                entity.ToTable("USERS");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Career)
                    .HasColumnName("career")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Cv).HasColumnName("cv");

                entity.Property(e => e.CvName)
                    .HasColumnName("cvName")
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasColumnName("rol")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPass)
                    .IsRequired()
                    .HasColumnName("userPass")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
