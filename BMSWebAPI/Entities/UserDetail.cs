using System;
using System.Collections.Generic;

#nullable disable

namespace BMSWebAPI.Entities
{
    public partial class UserDetail
    {
        public int UserDetailId { get; set; }
        public string UserId { get; set; }
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
        public string BankName { get; set; }
        public decimal? InitialDeposit { get; set; }
        public int? AccountType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
