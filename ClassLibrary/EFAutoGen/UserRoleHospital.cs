using System;
using System.Collections.Generic;

namespace ClassLibrary.EFAutoGen
{
    public partial class UserRoleHospital
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public int HospitalId { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public int Urhid { get; set; }

        public Hospital Hospital { get; set; }
        public Roles Role { get; set; }
        public Users User { get; set; }
    }
}
