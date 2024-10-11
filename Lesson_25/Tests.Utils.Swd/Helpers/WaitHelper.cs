using Polly;
using static Polly.Policy;

namespace Tests.Utils.Swd.Helpers;

public static class WaitHelper
{
    private static readonly TimeSpan Timeout = TimeSpan.FromMilliseconds(500);

    public static T WaitAndReturn<T>(Func<T> func, Func<T, bool> condition)
    {
        return WaitAndReturn(func, condition, 10, Timeout);
    }

    public static T WaitAndReturn<T>(Func<T> func, Func<T, bool> condition, int retryCount, TimeSpan timeout)
    {
        var result = Handle<Exception>()
            .OrResult(condition)
            .WaitAndRetry(retryCount, _ => timeout)
            .ExecuteAndCapture(func)
            .Result;

        return result;
    }

    public static T Wait<T>(Func<T> func)
    {
        return Wait(func, 10, Timeout);
    }

    public static T Wait<T>(Func<T> func, int retryCount, TimeSpan timeout)
    {
        return Handle<Exception>()
            .WaitAndRetry(retryCount, _ => timeout)
            .ExecuteAndCapture(func.Invoke).Result;
    }

    public static void Wait(Action func)
    {
        Wait(func, 10, Timeout);
    }

    public static void Wait(Action func, int retryCount, TimeSpan timeout)
    {
        Handle<Exception>()
            .WaitAndRetry(retryCount, _ => timeout)
            .ExecuteAndCapture(func.Invoke);
    }
}