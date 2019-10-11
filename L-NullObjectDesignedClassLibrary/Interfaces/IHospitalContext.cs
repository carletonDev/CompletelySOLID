using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Interfaces
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

    }
}
