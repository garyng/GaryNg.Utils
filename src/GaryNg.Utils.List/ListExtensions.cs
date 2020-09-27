using System;
using System.Collections.Generic;

namespace GaryNg.Utils.List
{
	public static class ListExtensions
	{
		public static IList<T> RemoveLast<T>(this IList<T> @this)
		{
			@this.RemoveAt(@this.Count - 1);
			return @this;
		}
	}
}
