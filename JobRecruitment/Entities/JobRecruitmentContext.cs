using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

namespace JobRecruitment.Entities
{
    public partial class JobRecruitmentContext : DbContext
    {
        public JobRecruitmentContext()
        {
        }

        public JobRecruitmentContext(DbContextOptions<JobRecruitmentContext> options)
            : base(options)
        {
        }

        private readonly ILoggerFactory loggerFactory = LoggerFactory.Create(o => o.AddConsole());
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Companys> Companys { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Requirements> Requirements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLoggerFactory(loggerFactory);
                optionsBuilder.UseSqlServer("Data Source=.;database=JobRecruitment;uid=sa;pwd=1qaz2wsx");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>(entity =>
            {
                entity.Property(e => e.CityName).HasMaxLength(50);
            });

            modelBuilder.Entity<Companys>(entity =>
            {
                entity.Property(e => e.CompanyAddress).HasMaxLength(100);

                entity.Property(e => e.CompanyIntroduce).HasMaxLength(500);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.CompanyNature).HasMaxLength(50);

                entity.Property(e => e.CompanySize).HasMaxLength(50);

                entity.Property(e => e.IndustryType).HasMaxLength(50);
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
              
                entity.Property(e => e.Education).HasMaxLength(50);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.JobPay).HasMaxLength(50);

                entity.Property(e => e.PublishTime).HasColumnType("datetime");

                entity.Property(e => e.Welfare).HasMaxLength(500);

                entity.Property(e => e.WorkArea)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.WorkExperience).HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Jobs_Companys");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Jobs_Jobs1");
            });
            modelBuilder.Entity<Jobs>().Property(b => b.Id)
                .ValueGeneratedNever(); //.ValueGeneratedOnAdd();
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
