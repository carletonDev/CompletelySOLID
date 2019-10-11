using L_NullObjectDesignedClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary
{
    public class Bills:AbstractBills
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int BillID { get; set; }
        [ForeignKey("userId")]
        public override Users User { get; set; }
        [ForeignKey("hospitalId")]
        public override Hospital Hospital { get; set; }
        public override decimal Amount { get; set; }
    }
}
