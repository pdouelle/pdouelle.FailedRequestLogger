namespace pdouelle.FailedRequestLogger;

public static class HttpResponseMessageExtensions
{
    public static bool IsFailedStatusCode(this HttpResponseMessage message) => !message.IsSuccessStatusCode;
}