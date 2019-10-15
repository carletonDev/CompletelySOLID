using System;
using System.Collections.Generic;

namespace ClassLibrary.Pharmacy
{
    public partial class Pharmacy
    {
        public Pharmacy()
        {
            PharmacyMedicine = new HashSet<PharmacyMedicine>();
            Salary = new HashSet<Salary>();
        }

        public int PharmacyId { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Zip { get; set; }

        public ICollection<PharmacyMedicine> PharmacyMedicine { get; set; }
        public ICollection<Salary> Salary { get; set; }
    }
}
