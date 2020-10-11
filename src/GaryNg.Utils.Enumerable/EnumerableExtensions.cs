using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GaryNg.Utils.Enumerable
{
	public static class EnumerableExtensions
	{
		public static bool Empty<T>(this IEnumerable<T> @this) => !@this.Any();

		public static IEnumerable<T> NotNull<T>(this IEnumerable<T> @this) => @this.Where(x => x != null);
	}
}