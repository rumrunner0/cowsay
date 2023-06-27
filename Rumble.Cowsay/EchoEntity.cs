using System;

namespace Rumble.Cowsay;

///
/// <inheritdoc />
///
public sealed class EchoEntity : IEchoEntity
{
	/// <summary>
	/// Min length of the phrase line.
	/// </summary>
	private static readonly int _minLineLength = 1;

	/// <summary>
	/// Max length of the phrase line.
	/// </summary>
	private static readonly int _maxLineLength = 60;

	/// <summary>
	/// Phrase that represents an entity.
	/// </summary>
	private readonly string _defaultPhrase;

	/// <summary>
	/// ASCII art of an entity.
	/// </summary>
	private readonly string _appearance;

	/// <summary>
	/// Constructor of the instance.
	/// </summary>
	public EchoEntity()
	{
		this._defaultPhrase = string.Empty;
		this._appearance = string.Empty;
	}

	///
	/// <inheritdoc cref="_defaultPhrase" />
	///
	public required string DefaultPhrase
	{
		init => this._defaultPhrase = value;
	}

	///
	/// <inheritdoc cref="_appearance" />
	///
	public required string Appearance
	{
		init => this._appearance = value;
	}

	///
	/// <inheritdoc />
	///
	public string Speak()
	{
		return Echo(phrase: _defaultPhrase);
	}

	///
	/// <inheritdoc />
	///
	public string Echo(string phrase)
	{
		return Echo(phrase, EchoEntity._maxLineLength);
	}

	///
	/// <inheritdoc />
	///
	public string Echo(string phrase, int maxLineLength)
	{
		var phraseLength = phrase.Length;
		return
		(
			$@"{Symbol.DoubledTopLeftCorner}{new (Symbol.DashMinusHorizontalLine, phraseLength+2)}{Symbol.DoubledTopRightCorner}" + Environment.NewLine +
			$@"{Symbol.DoubledVerticalLine} {phrase} {Symbol.DoubledVerticalLine}" + Environment.NewLine +
			$@"{Symbol.DoubledBottomLeftCorner}{new (Symbol.DashMinusHorizontalLine, phraseLength+2)}{Symbol.DoubledBottomRightCorner}" + Environment.NewLine +
			StickWithOffset(phraseLength + 4) + Environment.NewLine +
			AppearanceWithOffset(phraseLength + 7)
		);
	}

	/// <summary>
	/// Stick part of the ASCII art.
	/// </summary>
	/// <param name="offsetLength">Length of the offset by which the stick is shifted</param>
	private static string StickWithOffset(int offsetLength)
	{
		var offset = new string(Symbol.Space, offsetLength);
		return
		(
			$@"{offset}\" + Environment.NewLine +
			$@"{offset} \"
		);
	}

	/// <summary>
	/// <see cref="_appearance"/> with added offset.
	/// </summary>
	/// <param name="offsetLength">Length of the offset by which the <see cref="_appearance"/> is shifted</param>
	/// <returns></returns>
	private string AppearanceWithOffset(int offsetLength)
	{
		var offset = new string(Symbol.Space, offsetLength);
		return $@"{offset}{_appearance.Replace(oldValue: Environment.NewLine, newValue: $"{Environment.NewLine}{offset}")}";
	}
}