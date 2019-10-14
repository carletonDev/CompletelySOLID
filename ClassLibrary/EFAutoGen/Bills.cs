using System;
using System.Collections.Generic;

namespace ClassLibrary.EFAutoGen
{
    public partial class Bills
    {
        public int BillId { get; set; }
        public int? UserId { get; set; }
        public int? HospitalId { get; set; }
        public decimal? Amount { get; set; }

        public Hospital Hospital { get; set; }
        public Users User { get; set; }
    }
}
