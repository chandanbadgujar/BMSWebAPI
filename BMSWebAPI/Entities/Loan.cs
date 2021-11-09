using System;
using System.Collections.Generic;

#nullable disable

namespace BMSWebAPI.Entities
{
    public partial class Loan
    {
        public int LoanId { get; set; }
        public string UserId { get; set; }
        public int LoanType { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime LoanApplyDate { get; set; }
        public DateTime? LoanIssueDate { get; set; }
        public int Duration { get; set; }
        public string Course { get; set; }
        public decimal? CourseFee { get; set; }
        public string FatherName { get; set; }
        public string FatherOccupation { get; set; }
        public int? FatherTotalExp { get; set; }
        public int? FatherExpInCurrentComp { get; set; }
        public string RationCardNo { get; set; }
        public decimal? AnnualIncome { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public int? TotalExp { get; set; }
        public int? ExpInCurrentComp { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
