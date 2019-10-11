using L_NullObjectDesignedClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary
{
    public abstract class AbstractBills
    {
        public static readonly NullBills nullBills = NullBillInst;
        private static NullBills NullBillInst
        {
            get { return new NullBills();}
        }
        public virtual int BillID { get; set; }
        public virtual Users User { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual decimal Amount { get; set; }

    }
    public class NullBills:AbstractBills
    {
        public override int BillID { get => 0; }
        public override Users User { get => null;}
        public override Hospital Hospital { get => null; }
        public override decimal Amount { get => 0.0M; }
    }
}
