using ShiftManagement.Entitties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftManagement.Business
{
    public class ShiftBusiness : IShiftBusiness
    {
        //for sample, we assume all input time are same day.
        public TimeSpan CalculateLateTime(Shift shift, LeaveLog leave, SignInLog signInTime)
        {
            if (shift == null || DateTime.Compare(shift.EndShift, shift.StartShift) <= 0)
            {
                throw new ArgumentNullException("Shift không hợp lệ");
            }

            if (signInTime == null || signInTime.SignInTime == null)
            {
                throw new ArgumentNullException("signInTime không hợp lệ");
            }

            if (leave != null)
            {
                if (DateTime.Compare(leave.LeaveTo, leave.LeaveFrom) <= 0)
                {
                    throw new ArgumentNullException("Leave không hợp lệ");
                }
                if (DateTime.Compare(leave.LeaveTo, shift.EndShift) >= 0)
                {
                    throw new ArgumentNullException("LeaveTo phải < EndShift");
                }
                if (DateTime.Compare(leave.LeaveFrom, shift.StartShift) < 0)
                {
                    leave.LeaveFrom = shift.StartShift;
                }

                if (DateTime.Compare(leave.LeaveTo, shift.EndShift) > 0)
                {
                    leave.LeaveTo = shift.EndShift;
                }

                if (DateTime.Compare(leave.LeaveFrom, shift.StartBreak) >= 0 && DateTime.Compare(leave.LeaveFrom, shift.EndBreak) <= 0)
                {
                    leave.LeaveFrom = shift.EndBreak;
                }

                if (DateTime.Compare(leave.LeaveTo, shift.StartBreak) >= 0 && DateTime.Compare(leave.LeaveTo, shift.EndBreak) <= 0 )
                {
                    leave.LeaveTo = shift.StartBreak;
                }

                if (DateTime.Compare(signInTime.SignInTime, leave.LeaveFrom) > 0 && DateTime.Compare(signInTime.SignInTime, leave.LeaveTo)<0)
                {
                    signInTime.SignInTime = leave.LeaveFrom;
                }

                if ((DateTime.Compare(leave.LeaveFrom, shift.StartBreak) > 0 && DateTime.Compare(leave.LeaveTo, shift.EndBreak) <= 0)
                    || DateTime.Compare(leave.LeaveFrom, signInTime.SignInTime) >= 0)
                {
                    leave = null;
                }
            }

            return _CalculateLateTime(shift, leave, signInTime.SignInTime);

        }

        private TimeSpan _CalculateLateTime(Shift shift, LeaveLog leave, DateTime signInTime)
        {
            if (DateTime.Compare(signInTime, shift.StartShift) <= 0)
            {
                return TimeSpan.Zero;
            }

            var leaveSpan = TimeSpan.Zero;
            if (leave != null)
            {
                leaveSpan = leave.LeaveTo - leave.LeaveFrom;
            }

            var breakSpan = TimeSpan.Zero;
            if (DateTime.Compare(signInTime, shift.StartBreak) > 0)
            {
                if (DateTime.Compare(signInTime, shift.EndBreak) >= 0)
                {
                    breakSpan = shift.EndBreak - shift.StartBreak;
                }
                else
                    breakSpan = signInTime - shift.StartBreak;
            }

            var lateSpan = signInTime - shift.StartShift - leaveSpan - breakSpan;
            return lateSpan < TimeSpan.Zero ? TimeSpan.Zero : lateSpan;

        }
    }
}
