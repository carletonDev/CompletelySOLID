using System;
using ClassLibrary.AppSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClassLibrary.Pharmacy
{
    public partial class PharmacyContext : DbContext
    {
        public PharmacyContext()
        {
        }

        public PharmacyContext(DbContextOptions<PharmacyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<Pharmacy> Pharmacy { get; set; }
        public virtual DbSet<PharmacyMedicine> PharmacyMedicine { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                AppConfiguration app = new AppConfiguration();
                optionsBuilder.UseSqlServer(app.PharmacyString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.MedicineId).HasColumnName("medicineId");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.MedicineName)
                    .HasColumnName("medicineName")
                    .HasMaxLength(50);

                entity.Property(e => e.MedicineType)
                    .HasColumnName("medicineType")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Pharmacy>(entity =>
            {
                entity.Property(e => e.PharmacyId).HasColumnName("pharmacyId");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.PharmacyAddress)
                    .HasColumnName("pharmacyAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.PharmacyName)
                    .HasColumnName("pharmacyName")
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(30);

                entity.Property(e => e.Zip).HasColumnName("zip");
            });

            modelBuilder.Entity<PharmacyMedicine>(entity =>
            {
                entity.HasKey(e => e.Pmid);

                entity.Property(e => e.Pmid).HasColumnName("pmid");

                entity.Property(e => e.InStock).HasColumnName("inStock");

                entity.Property(e => e.MedicineId).HasColumnName("medicineId");

                entity.Property(e => e.PharmacyId).HasColumnName("pharmacyId");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.PharmacyMedicine)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__PharmacyM__medic__276EDEB3");

                entity.HasOne(d => d.Pharmacy)
                    .WithMany(p => p.PharmacyMedicine)
                    .HasForeignKey(d => d.PharmacyId)
                    .HasConstraintName("FK__PharmacyM__pharm__286302EC");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.RoleType)
                    .HasColumnName("roleType")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.Property(e => e.SalaryId).HasColumnName("salaryId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PharmacyId).HasColumnName("pharmacyId");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Salary)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Salary__employee__32E0915F");

                entity.HasOne(d => d.Pharmacy)
                    .WithMany(p => p.Salary)
                    .HasForeignKey(d => d.PharmacyId)
                    .HasConstraintName("FK__Salary__pharmacy__33D4B598");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.DateTransaction)
                    .HasColumnName("dateTransaction")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TransactionsCustomer)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Transacti__custo__300424B4");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TransactionsEmployee)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Transacti__emplo__2F10007B");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(30);

                entity.Property(e => e.UserAddress)
                    .HasColumnName("userAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.Zip).HasColumnName("zip");
            });
        }
    }
}
