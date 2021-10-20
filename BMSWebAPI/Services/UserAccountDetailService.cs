using BMSWebAPI.Entities;
using BMSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSWebAPI.Services
{
    public class UserAccountDetailService: IUserAccountDetailService
    {
        BMSContext _context;
        public UserAccountDetailService(BMSContext context)
        {
            _context = context;
        }

        public UserAccountDetailModel Get(string userId)
        {
            var result = _context.UserAccountDetails.FirstOrDefault(x => x.UserId == userId);

            if (result == null)
            {
                return new UserAccountDetailModel();
            }

            return new UserAccountDetailModel() { 
                UserId=result.UserId,
                AccountNo=result.AccountNo,
                AccountType=result.AccountType,
                BranchName=result.BranchName,
                InitialDeposit=result.InitialDeposit,
                IdentityProofDocNo=result.IdentityProofDocNo,
                ReferanceName=result.ReferanceName,
                ReferenceAccountNo=result.ReferenceAccountNo,
                ReferenceAddress=result.ReferenceAddress,
                UserAccountId=result.UserAccountId,
                IdentityProofType=result.IdentityProofType
            };
        }

        public UserAccountDetailModel Upsert(UserAccountDetailModel userAccountDetailModel)
        {
           
            UserAccountDetail accountDetail = new UserAccountDetail() {
                IdentityProofType = userAccountDetailModel.IdentityProofType,
                AccountNo= userAccountDetailModel.AccountNo,
                AccountType= userAccountDetailModel.AccountType,
                BranchName= userAccountDetailModel.BranchName,
                IdentityProofDocNo= userAccountDetailModel.IdentityProofDocNo,
                InitialDeposit= userAccountDetailModel.InitialDeposit,
                ReferanceName= userAccountDetailModel.ReferanceName,
                ReferenceAccountNo= userAccountDetailModel.ReferenceAccountNo,
                ReferenceAddress= userAccountDetailModel.ReferenceAddress,
                UserId= userAccountDetailModel.UserId,
                CreatedDate= userAccountDetailModel.CreatedDate
            };

            if (!string.IsNullOrEmpty(userAccountDetailModel.UserAccountId))
            {
                accountDetail.UserAccountId = userAccountDetailModel.UserAccountId;
                accountDetail.ModifiedDate = DateTime.Now;

                _context.UserAccountDetails.Update(accountDetail);
            }
            else
            {
                accountDetail.UserAccountId = GenerateAccountId();
                _context.UserAccountDetails.Add(accountDetail);

            }

            _context.SaveChanges();

            if (string.IsNullOrEmpty(userAccountDetailModel.UserAccountId))
            {
                userAccountDetailModel.UserAccountId = accountDetail.UserAccountId;
            }

            return userAccountDetailModel;
        }

        private string GenerateAccountId()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 16);
        }
    }
}
