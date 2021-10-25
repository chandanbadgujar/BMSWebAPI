using System;
using System.Collections.Generic;

#nullable disable

namespace BMSWebAPI.Entities
{
    public partial class UserAccountDetail
    {
        public string AccountId { get; set; }
        public string UserId { get; set; }
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
