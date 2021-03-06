using BMSWebAPI.Helpers;
using BMSWebAPI.Models;
using BMSWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BMSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        JwtService _jwtService;
        IUserService _userService;
        IAuthService _authService;
        public AuthController(JwtService jwtService,
            IUserService userService,
            IAuthService authService)
        {
            _jwtService = jwtService;
            _userService = userService;
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _userService.GetByUsername(dto.Username);
            
            if (user == null)
            {
                throw new Exception("user not found."); ;
            }

            string jwt = _jwtService.Generate(dto.Username);

            Response.Cookies.Append("jwt", jwt, new CookieOptions { 
                HttpOnly=true
            });

            return Ok(user);
        }

        [HttpGet]
        [Route("user")]
        public IActionResult User()
        {
            var jwt = Request.Cookies["jwt"];

            var user = _authService.GetUser(jwt);

            return Ok(user);
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new {
                message = "success"    
            });
        }
    }
}