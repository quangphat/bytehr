using Microsoft.Extensions.DependencyInjection;
using ShiftManagement.Business;
using ShiftManagement.Repositories;
using System;
using System.Linq;

namespace ShiftManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IUserRepository, UserRepository>()
                .AddScoped<IShiftBusiness, ShiftBusiness>()
                .BuildServiceProvider(); ;


            //do the task
            var rpUser = serviceProvider.GetService<IUserRepository>();

            var logs = rpUser.GetAllLog();
            if (logs == null || !logs.Any())
                return;

            var shiftBusiness = serviceProvider.GetService<IShiftBusiness>();

            foreach(var log in logs)
            {
                Console.WriteLine($"StartShift: {log.Shift.StartShift}");
                Console.WriteLine($"EndShift: {log.Shift.EndShift}");
                Console.WriteLine($"StartBreak: {log.Shift.StartBreak}");
                Console.WriteLine($"EndBreak: {log.Shift.EndBreak}");
                Console.WriteLine($"LeaveFrom: {log.LeaveTime?.LeaveFrom}");
                Console.WriteLine($"LeaveTo: {log.LeaveTime?.LeaveTo}");
                Console.WriteLine($"SignInTime: {log.SignInTime?.SignInTime}");

                var lateSpan = shiftBusiness.CalculateLateTime(log.Shift, log.LeaveTime, log.SignInTime);
                Console.WriteLine($"lateSpan: {lateSpan}");
                Console.WriteLine("--------------------------------------------------");
            }

            Console.ReadLine();
        }
    }
}
