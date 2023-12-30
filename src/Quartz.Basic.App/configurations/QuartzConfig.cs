using Microsoft.Extensions.DependencyInjection;

namespace Quartz.Basic.App.configurations
{
    public static class QuartzConfig
    {
        public static void AddQuartzConfig(this IServiceCollection services)
        {
            services.AddQuartz(q =>
            {
                var jobKey = new JobKey("my-key");

                q.AddJob<Worker>(opts => opts.WithIdentity(jobKey));

                q.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithCronSchedule("0/5 * * * * ?"));

            });

            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

        }
    }
}
