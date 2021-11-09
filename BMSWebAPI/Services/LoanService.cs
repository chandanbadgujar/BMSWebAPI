using BMSWebAPI.Entities;
using BMSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSWebAPI.Services
{
    public class LoanService : ILoanService
    {
        BMSContext _context;
        public LoanService(BMSContext context)
        {
            _context = context;
        }

        public LoanModel Get(string userId)
        {
            var loan = _context.Loans.FirstOrDefault(x => x.UserId == userId);

            return new LoanModel() { 
                UserId= loan.UserId,
                CompanyName= loan.CompanyName,
                AnnualIncome= loan.AnnualIncome,
                Course= loan.Course,
                CourseFee= loan.CourseFee,
                Designation= loan.Designation,
                Duration= loan.Duration,
                ExpInCurrentComp= loan.ExpInCurrentComp,
                FatherExpInCurrentComp= loan.FatherExpInCurrentComp,
                FatherName= loan.FatherName,
                FatherOccupation= loan.FatherOccupation,
                LoanAmount= loan.LoanAmount,
                LoanApplyDate= loan.LoanApplyDate,
                FatherTotalExp= loan.FatherTotalExp,
                RationCardNo= loan.RationCardNo,
                TotalExp= loan.TotalExp,
                LoanIssueDate= loan.LoanIssueDate,
                LoanType= loan.LoanType,
                LoanId=loan.LoanId,
                CreatedDate= loan.CreatedDate
            };
        }

        public LoanModel Upsert(LoanModel loanModel)
        {
            var existingLoan = _context.Loans.FirstOrDefault(x => x.UserId == loanModel.UserId && x.LoanType == loanModel.LoanType);
            
            Loan loan = new Loan()
            {
                UserId = loanModel.UserId,
                CompanyName = loanModel.CompanyName,
                AnnualIncome = loanModel.AnnualIncome,
                Course = loanModel.Course,
                CourseFee = loanModel.CourseFee,
                Designation = loanModel.Designation,
                Duration = loanModel.Duration,
                ExpInCurrentComp = loanModel.ExpInCurrentComp,
                FatherExpInCurrentComp = loanModel.FatherExpInCurrentComp,
                FatherName = loanModel.FatherName,
                FatherOccupation = loanModel.FatherOccupation,
                LoanAmount = loanModel.LoanAmount,
                LoanApplyDate = loanModel.LoanApplyDate,
                FatherTotalExp = loanModel.FatherTotalExp,
                RationCardNo = loanModel.RationCardNo,
                TotalExp = loanModel.TotalExp,
                LoanIssueDate = loanModel.LoanIssueDate,
                LoanType = loanModel.LoanType
            };

            if (existingLoan != null)
            {
                loan.LoanId = loanModel.LoanId;
                loan.ModifiedDate = DateTime.Now;
                loan.ModifiedBy = loanModel.UserId;

                _context.Loans.Update(loan);
            }
            else
            {
                loan.CreatedDate = DateTime.Now;
                loan.CreatedBy = loanModel.UserId;

                _context.Loans.Add(loan);

            }

            _context.SaveChanges();

            if (loanModel.LoanId <= 0)
            {
                loanModel.LoanId = loan.LoanId;
            }

            return loanModel;
        }
    }
}
