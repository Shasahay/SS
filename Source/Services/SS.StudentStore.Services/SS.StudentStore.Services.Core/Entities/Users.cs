using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SS.StudentStore.Services.Core.Entities
{
    public class Users
    {
        [Key]
        public long? UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ClearPassword { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool? IsLocked{ get; set; }
        public int? AccessFailedCount { get; set; }
        public bool? IsActive { get; set; }
    }
}
