using BMSWebAPI.Entities;
using BMSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSWebAPI.Services
{
    public class UserAccountDetailService
    {
        BMSContext _context;
        public UserAccountDetailService(BMSContext context)
        {
            _context = context;
        }

        public UserAccountDetailModel Get(int userId)
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

            if (userAccountDetailModel.UserAccountId > 0)
            {
                accountDetail.UserAccountId = userAccountDetailModel.UserAccountId;
                accountDetail.ModifiedDate = DateTime.Now;

                _context.UserAccountDetails.Update(accountDetail);
            }
            else
            {
                _context.UserAccountDetails.Add(accountDetail);

            }

            _context.SaveChanges();

            if (userAccountDetailModel.UserAccountId <= 0)
            {
                userAccountDetailModel.UserAccountId = accountDetail.UserAccountId;
            }

            return userAccountDetailModel;
        }
    }
}
