using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSWebAPI.Models
{
    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string GuardianName { get; set; }
        public int GuardianType { get; set; }
        public string Address { get; set; }
        public int CitizenshipType { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public int MaritalStatus { get; set; }
        public string ContactNo { get; set; }
        public DateTime Dob { get; set; }
        public int AccountType { get; set; }
        public string BranchName { get; set; }
        public decimal InitialDeposit { get; set; }
        public int IdentificationType { get; set; }
        public string IdentificationDocNo { get; set; }
        public string ReferralAccountName { get; set; }
        public string ReferralAccountNo { get; set; }
        public string ReferralAccountAddress { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
