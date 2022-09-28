namespace CreativeTrager.CowSay.Demo.Runnable;
internal static class StringExtensions 
{
	internal static bool IsEmpty(this string value) 
	{
		return 0u >= (uint)value.Length;
	}
	internal static bool IsWhiteSpace(this string value) 
	{
		return value.All(char.IsWhiteSpace);
	}
	internal static bool IsEmptyOrWhitespace(this string value) 
	{
		return
			value.IsEmpty() ||
			value.IsWhiteSpace();
	}
	internal static IEnumerable<string> SplitByWord(this string value) 
	{
		return value.Split(
			separator: new [] { ' ' },
			StringSplitOptions.RemoveEmptyEntries
		);
	}
}