using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Interfaces
{
    public class AbstractSalary
    {
        public static readonly NullSalary nullSalary = NullSalaryInst;

        private static NullSalary NullSalaryInst
        {
            get { return new NullSalary(); }
        }
        public virtual int SalaryId { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual Users Users { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
    public class NullSalary:AbstractSalary
    {
        public override int SalaryId { get => 0; }
        public override decimal Amount { get => 0.0M; }
        public override Users Users { get => null; }
        public override Hospital Hospital { get => null; }
    }
}
