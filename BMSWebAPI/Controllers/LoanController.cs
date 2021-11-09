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
        IAuthService _authService;

        public LoanController(ILoanService loanService,
            IAuthService authService)
        {
            _loanService = loanService;
            _authService = authService;
        }

        [HttpGet]
        [Route("GetLoanDetail")]
        public IActionResult Get()
        {
            var jwt = Request.Cookies["jwt"];
            LoanModel loan = new LoanModel();

            if (!string.IsNullOrEmpty(jwt))
            {
                var user = _authService.GetUser(jwt);

                loan = _loanService.Get(user.UserId);
            }

            return Ok(loan);
        }

        [HttpPost]
        public IActionResult Post(LoanModel loanModel)
        {
            var jwt = Request.Cookies["jwt"];
            LoanModel loan = new LoanModel();

            if (!string.IsNullOrEmpty(jwt))
            {
                var user = _authService.GetUser(jwt);

                loanModel.UserId = user.UserId;
                loanModel.CreatedBy = user.UserId;

                loan = _loanService.Upsert(loanModel);
            }

            return Ok(loan);
        }
    }
}