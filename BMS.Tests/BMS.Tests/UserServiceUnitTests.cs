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
            #region Arrange
            UserService userService = new UserService(_context);
            #endregion

            #region Act
            var user = userService.GetByUsername("test");
            #endregion

            #region Assert
            Assert.AreEqual(typeof(User), user);
            #endregion
        }
    }
}
