using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Pharmacy;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace CompletelySOLID.Controllers.PharmacyControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortController : ControllerBase
    {
        /// <summary>
        /// factory pattern interface dependency injection to instantiate either one of the two databses in the app
        /// </summary>
        private readonly IDbContextFactory sort;

        public SortController(IDbContextFactory context) {
            sort = context;
        }
        [HttpGet("medicineCost")]
        public IEnumerable<Medicine> SortMedicineByCost()
        {
            return sort.PharmacyContext().Medicine.OrderBy(m => m.Cost);
            
        }
        //api route that finds nearest pharmacy to hospital in session
        [HttpGet("closest/{zip}")]
        public IEnumerable<Pharmacy> FindNearestPharmacy([FromRoute]int zip)
        {
            return sort.PharmacyContext().Pharmacy.Where(m => m.Zip == zip);
        }
        //api route that gets a collection of employee salaries on payroll sorted by name
        [HttpGet("pharmacypayroll/{name}")]
        public IEnumerable<ClassLibrary.Pharmacy.Salary>PayrollByPharmacyName([FromRoute] string name)
        {
            IEnumerable<ClassLibrary.Pharmacy.Salary> debug=sort.PharmacyContext().Salary.Where(m => m.Pharmacy.PharmacyName == name);
            return debug;
        }
        //api route that gets a collectiion of employee salaries on payroll for a hospital sorted by hospital name
        [HttpGet("hospitalpayroll/{name}")]
        public IEnumerable<ClassLibrary.Models.Salary>PayrollByHospitalName([FromRoute]string name)
        {
            return sort.HospitalContext().Salary.Where(m => m.Hospital.HospitalName == name).OrderBy(m=>m.Amount);
        }
    }
}