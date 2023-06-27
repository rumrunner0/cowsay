namespace Rumble.Cowsay;

/// <summary>
/// Predefined symbols.
/// For more variants, please take a look at the following link.
/// https://en.wikipedia.org/wiki/Box-drawing_character
/// </summary>
public static class Symbol
{
	/// <summary>
	/// Space symbol.
	/// </summary>
	public static char Space => ' ';

	/// <summary>
	/// Horizontal line symbol.
	/// </summary>
	public static char HorizontalLine => '┄';

	/// <summary>
	/// Vertical line symbol.
	/// </summary>
	public static char VerticalLine => '║';

	/// <summary>
	/// Top-left corner symbol.
	/// </summary>
	public static char TopLeftCorner => '╓';

	/// <summary>
	/// Bottom-left corner symbol.
	/// </summary>
	public static char BottomLeftCorner => '╙';

	/// <summary>
	/// Top-right corner symbol.
	/// </summary>
	public static char TopRightCorner => '╖';

	/// <summary>
	/// Bottom-right corner symbol.
	/// </summary>
	public static char BottomRightCorner => '╜';
}