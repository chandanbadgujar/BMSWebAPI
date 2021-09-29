using System;
using System.Collections.Generic;

#nullable disable

namespace BMSWebAPI.Entities
{
    public partial class User
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
