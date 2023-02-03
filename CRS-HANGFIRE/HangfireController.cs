using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace CRS_HANGFIRE
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HangfireController : ControllerBase
    {
        private readonly ILogger<HangfireController> logger;
        private readonly IBackgroundJobClient backgroundJobClient;
        private readonly IRecurringJobManager recurringJobManager;
        private readonly IHangfireJobService hangfireJobService;

        public HangfireController(ILogger<HangfireController> logger, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager, IHangfireJobService hangfireJobService)
        {
            this.logger = logger;
            this.backgroundJobClient = backgroundJobClient;
            this.recurringJobManager = recurringJobManager;
            this.hangfireJobService = hangfireJobService;
        }

        [HttpPost("[action]")]
        public ActionResult TriggerTestJob()
        {
            logger.LogInformation("Trigger test job");
            try
            {
                backgroundJobClient.Enqueue(() => hangfireJobService.TestJob());
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public ActionResult ContinuationJob()
        {
            logger.LogInformation("Trigger continuation job");
            try
            {
                var parentJobId = backgroundJobClient.Enqueue(() => hangfireJobService.TestJob());
                backgroundJobClient.ContinueJobWith(parentJobId, () => hangfireJobService.TestJob());
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public ActionResult DelayedJob()
        {
            logger.LogInformation("Trigger delayed job");
            try
            {
                backgroundJobClient.Schedule(() => hangfireJobService.DelayedJob(), TimeSpan.FromMinutes(1));
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public ActionResult RecurringJob()
        {
            logger.LogInformation("Trigger recurring job");
            try
            {
                recurringJobManager.AddOrUpdate(Guid.NewGuid().ToString(), () => hangfireJobService.RecurringJob(), Cron.Daily());
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public ActionResult ScheduledJob()
        {
            logger.LogInformation("Trigger schedule job");
            try
            {
                backgroundJobClient.Schedule(() => hangfireJobService.ScheduledJob(), TimeSpan.FromHours(3));
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
