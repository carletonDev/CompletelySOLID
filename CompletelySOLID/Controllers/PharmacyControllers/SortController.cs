using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Pharmacy;
using ClassLibrary.Interfaces;

namespace CompletelySOLID.Controllers.PharmacyControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortController:ControllerBase
    {
        private readonly IDbContextFactory _context;

        public SortController(IDbContextFactory sort){
            sort=_context;
        }
        [HttpGet]
        public IEnumerable SortMedicine()
        {
            
        }
    }
}