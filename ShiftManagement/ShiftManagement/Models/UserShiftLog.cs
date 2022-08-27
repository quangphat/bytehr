using ShiftManagement.Entitties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftManagement.Models
{
    public class UserShiftLog
    {
        public User User { get; set; }
        public Shift Shift { get; set; }
        public LeaveLog LeaveTime { get; set; }
        public SignInLog SignInTime { get; set; }
    }
}
