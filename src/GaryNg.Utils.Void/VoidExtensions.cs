using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace GaryNg.Utils.Void
{
	public static class VoidExtensions
	{
		public static IObservable<Void> ToVoid(this IObservable<System.Reactive.Unit> @this) =>
			@this.Select(_ => Void.Value);

		public static IObservable<Void> ToVoid<T>(this IObservable<T> @this) => @this.Select(_ => Void.Value);

		public static Task<Void> ToVoid(this Task<System.Reactive.Unit> @this) => Task.FromResult(Void.Value);
	}
}