using BMSWebAPI.Entities;
using BMSWebAPI.Helpers;
namespace BMSWebAPI.Services
{
    public class AuthService : IAuthService
    {
        JwtService _jwtService;
        IUserService _userService;

        public AuthService(JwtService jwtService,
            IUserService userService)
        {
            _jwtService = jwtService;
            _userService = userService;
        }

        public User GetUser(string jwt)
        {
            var token = _jwtService.Verify(jwt);

            string username = token?.Issuer;

            var user = _userService.GetByUsername(username);

            return user;
        }
    }
}
