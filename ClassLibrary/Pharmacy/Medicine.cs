using System;
using System.Collections.Generic;

namespace ClassLibrary.Pharmacy
{
    public partial class Medicine
    {
        public Medicine()
        {
            PharmacyMedicine = new HashSet<PharmacyMedicine>();
        }

        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string MedicineType { get; set; }
        public decimal Cost { get; set; }

        public ICollection<PharmacyMedicine> PharmacyMedicine { get; set; }
    }
}
