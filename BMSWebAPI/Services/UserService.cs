using BMSWebAPI.Constants;
using BMSWebAPI.Entities;
using BMSWebAPI.Enums;
using BMSWebAPI.Models;
using System;
using System.Linq;
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

        public string Add(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        
            _context.Users.Add(user);

            _context.SaveChanges();

            return user.UserId;
        }

        private string GenerateCustomerId()
        {
            return "R-" + new Random().Next(100, 999);
        }

        private bool IsValidateInitialDeposit(int accountType, decimal initialDeposit)
        {
            bool isValid = true;

            if ((accountType == (int)AccountType.Savings &&
                initialDeposit < Configurations.savingsInitialDepositAmountLimit) ||
                (accountType == (int)AccountType.Salary &&
                initialDeposit < Configurations.salaryInitialDepositAmountLimit))
            {
                isValid = false;
            }

            return isValid;
        }

        public int Register(RegisterModel register)
        {
            if (!IsValidateInitialDeposit(register.AccountType ?? 0, register.InitialDeposit ?? 0))
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
                UserId = newUser,
                CreatedDate = DateTime.Now,
                InitialDeposit = register.InitialDeposit,
                AccountType = register.AccountType
            };

            _context.UserDetails.Add(newUserDetail);

            _context.SaveChanges();

            return newUserDetail.UserDetailId;
        }

        public User GetByUsername(string username) 
        {
            var result = _context.Users.FirstOrDefault(f=>f.Username == username);
            
            return result;
        }
    }
}
