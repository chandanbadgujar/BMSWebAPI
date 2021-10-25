using BMSWebAPI.Entities;
using BMSWebAPI.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSWebAPI.Services
{
    public class UserAccountDetailService : IUserAccountDetailService
    {
        BMSContext _context;
        public UserAccountDetailService(BMSContext context)
        {
            _context = context;
        }

        public UserAccountDetailModel Get(string userId)
        {
            var accountDetail = _context.UserAccountDetails.FirstOrDefault(x => x.UserId == userId);

            if (accountDetail == null)
            {
                return new UserAccountDetailModel();
            }

            var userDetails = _context.UserDetails.FirstOrDefault(x => x.UserId == userId);

            return new UserAccountDetailModel()
            {
                UserId = accountDetail.UserId,
                AccountId = accountDetail.AccountId,
                AccountType = accountDetail.AccountType,
                BranchName = accountDetail.BranchName,
                InitialDeposit = accountDetail.InitialDeposit,
                IdentityProofDocNo = accountDetail.IdentityProofDocNo,
                ReferanceName = accountDetail.ReferanceName,
                ReferenceAccountNo = accountDetail.ReferenceAccountNo,
                ReferenceAddress = accountDetail.ReferenceAddress,
                IdentityProofType = accountDetail.IdentityProofType,
                Name = userDetails.Name,
                GuardianName = userDetails.GuardianName,
                GuardianType = userDetails.GuardianType,
                Address = userDetails.Address,
                CitizenshipType = userDetails.CitizenshipType,
                ContactNo = userDetails.ContactNo,
                Country = userDetails.Country,
                State = userDetails.State,
                Dob = userDetails.Dob,
                Email = userDetails.Email,
                Gender = userDetails.Gender,
                MaritalStatus = userDetails.MaritalStatus,
                CreatedDate = userDetails.CreatedDate,
                BankName = userDetails.BankName
            };
        }

        public UserAccountDetailModel Upsert(UserAccountDetailModel userAccountDetailModel)
        {

            UserAccountDetail accountDetail = new UserAccountDetail()
            {
                IdentityProofType = userAccountDetailModel.IdentityProofType,
                AccountId = userAccountDetailModel.AccountId,
                AccountType = userAccountDetailModel.AccountType,
                BranchName = userAccountDetailModel.BranchName,
                IdentityProofDocNo = userAccountDetailModel.IdentityProofDocNo,
                InitialDeposit = userAccountDetailModel.InitialDeposit,
                ReferanceName = userAccountDetailModel.ReferanceName,
                ReferenceAccountNo = userAccountDetailModel.ReferenceAccountNo,
                ReferenceAddress = userAccountDetailModel.ReferenceAddress,
                UserId = userAccountDetailModel.UserId,
                CreatedDate = userAccountDetailModel.CreatedDate
            };

            if (!string.IsNullOrEmpty(userAccountDetailModel.AccountId))
            {
                accountDetail.AccountId = userAccountDetailModel.AccountId;
                accountDetail.ModifiedDate = DateTime.Now;

                _context.UserAccountDetails.Update(accountDetail);
            }
            else
            {
                accountDetail.AccountId = GenerateAccountId();
                _context.UserAccountDetails.Add(accountDetail);

            }

            _context.SaveChanges();

            if (string.IsNullOrEmpty(userAccountDetailModel.AccountId))
            {
                userAccountDetailModel.AccountId = accountDetail.AccountId;
            }

            return userAccountDetailModel;
        }

        private string GenerateAccountId()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 16);
        }
    }
}
