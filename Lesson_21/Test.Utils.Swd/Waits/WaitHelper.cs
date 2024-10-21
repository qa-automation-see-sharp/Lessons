using Polly;
using static Polly.Policy;

namespace Test.Utils.Swd.Waits;

public static class WaitHelper
{
    private static readonly TimeSpan Timeout = TimeSpan.FromMilliseconds(5000);

    public static T Wait<T>(Func<T> func, Func<T, bool> condition)
    {
        return Wait(func, condition, 10, Timeout);
    }

    public static T Wait<T>(Func<T> func, Func<T, bool> condition, int retryCount, TimeSpan timeout)
    {
        var result = Handle<Exception>()
            .OrResult(condition)
            .WaitAndRetry(retryCount, _ => timeout)
            .ExecuteAndCapture(func)
            .Result;

        return result;
    }

    public static void Wait(Action action)
    {
        WaitForAction(action, 10, Timeout);
    }

    public static void WaitForAction(Action action, int retryCount, TimeSpan timeout)
    {
        Handle<Exception>()
            .WaitAndRetry(retryCount, _ => timeout)
            .ExecuteAndCapture(action.Invoke);
    }
}