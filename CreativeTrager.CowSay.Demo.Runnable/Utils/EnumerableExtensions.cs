using System.Collections.Generic;

namespace CreativeTrager.CowSay.Demo.Runnable.Utils;

internal static class EnumerableExtensions
{
	public static bool Multiple<T>(this IEnumerable<T> enumerable)
	{
		var count = 0;
		foreach(var _ in enumerable)
			if(++count > 1)
				return true;

		return false;
	}
}