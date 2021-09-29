using System;
using System.Collections.Generic;

#nullable disable

namespace BMSWebAPI.Models
{
    public partial class UserAccountDetailModel
    {
        public int UserAccountId { get; set; }
        public int UserId { get; set; }
        public string AccountNo { get; set; }
        public int AccountType { get; set; }
        public string BranchName { get; set; }
        public decimal InitialDeposit { get; set; }
        public int IdentityProofType { get; set; }
        public string IdentityProofDocNo { get; set; }
        public string ReferanceName { get; set; }
        public string ReferenceAccountNo { get; set; }
        public string ReferenceAddress { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
