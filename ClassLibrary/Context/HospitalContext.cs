using ClassLibrary.AppSettings;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.Context
{

    public partial class HospitalContext : DbContext
    {
        public HospitalContext() { }
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }

        public virtual DbSet<Users> Users { get; set; }

        public virtual DbSet<Hospital>Hospital{get;set;}
        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
        public virtual DbSet<UserRoleHospital> UserRoleHospital { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              AppConfiguration app = new AppConfiguration();
              optionsBuilder.UseSqlServer(app.HospitalString);
            }
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
