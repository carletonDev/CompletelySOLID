using System;
using System.Threading.Tasks;
using ClassLibrary.AppSettings;
using ClassLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClassLibrary.EFAutoGen
{
    public partial class HospitalContext : DbContext,IHospitalContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Hospital> Hospital { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
        public virtual DbSet<UserRoleHospital> UserRoleHospital { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                AppConfiguration app = new AppConfiguration();
                optionsBuilder.UseSqlServer(app.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bills>(entity =>
            {
                entity.HasKey(e => e.BillId);

                entity.Property(e => e.BillId);

                entity.Property(e => e.Amount);

                entity.Property(e => e.HospitalId);

                entity.Property(e => e.UserId);

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.HospitalId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.Property(e => e.HospitalId);

                entity.Property(e => e.City)
                    .HasMaxLength(50);

                entity.Property(e => e.HospitalName)
                    .IsRequired();

                entity.Property(e => e.Street);

                entity.Property(e => e.Zip);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleId);

                entity.Property(e => e.RoleType)
                    .IsRequired();
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.Property(e => e.RoomId);

                entity.Property(e => e.HospitalId);

                entity.Property(e => e.Occupied);

                entity.Property(e => e.RoomName);

                entity.Property(e => e.RoomType)
                    .IsRequired();

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.Property(e => e.SalaryId);

                entity.Property(e => e.Amount);


                entity.Property(e => e.HospitalId);

                entity.Property(e => e.UserId);

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Salary)
                    .HasForeignKey(d => d.HospitalId);


                entity.HasOne(d => d.User)
                    .WithMany(p => p.Salary)
                    .HasForeignKey(d => d.UserId);

            });

            modelBuilder.Entity<UserRoleHospital>(entity =>
            {
                entity.HasKey(e => e.Urhid);

                entity.Property(e => e.Urhid);

                entity.Property(e => e.Endtime);

                entity.Property(e => e.HospitalId);

                entity.Property(e => e.RoleId);

                entity.Property(e => e.Starttime);

                entity.Property(e => e.UserId);

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.UserRoleHospital)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoleHospital)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoleHospital)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId);

                entity.Property(e => e.City)
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50);

                entity.Property(e => e.Insurance)
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50);

                entity.Property(e => e.Street);

                entity.Property(e => e.Zip);
            });
        }


        public void ModifyState(Users users)
        {
            HospitalContext context = new HospitalContext();
            context.Entry(users).State = EntityState.Modified;
        }

        public Task SaveChangesAsync()
        {
            HospitalContext hospital = new HospitalContext();
            return hospital.SaveChangesAsync();
        }
    }
}
