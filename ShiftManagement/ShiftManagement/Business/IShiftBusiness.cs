using ShiftManagement.Entitties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftManagement.Business
{
    public interface IShiftBusiness
    {
        TimeSpan CalculateLateTime(Shift shift, LeaveLog leave, SignInLog signInTime);
    }
}
