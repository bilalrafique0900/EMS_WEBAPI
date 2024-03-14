namespace HangfireJob.IServices
{
    public interface IJobService
    {
        void FireAndForgetJob();
        Task ReccuringJob();
        void DelayedJob();
        void ContinuationJob();
        Task AttendanceLateNotifications(Guid branchId);
    }
}
