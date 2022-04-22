using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EFCore.Entities;

#nullable disable

namespace EFCore.Context
{
    public partial class CS_Niklas_NegriContext : DbContext
    {
        public CS_Niklas_NegriContext()
        {
        }

        public CS_Niklas_NegriContext(DbContextOptions<CS_Niklas_NegriContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cabin> Cabins { get; set; }
        public virtual DbSet<CabinCamper> CabinCampers { get; set; }
        public virtual DbSet<CabinCounselor> CabinCounselors { get; set; }
        public virtual DbSet<Camper> Campers { get; set; }
        public virtual DbSet<CamperNextOfKin> CamperNextOfKins { get; set; }
        public virtual DbSet<Counselor> Counselors { get; set; }
        public virtual DbSet<NextOfKin> NextOfKins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-T2GL85N\\SQLEXPRESS2017;Initial Catalog=CS_Niklas_Negri;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cabin>(entity =>
            {
                entity.ToTable("Cabin");
            });

            modelBuilder.Entity<CabinCamper>(entity =>
            {
                entity.ToTable("CabinCamper");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Cabin)
                    .WithMany(p => p.CabinCampers)
                    .HasForeignKey(d => d.CabinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CabinCamper_Cabin");

                entity.HasOne(d => d.Camper)
                    .WithMany(p => p.CabinCampers)
                    .HasForeignKey(d => d.CamperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CabinCamper_Camper");
            });

            modelBuilder.Entity<CabinCounselor>(entity =>
            {
                entity.ToTable("CabinCounselor");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Cabin)
                    .WithMany(p => p.CabinCounselors)
                    .HasForeignKey(d => d.CabinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CabinCounselor_Cabin");

                entity.HasOne(d => d.Counselor)
                    .WithMany(p => p.CabinCounselors)
                    .HasForeignKey(d => d.CounselorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CabinCounselor_Counselor");
            });

            modelBuilder.Entity<Camper>(entity =>
            {
                entity.ToTable("Camper");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CamperNextOfKin>(entity =>
            {
                entity.ToTable("CamperNextOfKin");

                entity.HasOne(d => d.Camper)
                    .WithMany(p => p.CamperNextOfKins)
                    .HasForeignKey(d => d.CamperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CamperNextOfKin_Camper");

                entity.HasOne(d => d.NextOfKin)
                    .WithMany(p => p.CamperNextOfKins)
                    .HasForeignKey(d => d.NextOfKinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CamperNextOfKin_NextOfKin");
            });

            modelBuilder.Entity<Counselor>(entity =>
            {
                entity.ToTable("Counselor");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NextOfKin>(entity =>
            {
                entity.ToTable("NextOfKin");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EmergencyPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
