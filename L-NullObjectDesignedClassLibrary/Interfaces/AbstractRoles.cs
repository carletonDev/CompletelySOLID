using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Interfaces
{
    public abstract class AbstractRoles
    {
        public static readonly NullRoles nullRoles = NullRolesInst;

        private static NullRoles NullRolesInst
        {
            get { return new NullRoles(); }
        }

        public virtual int RoleId { get; set; }
        public virtual string RoleType { get; set; }
    }
    public class NullRoles:AbstractRoles
    {
        public override int RoleId { get => 0;}
        public override string RoleType { get => "No Role Found";}
    }
    
}
