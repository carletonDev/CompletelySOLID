using System;
using System.Collections.Generic;

namespace ClassLibrary.EFAutoGen
{
    public partial class Roles
    {
        public Roles()
        {
            UserRoleHospital = new HashSet<UserRoleHospital>();
        }

        public int RoleId { get; set; }
        public string RoleType { get; set; }

        public ICollection<UserRoleHospital> UserRoleHospital { get; set; }
    }
}
