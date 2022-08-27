using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftManagement.Entitties
{
    public class LeaveLog :BaseEntity
    {
        public long UserId { get; set; }
        public DateTime LeaveFrom { get; set; }
        public DateTime LeaveTo { get; set; }
    }
}
