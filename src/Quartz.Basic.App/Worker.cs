using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace Quartz.Basic.App;

[DisallowConcurrentExecution]
public class Worker : IJob
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        await Task.Delay(1000);
    }
}
