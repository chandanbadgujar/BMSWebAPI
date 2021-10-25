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
    public class AccountController : ControllerBase
    {
        IAuthService _authService;
        IUserAccountDetailService _accountService;
        public AccountController(IUserAccountDetailService accountService,
            IAuthService authService)
        {
            _accountService = accountService;
            _authService = authService;
        }

        [HttpGet]
        [Route("getDetails")]
        public IActionResult GetDetails()
        {
            UserAccountDetailModel userDetails = new UserAccountDetailModel(); ;
            try
            {
                var jwt = Request.Cookies["jwt"];

                var user = _authService.GetUser(jwt);

                userDetails = _accountService.Get(user.UserId);
            }
            catch(Exception ex)
            {
                throw new Exception("user not found");
            }

            return Ok(userDetails);
        }

        [HttpPost]
        public IActionResult UpdateAccount(UserAccountDetailModel userDetails)
        {
            _accountService.Upsert(userDetails);

            return Ok();

        }
    }
}