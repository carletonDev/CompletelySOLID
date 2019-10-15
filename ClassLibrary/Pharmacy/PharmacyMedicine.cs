using System;
using System.Collections.Generic;

namespace ClassLibrary.Pharmacy
{
    public partial class PharmacyMedicine
    {
        public int Pmid { get; set; }
        public int? MedicineId { get; set; }
        public int? PharmacyId { get; set; }
        public int InStock { get; set; }

        public Medicine Medicine { get; set; }
        public Pharmacy Pharmacy { get; set; }
    }
}
