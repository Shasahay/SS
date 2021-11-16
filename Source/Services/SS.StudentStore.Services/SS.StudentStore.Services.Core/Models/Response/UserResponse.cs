using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Models.Response
{
    public class UserResponse
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Token { get; set; }
    }
}
