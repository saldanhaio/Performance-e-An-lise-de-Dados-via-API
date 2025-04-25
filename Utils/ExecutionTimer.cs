using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CodeconChallenge.Helpers
{
    public static class ExecutionTimer
    {
        public static async Task<(T result, long timeInMilliseconds)> MeasureAsync<T>(Func<Task<T>> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            var stopwatch = Stopwatch.StartNew();
            var result = await action();
            stopwatch.Stop();
            return (result, stopwatch.ElapsedMilliseconds);
        }

        public static (T result, long timeInMilliseconds) Measure<T>(Func<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            var stopwatch = Stopwatch.StartNew();
            var result = action();
            stopwatch.Stop();
            return (result, stopwatch.ElapsedMilliseconds);
        }
    }
}
