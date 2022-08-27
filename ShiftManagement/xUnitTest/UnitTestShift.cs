using ShiftManagement.Business;
using ShiftManagement.Models;
using System;
using Xunit;

namespace xUnitTest
{
    public class UnitTestShift
    {
        private readonly IShiftBusiness _shiftBusiness;
        public UnitTestShift()
        {
            _shiftBusiness = new ShiftBusiness();
        }

        [Fact]
        public void Test_SignInTimeBetweenStartAndEndShift()
        {
            var log = new UserShiftLog
            {
                User = new ShiftManagement.Entitties.User { Id = 1, UserName = Guid.NewGuid().ToString("N") },
                Shift = new ShiftManagement.Entitties.Shift
                {
                    Id = 1,
                    StartShift = new DateTime(2022, 08, 27, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 27, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 27, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 27, 13, 0, 0)
                },
                SignInTime = new ShiftManagement.Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 27, 8, 0, 0),
                    UserId = 1,
                },
                LeaveTime = null
            };

            var lateSpan = _shiftBusiness.CalculateLateTime(log.Shift, log.LeaveTime, log.SignInTime);

            Assert.Equal(TimeSpan.Zero, lateSpan);
        }

        [Fact]
        public void Test_SignInTimeLessThanStartShift()
        {
            var log = new UserShiftLog
            {
                User = new ShiftManagement.Entitties.User { Id = 1, UserName = Guid.NewGuid().ToString("N") },
                Shift = new ShiftManagement.Entitties.Shift
                {
                    Id = 1,
                    StartShift = new DateTime(2022, 08, 27, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 27, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 27, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 27, 13, 0, 0)
                },
                SignInTime = new ShiftManagement.Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 27, 7, 0, 0),
                    UserId = 1,
                },
                LeaveTime = null
            };

            var lateSpan = _shiftBusiness.CalculateLateTime(log.Shift, log.LeaveTime, log.SignInTime);

            Assert.Equal(TimeSpan.Zero, lateSpan);
        }

        [Fact]
        public void Test_SignInTimeGreaterThanStartShift()
        {
            var log = new UserShiftLog
            {
                User = new ShiftManagement.Entitties.User { Id = 1, UserName = Guid.NewGuid().ToString("N") },
                Shift = new ShiftManagement.Entitties.Shift
                {
                    Id = 1,
                    StartShift = new DateTime(2022, 08, 27, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 27, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 27, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 27, 13, 0, 0)
                },
                SignInTime = new ShiftManagement.Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 27, 20, 0, 0),
                    UserId = 1,
                },
                LeaveTime = null
            };

            var lateSpan = _shiftBusiness.CalculateLateTime(log.Shift, log.LeaveTime, log.SignInTime);

            Assert.Equal(new TimeSpan(11, 0, 0), lateSpan);
        }

        [Fact]
        public void Test_LeaveStartLessThanStartShift()
        {
            var log = new UserShiftLog
            {
                User = new ShiftManagement.Entitties.User { Id = 1, UserName = Guid.NewGuid().ToString("N") },
                Shift = new ShiftManagement.Entitties.Shift
                {
                    Id = 1,
                    StartShift = new DateTime(2022, 08, 27, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 27, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 27, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 27, 13, 0, 0)
                },
                SignInTime = new ShiftManagement.Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 27, 9, 0, 0),
                    UserId = 1,
                },
                LeaveTime = new ShiftManagement.Entitties.LeaveLog
                {
                    LeaveFrom = new DateTime(2022, 08, 27, 7, 0, 0),
                    LeaveTo = new DateTime(2022, 08, 27, 9, 0, 0),
                }
            };

            var lateSpan = _shiftBusiness.CalculateLateTime(log.Shift, log.LeaveTime, log.SignInTime);

            Assert.Equal(TimeSpan.Zero, lateSpan);
        }
        [Fact]
        public void Test_LeaveStartLessThanStartShiftAndSignInLessThanEndLeave()
        {
            var log = new UserShiftLog
            {
                User = new ShiftManagement.Entitties.User { Id = 1, UserName = Guid.NewGuid().ToString("N") },
                Shift = new ShiftManagement.Entitties.Shift
                {
                    Id = 1,
                    StartShift = new DateTime(2022, 08, 27, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 27, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 27, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 27, 13, 0, 0)
                },
                SignInTime = new ShiftManagement.Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 27, 9, 0, 0),
                    UserId = 1,
                },
                LeaveTime = new ShiftManagement.Entitties.LeaveLog
                {
                    LeaveFrom = new DateTime(2022, 08, 27, 7, 0, 0),
                    LeaveTo = new DateTime(2022, 08, 27, 10, 0, 0),
                }
            };

            var lateSpan = _shiftBusiness.CalculateLateTime(log.Shift, log.LeaveTime, log.SignInTime);

            Assert.Equal(TimeSpan.Zero, lateSpan);
        }

        [Fact]
        public void Test_SignInOutsideLeaveTime()
        {
            var log = new UserShiftLog
            {
                User = new ShiftManagement.Entitties.User { Id = 1, UserName = Guid.NewGuid().ToString("N") },
                Shift = new ShiftManagement.Entitties.Shift
                {
                    Id = 1,
                    StartShift = new DateTime(2022, 08, 27, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 27, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 27, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 27, 13, 0, 0)
                },
                SignInTime = new ShiftManagement.Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 27, 10, 15, 0),
                    UserId = 1,
                },
                LeaveTime = new ShiftManagement.Entitties.LeaveLog
                {
                    LeaveFrom = new DateTime(2022, 08, 27, 9, 0, 0),
                    LeaveTo = new DateTime(2022, 08, 27, 10, 0, 0),
                }
            };

            var lateSpan = _shiftBusiness.CalculateLateTime(log.Shift, log.LeaveTime, log.SignInTime);

            Assert.Equal(new TimeSpan(1, 15, 0), lateSpan);
        }

        [Fact]
        public void Test_LeaveIsSameAsBreak()
        {
            var log = new UserShiftLog
            {
                User = new ShiftManagement.Entitties.User { Id = 1, UserName = Guid.NewGuid().ToString("N") },
                Shift = new ShiftManagement.Entitties.Shift
                {
                    Id = 1,
                    StartShift = new DateTime(2022, 08, 27, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 27, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 27, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 27, 13, 0, 0)
                },
                SignInTime = new ShiftManagement.Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 27, 13, 15, 0),
                    UserId = 1,
                },
                LeaveTime = new ShiftManagement.Entitties.LeaveLog
                {
                    LeaveFrom = new DateTime(2022, 08, 27, 12, 0, 0),
                    LeaveTo = new DateTime(2022, 08, 27, 13, 0, 0),
                }
            };

            var lateSpan = _shiftBusiness.CalculateLateTime(log.Shift, log.LeaveTime, log.SignInTime);

            Assert.Equal(new TimeSpan(4, 15, 0), lateSpan);
        }

        [Fact]
        public void Test_SignInIsInBreakTime()
        {
            var log = new UserShiftLog
            {
                User = new ShiftManagement.Entitties.User { Id = 1, UserName = Guid.NewGuid().ToString("N") },
                Shift = new ShiftManagement.Entitties.Shift
                {
                    Id = 1,
                    StartShift = new DateTime(2022, 08, 27, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 27, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 27, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 27, 13, 0, 0)
                },
                SignInTime = new ShiftManagement.Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 27, 12, 15, 0),
                    UserId = 1,
                },
                LeaveTime = new ShiftManagement.Entitties.LeaveLog
                {
                    LeaveFrom = new DateTime(2022, 08, 27, 12, 0, 0),
                    LeaveTo = new DateTime(2022, 08, 27, 13, 0, 0),
                }
            };

            var lateSpan = _shiftBusiness.CalculateLateTime(log.Shift, log.LeaveTime, log.SignInTime);

            Assert.Equal(new TimeSpan(4, 0, 0), lateSpan);
        }

        [Fact]
        public void Test_LeaveTimeGreaterThanBreakTime()
        {
            var log = new UserShiftLog
            {
                User = new ShiftManagement.Entitties.User { Id = 1, UserName = Guid.NewGuid().ToString("N") },
                Shift = new ShiftManagement.Entitties.Shift
                {
                    Id = 1,
                    StartShift = new DateTime(2022, 08, 27, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 27, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 27, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 27, 13, 0, 0)
                },
                SignInTime = new ShiftManagement.Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 27, 9, 15, 0),
                    UserId = 1,
                },
                LeaveTime = new ShiftManagement.Entitties.LeaveLog
                {
                    LeaveFrom = new DateTime(2022, 08, 27, 13, 0, 0),
                    LeaveTo = new DateTime(2022, 08, 27, 15, 0, 0),
                }
            };

            var lateSpan = _shiftBusiness.CalculateLateTime(log.Shift, log.LeaveTime, log.SignInTime);

            Assert.Equal(new TimeSpan(1, 15, 0), lateSpan);
        }

        [Fact]
        public void Test_LeaveIsalternateBreakTimeAndLeaveFromLessThanStartBreak()
        {
            var log = new UserShiftLog
            {
                User = new ShiftManagement.Entitties.User { Id = 1, UserName = Guid.NewGuid().ToString("N") },
                Shift = new ShiftManagement.Entitties.Shift
                {
                    Id = 1,
                    StartShift = new DateTime(2022, 08, 27, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 27, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 27, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 27, 13, 0, 0)
                },
                SignInTime = new ShiftManagement.Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 27, 13, 15, 0),
                    UserId = 1,
                },
                LeaveTime = new ShiftManagement.Entitties.LeaveLog
                {
                    LeaveFrom = new DateTime(2022, 08, 27, 11, 0, 0),
                    LeaveTo = new DateTime(2022, 08, 27, 12, 30, 0),
                }
            };

            var lateSpan = _shiftBusiness.CalculateLateTime(log.Shift, log.LeaveTime, log.SignInTime);

            Assert.Equal(new TimeSpan(3, 15, 0), lateSpan);
        }

        [Fact]
        public void Test_LeaveIsalternateBreakTimeAndLeaveToGreateThanEndBreak()
        {
            var log = new UserShiftLog
            {
                User = new ShiftManagement.Entitties.User { Id = 1, UserName = Guid.NewGuid().ToString("N") },
                Shift = new ShiftManagement.Entitties.Shift
                {
                    Id = 1,
                    StartShift = new DateTime(2022, 08, 27, 8, 0, 0),
                    EndShift = new DateTime(2022, 08, 27, 17, 0, 0),
                    StartBreak = new DateTime(2022, 08, 27, 12, 0, 0),
                    EndBreak = new DateTime(2022, 08, 27, 13, 0, 0)
                },
                SignInTime = new ShiftManagement.Entitties.SignInLog
                {
                    SignInTime = new DateTime(2022, 08, 27, 13, 15, 0),
                    UserId = 1,
                },
                LeaveTime = new ShiftManagement.Entitties.LeaveLog
                {
                    LeaveFrom = new DateTime(2022, 08, 27, 12, 30, 0),
                    LeaveTo = new DateTime(2022, 08, 27, 13, 30, 0),
                }
            };

            var lateSpan = _shiftBusiness.CalculateLateTime(log.Shift, log.LeaveTime, log.SignInTime);

            Assert.Equal(new TimeSpan(4, 0, 0), lateSpan);
        }
    }
}
