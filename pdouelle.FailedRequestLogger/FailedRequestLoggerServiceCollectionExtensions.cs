using Microsoft.Extensions.DependencyInjection;

namespace pdouelle.FailedRequestLogger;

public static class FailedRequestLoggerServiceCollectionExtensions
{
    public static IHttpClientBuilder AddFailedRequestLoggerHandler(this IHttpClientBuilder httpClientBuilder) =>
        httpClientBuilder.AddHttpMessageHandler<FailedRequestLoggerHandler>();
}