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
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Register(RegisterModel register)
        {
            var result = _userService.Register(register);

            return Ok(result);
        }
    }
}