using ShiftManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftManagement.Repositories
{
    public interface IUserRepository
    {
        List<UserShiftLog> GetAllLog();
        UserShiftLog GetUserShiftLogById(long shiftId);
    }
}
