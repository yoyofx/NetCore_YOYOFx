using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace YOYO.Owin.Helper
{

	internal static class TaskExtensions
	{
		public static Task Iterate(IEnumerable<Task> asyncIterator) {
			if (asyncIterator == null) {
				throw new ArgumentNullException("asyncIterator");
			}

			var enumerator = asyncIterator.GetEnumerator();
			if (enumerator == null) {
				throw new InvalidOperationException("Invalid enumerable - GetEnumerator returned null");
			}

			var tcs = new TaskCompletionSource<object>();
			tcs.Task.ContinueWith(_ => enumerator.Dispose(), TaskContinuationOptions.ExecuteSynchronously);

			Action<Task> recursiveBody = null;
			recursiveBody = delegate {
				try {
					if (enumerator.MoveNext()) {
						enumerator.Current.ContinueWith(recursiveBody, TaskContinuationOptions.ExecuteSynchronously);
					}
					else {
						tcs.TrySetResult(null);
					}
				}
				catch (Exception exc) {
					tcs.TrySetException(exc);
				}
			};

			recursiveBody(null);
			return tcs.Task;
		}

		public static Task Then(this Task first, Action next) {
			if (first == null) {
				throw new ArgumentNullException("first");
			}
			if (next == null) {
				throw new ArgumentNullException("next");
			}

			var tcs = new TaskCompletionSource<object>();

			first.ContinueWith(delegate {
				if (first.IsFaulted) {
					tcs.TrySetException(first.Exception.InnerExceptions);
				}
				else if (first.IsCanceled) {
					tcs.TrySetCanceled();
				}
				else {
					try {
						next();
						tcs.TrySetResult(null);
					}
					catch (Exception ex) {
						tcs.TrySetException(ex);
					}
				}
			});

			return tcs.Task;
		}

		public static Task Then(this Task first, Func<Task> next) {
			if (first == null) {
				throw new ArgumentNullException("first");
			}
			if (next == null) {
				throw new ArgumentNullException("next");
			}

			var tcs = new TaskCompletionSource<object>();
			first.ContinueWith(delegate {
				if (first.IsFaulted) {
					tcs.TrySetException(first.Exception.InnerExceptions);
				}
				else if (first.IsCanceled) {
					tcs.TrySetCanceled();
				}
				else {
					try {
						var t = next();
						if (t == null) {
							tcs.TrySetCanceled();
						}
						else {
							t.ContinueWith(delegate {
								if (t.IsFaulted) {
									tcs.TrySetException(t.Exception.InnerExceptions);
								}
								else if (t.IsCanceled) {
									tcs.TrySetCanceled();
								}
								else {
									tcs.TrySetResult(null);
								}
							});
						}
					}
					catch (Exception ex) {
						tcs.TrySetException(ex);
					}
				}
			});
			return tcs.Task;
		}

		public static Task<T2> Then<T2>(this Task first, Func<T2> next) {
			if (first == null) {
				throw new ArgumentNullException("first");
			}
			if (next == null) {
				throw new ArgumentNullException("next");
			}

			var tcs = new TaskCompletionSource<T2>();
			first.ContinueWith(delegate {
				if (first.IsFaulted) {
					tcs.TrySetException(first.Exception.InnerExceptions);
				}
				else if (first.IsCanceled) {
					tcs.TrySetCanceled();
				}
				else {
					try {
						var result = next();
						tcs.TrySetResult(result);
					}
					catch (Exception ex) {
						tcs.TrySetException(ex);
					}
				}
			});
			return tcs.Task;
		}

		public static Task<T2> Then<T2>(this Task first, Func<Task<T2>> next) {
			if (first == null) {
				throw new ArgumentNullException("first");
			}
			if (next == null) {
				throw new ArgumentNullException("next");
			}

			var tcs = new TaskCompletionSource<T2>();
			first.ContinueWith(delegate {
				if (first.IsFaulted) {
					tcs.TrySetException(first.Exception.InnerExceptions);
				}
				else if (first.IsCanceled) {
					tcs.TrySetCanceled();
				}
				else {
					try {
						var t = next();
						if (t == null) {
							tcs.TrySetCanceled();
						}
						else {
							t.ContinueWith(delegate {
								if (t.IsFaulted) {
									tcs.TrySetException(t.Exception.InnerExceptions);
								}
								else if (t.IsCanceled) {
									tcs.TrySetCanceled();
								}
								else {
									tcs.TrySetResult(t.Result);
								}
							},
								TaskContinuationOptions.ExecuteSynchronously);
						}
					}
					catch (Exception exc) {
						tcs.TrySetException(exc);
					}
				}
			},
				TaskContinuationOptions.ExecuteSynchronously);
			return tcs.Task;
		}

		public static Task Then<T1>(this Task<T1> first, Action<T1> next) {
			if (first == null) {
				throw new ArgumentNullException("first");
			}
			if (next == null) {
				throw new ArgumentNullException("next");
			}

			var tcs = new TaskCompletionSource<object>();

			first.ContinueWith(delegate {
				if (first.IsFaulted) {
					tcs.TrySetException(first.Exception.InnerExceptions);
				}
				else if (first.IsCanceled) {
					tcs.TrySetCanceled();
				}
				else {
					try {
						next(first.Result);
						tcs.TrySetResult(null);
					}
					catch (Exception ex) {
						tcs.TrySetException(ex);
					}
				}
			});

			return tcs.Task;
		}

		public static Task Then<T1>(this Task<T1> first, Func<T1, Task> next) {
			if (first == null) {
				throw new ArgumentNullException("first");
			}
			if (next == null) {
				throw new ArgumentNullException("next");
			}

			var tcs = new TaskCompletionSource<object>();
			first.ContinueWith(delegate {
				if (first.IsFaulted) {
					tcs.TrySetException(first.Exception.InnerExceptions);
				}
				else if (first.IsCanceled) {
					tcs.TrySetCanceled();
				}
				else {
					try {
						var t = next(first.Result);
						if (t == null) {
							tcs.TrySetCanceled();
						}
						else {
							t.ContinueWith(delegate {
								if (t.IsFaulted) {
									tcs.TrySetException(t.Exception.InnerExceptions);
								}
								else if (t.IsCanceled) {
									tcs.TrySetCanceled();
								}
								else {
									tcs.TrySetResult(null);
								}
							},
								TaskContinuationOptions.ExecuteSynchronously);
						}
					}
					catch (Exception exc) {
						tcs.TrySetException(exc);
					}
				}
			},
				TaskContinuationOptions.ExecuteSynchronously);

			return tcs.Task;
		}

		public static Task<T2> Then<T1, T2>(this Task<T1> first, Func<T1, T2> next) {
			if (first == null) {
				throw new ArgumentNullException("first");
			}
			if (next == null) {
				throw new ArgumentNullException("next");
			}

			var tcs = new TaskCompletionSource<T2>();
			first.ContinueWith(delegate {
				if (first.IsFaulted) {
					tcs.TrySetException(first.Exception.InnerExceptions);
				}
				else if (first.IsCanceled) {
					tcs.TrySetCanceled();
				}
				else {
					try {
						var result = next(first.Result);
						tcs.TrySetResult(result);
					}
					catch (Exception ex) {
						tcs.TrySetException(ex);
					}
				}
			});
			return tcs.Task;
		}

		public static Task<T2> Then<T1, T2>(this Task<T1> first, Func<T1, Task<T2>> next) {
			if (first == null) {
				throw new ArgumentNullException("first");
			}
			if (next == null) {
				throw new ArgumentNullException("next");
			}

			var tcs = new TaskCompletionSource<T2>();
			first.ContinueWith(delegate {
				if (first.IsFaulted) {
					tcs.TrySetException(first.Exception.InnerExceptions);
				}
				else if (first.IsCanceled) {
					tcs.TrySetCanceled();
				}
				else {
					try {
						var t = next(first.Result);
						if (t == null) {
							tcs.TrySetCanceled();
						}
						else {
							t.ContinueWith(delegate {
								if (t.IsFaulted) {
									tcs.TrySetException(t.Exception.InnerExceptions);
								}
								else if (t.IsCanceled) {
									tcs.TrySetCanceled();
								}
								else {
									tcs.TrySetResult(t.Result);
								}
							},
								TaskContinuationOptions.ExecuteSynchronously);
						}
					}
					catch (Exception exc) {
						tcs.TrySetException(exc);
					}
				}
			},
				TaskContinuationOptions.ExecuteSynchronously);
			return tcs.Task;
		}
	}
}


