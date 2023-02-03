namespace CRS_HANGFIRE
{
    public interface IHangfireJobService
    {
        public void RecurringJob();
        public void ScheduledJob();
        public void DelayedJob();
        public void ContinuationJob();
        public void TestJob();

    }
}
