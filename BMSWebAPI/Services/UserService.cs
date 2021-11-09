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
        IUserAccountDetailService _accountDetailService;
        public UserService(BMSContext context,
            IUserAccountDetailService accountDetailService)
        {
            _context = context;
            _accountDetailService = accountDetailService;
        }

        public string Add(User user)
        {
            try
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                User existingUser = null;

                do
                {
                    user.UserId = GenerateCustomerId();
                    existingUser = _context.Users.FirstOrDefault(f => f.UserId == user.UserId);
                }
                while (user.UserId == existingUser?.UserId);

                _context.Users.Add(user);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating user.");
            }


            return user.UserId;
        }

        public int Register(RegisterModel register)
        {
            if (!IsValidateInitialDeposit(register.AccountType, register.InitialDeposit))
            {
                throw new Exception("Initial minimum deposit amount for Salary=" + Configurations.salaryInitialDepositAmountLimit + " Savings="+Configurations.savingsInitialDepositAmountLimit);
            }

            var newUser = Add(new User()
            {
                Username = register.Username,
                Password = register.Password,
                CreatedDate = DateTime.Now
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

            _accountDetailService.Upsert(new UserAccountDetailModel() {
                IdentityProofType = register.IdentificationType,
                AccountId = register.ReferralAccountNo,
                AccountType = register.AccountType,
                BranchName = register.BranchName,
                IdentityProofDocNo = register.IdentificationDocNo,
                InitialDeposit = register.InitialDeposit,
                ReferanceName = register.ReferralAccountName,
                ReferenceAccountNo = register.ReferralAccountNo,
                ReferenceAddress = register.ReferralAccountAddress,
                UserId = newUser,
                CreatedDate = register.CreatedDate
            });

            return newUserDetail.UserDetailId;
        }

        public User GetByUsername(string username) 
        {
            var result = _context.Users.FirstOrDefault(f=>f.Username == username);
            
            return result;
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

    }
}
