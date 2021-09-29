using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMSWebAPI.Models;
using BMSWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BMSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        [Route("GetLoanDetail")]
        public IActionResult Get(int userId)
        {
            var loan = _loanService.Get(userId);

            return Ok(loan);
        }

        [HttpPost]
        public IActionResult Post(LoanModel loanModel)
        {
            var loan = _loanService.Upsert(loanModel);

            return Ok(loan);
        }
    }
}