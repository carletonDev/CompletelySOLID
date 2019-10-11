using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary.Models
{
    public class Salary:AbstractSalary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int SalaryId { get; set; }
        public override decimal Amount { get; set; }
        [ForeignKey("userId")]
        public override Users Users { get; set; }
        [ForeignKey("hospitalId")]
        public override Hospital Hospital { get; set; }
    }
}
