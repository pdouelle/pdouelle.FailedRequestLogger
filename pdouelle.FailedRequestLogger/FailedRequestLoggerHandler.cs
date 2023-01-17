using Microsoft.Extensions.Logging;

namespace pdouelle.FailedRequestLogger;

public sealed class FailedRequestLoggerHandler : DelegatingHandler
{
    private readonly ILogger<FailedRequestLoggerHandler> _logger;

    public FailedRequestLoggerHandler(ILogger<FailedRequestLoggerHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

        if (response.IsFailedStatusCode())
        {
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogWarning("Failed Request:{@Request}\nContent:{@Content}", request, content);
        }

        return response;
    }
}