using I_Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L_NullObjectDesignedClassLibrary
{
    /// <summary>
    /// null object pattern of Users Database
    /// </summary>
    public class Users : AbstractUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int UserId { get; set; }
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override string Street { get; set; }
        public override string City { get; set; }
        public override int? Zip { get; set; }
        public override string Phone { get; set; }
        public override string Insurance { get; set; }


    }
}
