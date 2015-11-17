using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Owin
{
    internal static class TaskHelper
    {
        static TaskHelper()
        {
            var completed = new TaskCompletionSource<int>();
            completed.SetResult(0);
            _completed = completed.Task;

            var canceled = new TaskCompletionSource<int>();
            canceled.SetCanceled();
            _canceled = canceled.Task;
        }

        private static readonly Task _canceled;
        private static readonly Task _completed;

        public static Task Canceled()
        {
            return _canceled;
        }

        public static Task<T> Canceled<T>()
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetCanceled();
            return tcs.Task;
        }

        /// <summary>
        /// Creates a completed <see cref="Task"/>.
        /// </summary>
        public static Task Completed()
        {
            return _completed;
        }

        /// <summary>
        /// Creates a completed <see cref="Task"/> with the specified <c>Result</c> value.
        /// </summary>
        /// <typeparam name="T">The type of the <c>Result</c> value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>A <see cref="Task{T}"/> set to completed with the specified value as the <c>Result</c>.</returns>
        public static Task<T> Completed<T>(T value)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetResult(value);
            return tcs.Task;
        }

        /// <summary>
        /// Creates a faulted <see cref="Task"/>.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>A faulted <see cref="Task"/> with the <c>Exception</c> property set to the specified value.</returns>
        public static Task Exception(Exception exception)
        {
            var tcs = new TaskCompletionSource<int>();
            tcs.SetException(exception);
            return tcs.Task;
        }
    }
}
