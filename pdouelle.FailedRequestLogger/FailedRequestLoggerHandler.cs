using Serilog;

namespace pdouelle.FailedRequestLogger;

public sealed class FailedRequestLoggerHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

        if (response.IsFailedStatusCode())
        {
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            Log.Warning("Failed Request:{@Request}\nContent:{@Content}", request, content);
        }

        return response;
    }
}