using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary.Models
{
    public class UserRoleHospital:AbstractUserRoleHospital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int urhid { get; set; }

        [ForeignKey("roleId")]
        public override Roles Role { get; set; }
        [ForeignKey("userId")]
        public override Users Users { get; set; }
        [ForeignKey("hospitalId")]
        public override Hospital Hospital { get; set; }
        public override DateTime? StartTime { get; set; }
        public override DateTime? EndTime { get; set; }
    }
}
