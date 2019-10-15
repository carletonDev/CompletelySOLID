using System;
using System.Collections.Generic;

namespace ClassLibrary.Pharmacy
{
    public partial class Users
    {
        public Users()
        {
            Salary = new HashSet<Salary>();
            TransactionsCustomer = new HashSet<Transactions>();
            TransactionsEmployee = new HashSet<Transactions>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Zip { get; set; }

        public ICollection<Salary> Salary { get; set; }
        public ICollection<Transactions> TransactionsCustomer { get; set; }
        public ICollection<Transactions> TransactionsEmployee { get; set; }
    }
}
