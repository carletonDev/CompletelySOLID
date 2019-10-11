using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary.Models
{
    public abstract class AbstractHospital
    {

        public static readonly NullHospital hospital = NullHospitalInst;

        private static NullHospital NullHospitalInst
        {
            get { return new NullHospital(); }
        }
        public abstract int HospitalID { get; set; }

        public abstract string HospitalName { get; set; }

        public abstract string Street { get; set; }

        public abstract string City { get; set; }
        public abstract int? Zip { get; set; }
    }
    public class NullHospital : AbstractHospital
    {
        public override int HospitalID { get => 0; set => throw new NotImplementedException(); }
        public override string HospitalName { get => "No Hospital Name Entered"; set => throw new NotImplementedException(); }
        public override string Street { get => "N/A"; set => throw new NotImplementedException(); }
        public override string City { get => "No City Information"; set => throw new NotImplementedException(); }
        public override int? Zip { get => 11111; set => throw new NotImplementedException(); }
    }
    public class Hospital : AbstractHospital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int HospitalID { get; set; }
        public override string HospitalName { get; set; }
        public override string Street { get; set; }
        public override string City { get; set; }
        public override int? Zip { get; set; }
    }

}
