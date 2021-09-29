using BMSWebAPI.Constants;
using BMSWebAPI.Entities;
using BMSWebAPI.Enums;
using BMSWebAPI.Models;
using System;
using System.Threading.Tasks;

namespace BMSWebAPI.Services
{
    public class UserService : IUserService
    {
        BMSContext _context;
        public UserService(BMSContext context)
        {
            _context = context;
        }

        public async Task<string> Add(User user)
        {
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return user.UserId;
        }

        public string GenerateCustomerId()
        {
            return "R-" + new Random().Next(100, 999);
        }

        public bool validateInitialDeposit(int accountType, decimal initialDeposit)
        {
            bool isValid = true;

            if ((accountType == (int)AccountType.Savings &&
                initialDeposit < Configurations.savingsInitialDepositAmountLimit) ||
                (accountType == (int)AccountType.Salary &&
                initialDeposit < Configurations.salaryInitialDepositAmountLimit))
            {
                isValid = false;
                //throw new Exception("Initial deposit amount shout be minimum " + Configurations.savingsInitialDepositAmountLimit + " for savings account.");
            }
            //else if (accountType == (int)AccountType.Salary &&
            //    initialDeposit < Configurations.salaryInitialDepositAmountLimit)
            //{
            //    isValid = false;
            //    //throw new Exception("Initial deposit amount shout be minimum " + Configurations.salaryInitialDepositAmountLimit + " for salary account.");
            //}

            return isValid;
        }

        public async Task<int> Register(RegisterModel register)
        {
            if (validateInitialDeposit(register.AccountType ?? 0, register.InitialDeposit ?? 0))
            {
                throw new Exception("Initial minimum deposit amount for Salary=" + Configurations.salaryInitialDepositAmountLimit + " Savings="+Configurations.savingsInitialDepositAmountLimit);
            }

            var newUser = Add(new User()
            {
                Username = register.Username,
                Password = register.Password,
                CreatedDate = DateTime.Now,
                UserId = GenerateCustomerId()
            });

            UserDetail newUserDetail = new UserDetail()
            {
                Address = register.Address,
                CitizenshipType = register.CitizenshipType,
                ContactNo = register.ContactNo,
                Country = register.Country,
                State = register.State,
                Dob = register.Dob,
                Email = register.Email,
                Name = register.Name,
                Gender = register.Gender,
                GuardianName = register.GuardianName,
                GuardianType = register.GuardianType,
                MaritalStatus = register.MaritalStatus,
                UserId = newUser.Result,
                CreatedDate = DateTime.Now,
                InitialDeposit = register.InitialDeposit,
                AccountType = register.AccountType
            };

            await _context.UserDetails.AddAsync(newUserDetail);

            await _context.SaveChangesAsync();

            return newUserDetail.UserDetailId;
        }
    }
}
