using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.EFAutoGen
{
   public interface IHospitalContext
    {
        DbSet<Users> Users { get; set; }

        DbSet<Hospital> Hospital { get; set; }

        DbSet<Bills> Bills { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<Rooms> Rooms { get; set; }
        DbSet<Salary> Salary { get; set; }
        DbSet<UserRoleHospital> UserRoleHospital { get; set; }

        Task SaveChangesAsync();
        void ModifyState(Users users);

    }
}
