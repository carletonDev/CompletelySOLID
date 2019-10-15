using System;
using System.Collections.Generic;

namespace ClassLibrary.Pharmacy
{
    public partial class Transactions
    {
        public int TransactionId { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime DateTransaction { get; set; }
        public decimal Amount { get; set; }

        public Users Customer { get; set; }
        public Users Employee { get; set; }
    }
}
