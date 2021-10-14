using BMSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMS.Tests.Models
{
    public class RegisterModelMock
    {
        public RegisterModel getRegisterModel()
        {
            return new RegisterModel() {
                AccountType = 1,
                Address = "dummy",
                CitizenshipType = 1,
                ContactNo = "9888555885",
                Country = 1,
                State = 1,
                Dob = DateTime.Now.AddDays(-1000),
                Email = "ch@ch.com",
                Gender = 1,
                GuardianName = "gn dummy",
                InitialDeposit = 34343,
                Name="some name",
                Username ="uname",
                Password="password",
                GuardianType=2,
                MaritalStatus=1
            };
        }
    }
}
