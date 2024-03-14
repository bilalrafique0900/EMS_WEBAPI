using HangfireJob.IServices;
using System.Data;
using EmployeeSystem.Domain.Common.CommonMethod;
using EmployeeSystem.Infra.MySql;
using EmployeeSystem.Infra.IRepositories.IAttendance;
using Hangfire;
using EmployeeSystem.Infra.IServices;
using EmployeeSystem.Application.Contracts.DTO;

namespace HangfireJob.Services
{
    public class JobService : IJobService
    {

        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IFirebaseService _firebaseService;

        public JobService(IAttendanceRepository attendanceRepository
            , IFirebaseService firebaseService
            )
        {

            _attendanceRepository = attendanceRepository;
            _firebaseService = firebaseService;
        }
        public void FireAndForgetJob()
        {
            Console.WriteLine("Hello from a Fire and Forget job!");
        }
        [AutomaticRetry(Attempts = 2)]
        public async Task ReccuringJob()
        {
            try
            {

                await _attendanceRepository.ImportFromMysql(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            catch (Exception)
            {

                throw;
            }

        }

        [AutomaticRetry(Attempts = 2)]
        public async Task AttendanceLateNotifications(Guid branchId)
        {
            try
            {

                await _firebaseService.SendAttendanceLateNotificationAsync(branchId
                    , DateTime.Now
                    , new FirebaseDto { NotificationTitle= "{student} is late", NotificationBody="Late Alert" });
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void DelayedJob()
        {
            Console.WriteLine("Hello from a Delayed job!");
        }
        public void ContinuationJob()
        {
            Console.WriteLine("Hello from a Continuation job!");
        }
    }
}
