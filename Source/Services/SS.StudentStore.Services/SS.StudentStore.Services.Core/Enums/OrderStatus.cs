using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SS.StudentStore.Services.Core.Enums
{
    public enum OrderStatus
    {
        [EnumMember(Value ="Pending")]
        Pending,
        [EnumMember(Value = "PaymentReceived")]
        PaymentReceived,
        [EnumMember(Value = "PaymentFailed")]
        PaymentFailed
    }
}
