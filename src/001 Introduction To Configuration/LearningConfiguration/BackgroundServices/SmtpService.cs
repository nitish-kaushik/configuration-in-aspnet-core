using LearningConfiguration.Options;
using Microsoft.Extensions.Options;

namespace LearningConfiguration.BackgroundServices;

public class SmtpService : BackgroundService, IDisposable
{
    private readonly ILogger<SmtpService> _logger;
    private readonly IOptionsMonitor<SmtpOptions> _smtpOptions;
    private readonly IDisposable? _optionsChangeToken;

    public SmtpService(ILogger<SmtpService> logger, IOptionsMonitor<SmtpOptions> smtpOptions)
    {
        _logger = logger;
        _smtpOptions = smtpOptions;
        _optionsChangeToken = smtpOptions.OnChange((options, name) =>
        {
            _logger.LogInformation("name: {Name} Settings Changed with port: {Port} & username: {UserName}",
                name,
                options.Port,
                options.SenderEmail);
        });
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var provider1Options = _smtpOptions.Get("provider1");
            var provider2Options = _smtpOptions.Get("provider2");

            _logger.LogInformation("SmtpService with port: {Port} & username: {UserName}",
                provider1Options.Port,
                provider1Options.SenderEmail);

            _logger.LogInformation("SmtpService with port: {Port} & username: {UserName}",
                provider2Options.Port,
                provider2Options.SenderEmail);

            await Task.Delay(20000, stoppingToken);
        }
    }

    public override void Dispose()
    {
        _optionsChangeToken?.Dispose();
        base.Dispose();
    }
}
