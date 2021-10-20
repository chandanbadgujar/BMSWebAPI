using BMS.Tests.Models;
using BMSWebAPI.Entities;
using BMSWebAPI.Models;
using BMSWebAPI.Services;
using NUnit.Framework;
using System;

namespace BMS.Tests
{
    [TestFixture]
    public class UserServiceUnitTests
    {
        BMSContext _context;
        RegisterModel _registerModel;
        RegisterModelMock _registerModelMock;
        UserService _userService;
        IUserAccountDetailService _userAccountService;
        public UserServiceUnitTests(BMSContext context)
        {
            _context = context;
        }

        [SetUp]
        public void Setup()
        {
            _userService = new UserService(_context, _userAccountService);
            _registerModelMock = new RegisterModelMock();
            _registerModel = _registerModelMock.getRegisterModel();
        }

        [Test]
        public void GetByUsernameSuccess()
        {
            #region Arrange
            //UserService userService = new UserService(_context);
            #endregion

            #region Act
            var user = _userService.GetByUsername("test");
            #endregion

            #region Assert
            Assert.AreEqual(typeof(User), user);
            #endregion
        }

        [Test]
        public void RegisterSuccess()
        {
            #region Arrange
            #endregion

            #region Act
            var result = _userService.Register(_registerModel);
            #endregion

            #region Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(int), result);
            #endregion
        }
    }
}
