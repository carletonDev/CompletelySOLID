using L_NullObjectDesignedClassLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public interface IHospitalContext
    {
         DbSet<Users> Users { get; set; }

         DbSet<Hospital> Hospital { get; set; }


    }
}
