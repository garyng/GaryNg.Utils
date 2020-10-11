using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GaryNg.Utils.Enumerable
{
	public static class EnumerableExtensions
	{
		public static bool Empty<T>(this IEnumerable<T> @this) => !@this.Any();

		public static IEnumerable<T> NotNull<T>(this IEnumerable<T> @this)
			=> @this.Where(x => x != null);

		public static IEnumerable<T> NotNullBy<T, U>(this IEnumerable<T> @this, Func<T, U> select)
			=> @this.Where(x => @select(x) != null);

		public static IEnumerable<U> SelectNotNull<T, U>(this IEnumerable<T> @this, Func<T, U> select)
			=> @this.Select(select).Where(x => x != null);

		/// <summary>
		/// Map source with <see cref="select"/>, remove nulls and flatten the resulting <see cref="IEnumerable{T}"/>
		/// </summary>
		public static IEnumerable<U> SelectManyNotNull<T, U>(this IEnumerable<T> @this, Func<T, IEnumerable<U>> select)
			=> @this.Select(select).Where(x => x != null).SelectMany(x => x);
		
		/// <summary>
		/// Map source with <see cref="select"/>, remove nulls, and flatten with <see cref="selectMany"/>.
		/// </summary>
		public static IEnumerable<V> SelectManyNotNull<T, U, V>(this IEnumerable<T> @this,
			Func<T, U> select,
			Func<U, IEnumerable<V>> selectMany)
			=> @this.Select(select).Where(x => x != null).SelectMany(selectMany);

	
	}
}