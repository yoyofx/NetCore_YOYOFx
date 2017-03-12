//using System;
//using System.IO;
//using System.Threading;
//using System.Threading.Tasks;
//using YOYO.AspNetCore.Owin;

//namespace YOYO.AspNetCore.Owin.Helper
//{
//    internal static partial class StreamExtensions
//    {
//        public static Task FlushAsync(this Stream stream, CancellationToken cancellationToken = default(CancellationToken)) {
//            if (cancellationToken.IsCancellationRequested) {
//                return OwinConstants.TaskHelper.Canceled();
//            }
//            stream.Flush();
//            return OwinConstants.TaskHelper.Completed();
//        }

//        public static Task<int> ReadAsync(this Stream stream,
//                                          byte[] buffer,
//                                          int offset,
//                                          int count,
//                                          CancellationToken cancellationToken = default(CancellationToken)) {
//            if (cancellationToken.IsCancellationRequested) {
//                return OwinConstants.TaskHelper.Canceled<int>();
//            }
//            return Task<int>.Factory.FromAsync(stream.BeginRead, stream.EndRead, buffer, offset, count, null);
//        }

//        public static Task WriteAsync(this Stream stream,
//                                      byte[] buffer,
//                                      int offset,
//                                      int count,
//                                      CancellationToken cancellationToken = default(CancellationToken)) {
//            if (cancellationToken.IsCancellationRequested) {
//                return OwinConstants.TaskHelper.Canceled();
//            }
//            var completionSource = new TaskCompletionSource<int>();
//            var processSync = stream.BeginWrite(buffer,
//                                                offset,
//                                                count,
//                                                processAsync => {
//                                                    if (processAsync.CompletedSynchronously) {
//                                                        return;
//                                                    }
//                                                    FinishWriteAsync(stream, processAsync, completionSource);
//                                                },
//                                                null);
//            if (processSync.CompletedSynchronously) {
//                FinishWriteAsync(stream, processSync, completionSource);
//            }
//            return completionSource.Task;
//        }

//        private static void FinishWriteAsync(Stream stream, IAsyncResult asyncResult, TaskCompletionSource<int> taskCompletionSource) {
//            try {
//                stream.EndWrite(asyncResult);
//                taskCompletionSource.SetResult(0);
//            }
//            catch (OperationCanceledException) {
//                taskCompletionSource.TrySetCanceled();
//            }
//            catch (Exception exception) {
//                taskCompletionSource.SetException(exception);
//            }
//        }
//    }
//}