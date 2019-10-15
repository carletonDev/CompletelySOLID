using System;
using System.Collections.Generic;

namespace ClassLibrary.EFAutoGen
{
    public partial class Users
    {
        public Users()
        {
            Bills = new HashSet<Bills>();
            Salary = new HashSet<Salary>();
            UserRoleHospital = new HashSet<UserRoleHospital>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int? Zip { get; set; }
        public string Phone { get; set; }
        public string Insurance { get; set; }

        public ICollection<Bills> Bills { get; set; }
        public ICollection<Salary> Salary { get; set; }
        public ICollection<UserRoleHospital> UserRoleHospital { get; set; }
    }
}
