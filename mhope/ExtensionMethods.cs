using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace martyhope.com
{
    internal static class ExtensionMethods
    {
        internal static String SecureStringToString(this SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        internal static double MillisecondsToSeconds(this long millseconds)
        {
            return (double)millseconds / (double)1000;
        }

        public static int IndexOf<T>(this IEnumerable<T> obj, T value)
        {
            return obj.IndexOf(value, null);
        }

        public static IEnumerable<Task<T>>
            InCompletionOrder<T>(this IEnumerable<Task<T>> tasks)
        {
            var inputs = tasks;
            var results = inputs.Select(i => new TaskCompletionSource<T>()).ToList();

            int index = -1;
            foreach (var task in inputs)
            {
                task.ContinueWith((t, state) =>
                {
                    var nextResult = results[Interlocked.Increment(ref index)];
                    nextResult.TrySetResult(t.Result);
                }, TaskContinuationOptions.ExecuteSynchronously);
            }
            return results.Select(r => r.Task);
        }

        private static int IndexOf<T>(this IEnumerable<T> obj, T value, IEqualityComparer<T> comparer)
        {
            comparer = comparer ?? EqualityComparer<T>.Default;
            var found = obj
                .Select((a, i) => new { a, i })
                .FirstOrDefault(x => comparer.Equals(x.a, value));
            return found?.i ?? -1;
        }



    }
}