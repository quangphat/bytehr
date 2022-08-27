using ShiftManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftManagement.Repositories
{
    public class UserRepository: IUserRepository
    {
        private static readonly List<UserShiftLog> _userLogs = new List<UserShiftLog>
        {
            new UserShiftLog
            {
                User = new Entitties.User{ Id = 1, UserName = Guid.NewGuid().ToString("N")},
                Shift = new Entitties.Shift
                {
                    Id = 1,
                    StartShift = new DateTime(2022, 08, 27, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 27, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 27, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 27, 13, 0, 0)
                },
                SignInTime = new Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 27, 8, 15, 0),
                    UserId = 1,
                },
                LeaveTime = null
            },
            new UserShiftLog
            {
                User = new Entitties.User{ Id = 1, UserName = Guid.NewGuid().ToString("N")},
                Shift = new Entitties.Shift
                {
                    Id = 2,
                    StartShift = new DateTime(2022, 08, 26, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 26, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 26, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 26, 13, 0, 0)
                },
                SignInTime = new Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 26, 13, 15, 0),
                    UserId = 1,
                },
                LeaveTime = null
            },
            new UserShiftLog
            {
                User = new Entitties.User{ Id = 1, UserName = Guid.NewGuid().ToString("N")},
                Shift = new Entitties.Shift
                {
                    Id = 3,
                    StartShift = new DateTime(2022, 08, 25, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 25, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 25, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 25, 13, 0, 0)
                },
                SignInTime = new Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 25, 17, 15, 0),
                    UserId = 1,
                },
                LeaveTime = null
            },
            new UserShiftLog
            {
                User = new Entitties.User{ Id = 1, UserName = Guid.NewGuid().ToString("N")},
                Shift = new Entitties.Shift
                {
                    Id = 4,
                    StartShift = new DateTime(2022, 08, 24, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 24, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 24, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 24, 13, 0, 0)
                },
                SignInTime = new Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 24, 10, 15, 0),
                    UserId = 1,
                },
                LeaveTime = new Entitties.LeaveLog
                {
                    LeaveFrom = new DateTime(2022, 08, 24, 8, 0, 0),
                    LeaveTo = new DateTime(2022, 08, 24, 10, 0, 0),
                }
            },
            new UserShiftLog
            {
                User = new Entitties.User{ Id = 1, UserName = Guid.NewGuid().ToString("N")},
                Shift = new Entitties.Shift
                {
                    Id = 5,
                    StartShift = new DateTime(2022, 08, 24, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 24, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 24, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 24, 13, 0, 0)
                },
                SignInTime = new Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 24, 9, 15, 0),
                    UserId = 1,
                },
                LeaveTime = new Entitties.LeaveLog
                {
                    LeaveFrom = new DateTime(2022, 08, 24, 8, 0, 0),
                    LeaveTo = new DateTime(2022, 08, 24, 10, 10, 0),
                }
            },
            new UserShiftLog
            {
                User = new Entitties.User{ Id = 1, UserName = Guid.NewGuid().ToString("N")},
                Shift = new Entitties.Shift
                {
                    Id = 6,
                    StartShift = new DateTime(2022, 08, 24, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 24, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 24, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 24, 13, 0, 0)
                },
                SignInTime = new Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 24, 11, 15, 0),
                    UserId = 1,
                },
                LeaveTime = new Entitties.LeaveLog
                {
                    LeaveFrom = new DateTime(2022, 08, 24, 9, 0, 0),
                    LeaveTo = new DateTime(2022, 08, 24, 11, 0, 0),
                }
            },
            new UserShiftLog
            {
                User = new Entitties.User{ Id = 1, UserName = Guid.NewGuid().ToString("N")},
                Shift = new Entitties.Shift
                {
                    Id = 7,
                    StartShift = new DateTime(2022, 08, 24, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 24, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 24, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 24, 13, 0, 0)
                },
                SignInTime = new Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 24,11, 15, 0),
                    UserId = 1,
                },
                LeaveTime = new Entitties.LeaveLog
                {
                    LeaveFrom = new DateTime(2022, 08, 24, 9, 0, 0),
                    LeaveTo = new DateTime(2022, 08, 24, 11, 0, 0),
                }
            },
            new UserShiftLog
            {
                User = new Entitties.User{ Id = 1, UserName = Guid.NewGuid().ToString("N")},
                Shift = new Entitties.Shift
                {
                    Id = 8,
                    StartShift = new DateTime(2022, 08, 24, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 24, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 24, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 24, 13, 0, 0)
                },
                SignInTime = new Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 24,13, 15, 0),
                    UserId = 1,
                },
                LeaveTime = new Entitties.LeaveLog
                {
                    LeaveFrom = new DateTime(2022, 08, 24, 9, 0, 0),
                    LeaveTo = new DateTime(2022, 08, 24, 11, 0, 0),
                }
            },
        };

        //in reality, we should query by date but we need to compare datetime
        //for this example, I will query by Id for simple.
        public UserShiftLog GetUserShiftLogById(long shiftId)
        {
            return _userLogs.FirstOrDefault(p => p.Shift.Id == shiftId);
        }

        public List<UserShiftLog> GetAllLog()
        {
            return _userLogs;
        }
    }
}
