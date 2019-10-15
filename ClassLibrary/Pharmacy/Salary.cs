using System;
using System.Collections.Generic;

namespace ClassLibrary.Pharmacy
{
    public partial class Salary
    {
        public int SalaryId { get; set; }
        public int? EmployeeId { get; set; }
        public int? PharmacyId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Users Employee { get; set; }
        public Pharmacy Pharmacy { get; set; }
    }
}
