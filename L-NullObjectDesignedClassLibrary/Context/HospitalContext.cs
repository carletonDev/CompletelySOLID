using ClassLibrary.Models;
using L_NullObjectDesignedClassLibrary;
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


    }
}
