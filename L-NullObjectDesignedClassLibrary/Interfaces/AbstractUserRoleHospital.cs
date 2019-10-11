using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Interfaces
{
    public abstract class AbstractUserRoleHospital
    {
        public static readonly NullUserRoleHospital userRoleHospital = NullUserRoleHospitalInst;

        private static NullUserRoleHospital NullUserRoleHospitalInst
        {
            get { return new NullUserRoleHospital(); }
        }
        public virtual Roles Role { get; set; }
        public virtual Users Users { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
    }
    public class NullUserRoleHospital:AbstractUserRoleHospital
    {
        public override Roles Role { get => null; }
        public override Users Users { get => null; }
        public override Hospital Hospital { get => null; }
        public override DateTime StartTime { get => DateTime.Now; }
        public override DateTime EndTime { get => DateTime.Now; }
    }
}
