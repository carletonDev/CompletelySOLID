﻿using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public partial class HospitalContext : DbContext,IHospitalContext
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


    }
}
