using BMSWebAPI.Entities;
using BMSWebAPI.Services;
using NUnit.Framework;
using System;

namespace BMS.Tests
{
    [TestFixture]
    public class UserServiceUnitTests
    {
        BMSContext _context;
        public UserServiceUnitTests(BMSContext context)
        {
            _context = context;
        }

        [Test]
        public void GetByUsernameSuccess()
        {
            UserService userService = new UserService(_context);
            var user = userService.GetByUsername("");
            Assert.AreEqual(typeof(User), user);
        }
    }
}
