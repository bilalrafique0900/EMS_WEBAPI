using Hangfire;
using HangfireJob.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangfireJob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IConfiguration _configuration;
        public JobController(IJobService jobTestService, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager, IConfiguration configuration)
        {
            _jobService = jobTestService;
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
            _configuration = configuration;
        }

        [HttpGet("/fire-and-forget")]
        public ActionResult CreateFireAndForgetJob()
        {
            _backgroundJobClient.Enqueue(() => _jobService.FireAndForgetJob());
            return Ok();
        }

        [HttpGet("/delayed")]
        public ActionResult CreateDelayedJob()
        {
            _backgroundJobClient.Schedule(() => _jobService.DelayedJob(), TimeSpan.FromSeconds(60));
            return Ok();
        }

        [HttpGet("/start-import-attendance")]
        public ActionResult CreateReccuringJob()
        {
            string attendanceJobTime = _configuration.GetValue<string>("Hangfire:attendanceJobTime");
            _recurringJobManager.AddOrUpdate("jobId", () => _jobService.ReccuringJob(), attendanceJobTime, TimeZoneInfo.Local);//Cron.Daily(22,55)
            return Ok();
        }


        [HttpGet("/end-import-attendance")]
        public ActionResult RemoveReccuringJob()
        {
            RecurringJob.RemoveIfExists("jobId");
            
            return Ok();
        }

        [HttpGet("/sen-attendance-late-notifications/{branchId}")]
        public ActionResult AttendanceLateNotifications(Guid branchId)
        {
            string attendanceJobTime = _configuration.GetValue<string>("Hangfire:attendanceLateNotificationJobTime");
            _recurringJobManager.AddOrUpdate("jobId", () => _jobService.AttendanceLateNotifications(branchId), attendanceJobTime, TimeZoneInfo.Local);//Cron.Daily(22,55)
            return Ok();
        }

        [HttpGet("/continuation")]
        public ActionResult CreateContinuationJob()
        {
            var parentJobId = _backgroundJobClient.Enqueue(() => _jobService.FireAndForgetJob());
            _backgroundJobClient.ContinueJobWith(parentJobId, () => _jobService.ContinuationJob());

            return Ok();
        }
    }
}
