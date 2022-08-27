using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftManagement.Entitties
{
    public class SignInLog : BaseEntity
    {
        public DateTime SignInTime { get; set; }
        public long UserId { get; set; }
    }
}
