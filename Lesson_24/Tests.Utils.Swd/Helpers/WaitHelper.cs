using Polly;
using static Polly.Policy;

namespace Tests.Utils.Swd.Helpers;

public static class WaitHelper
{
    private static readonly TimeSpan Timeout = TimeSpan.FromMilliseconds(500);

    public static T WaitAndHandleExceptionOrResult<T>(Func<T> func, Func<T, bool> condition)
    {
        return WaitAndHandleExceptionsOrResult(func, condition, 10, Timeout);
    }

    public static T WaitAndHandleExceptionsOrResult<T>(Func<T> func, Func<T, bool> condition, int retryCount, TimeSpan timeout)
    {
        var result = Handle<Exception>()
            .OrResult(condition)
            .WaitAndRetry(retryCount, _ => timeout)
            .ExecuteAndCapture(func)
            .Result;

        return result;
    }

    public static T WaitAndHandleExceptions<T>(Func<T> func)
    {
        return WaitAndHandleExceptions(func, 10, Timeout);
    }

    public static T WaitAndHandleExceptions<T>(Func<T> func, int retryCount, TimeSpan timeout)
    {
        return Handle<Exception>()
            .WaitAndRetry(retryCount, _ => timeout)
            .ExecuteAndCapture(func.Invoke).Result;
    }
    
    public static void WaitAndHandleExceptions(Action func)
    {
        WaitAndHandleExceptions(func, 10, Timeout);
    }

    public static void WaitAndHandleExceptions(Action func, int retryCount, TimeSpan timeout)
    {
         Handle<Exception>()
            .WaitAndRetry(retryCount, _ => timeout)
            .ExecuteAndCapture(func.Invoke);
    }
}