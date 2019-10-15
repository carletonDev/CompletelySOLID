using System;
using System.Collections.Generic;

namespace ClassLibrary.EFAutoGen
{
    public partial class Hospital
    {
        public Hospital()
        {
            Bills = new HashSet<Bills>();
            Rooms = new HashSet<Rooms>();
            Salary = new HashSet<Salary>();
            UserRoleHospital = new HashSet<UserRoleHospital>();
        }

        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int? Zip { get; set; }

        public ICollection<Bills> Bills { get; set; }
        public ICollection<Rooms> Rooms { get; set; }
        public ICollection<Salary> Salary { get; set; }
        public ICollection<UserRoleHospital> UserRoleHospital { get; set; }
    }
}
