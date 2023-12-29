using System;
using Humanizer;

namespace Rumrunner0.Cowsay;

///
/// <inheritdoc />
///
public sealed class EchoEntity : IEchoEntity
{
	/// <summary>
	/// Minimum length of the phrase line.
	/// </summary>
	private const int _minLineLength = 1;

	/// <summary>
	/// Maximum length of the phrase line.
	/// </summary>
	private const int _maxLineLength = 60;

	/// <summary>
	/// Name of the entity.
	/// </summary>
	private readonly string _name;

	/// <summary>
	/// Phrase that represents the entity.
	/// </summary>
	private readonly string _defaultPhrase;

	/// <summary>
	/// ASCII art of the entity.
	/// </summary>
	private readonly string _appearance;

	///
	/// <inheritdoc cref="EchoEntity" />
	///
	public EchoEntity()
	{
		this._name = string.Empty;
		this._defaultPhrase = string.Empty;
		this._appearance = string.Empty;
	}

	///
	/// <inheritdoc cref="_name" />
	///
	public required string Name
	{
		get => this._name;
		init => this._name = value.Kebaberize();
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
		return Echo(this._defaultPhrase);
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
			$"{Symbol.TopLeftCorner}{new (Symbol.HorizontalLine, phraseLength+2)}{Symbol.TopRightCorner}" + Environment.NewLine +
			$"{Symbol.VerticalLine} {phrase} {Symbol.VerticalLine}" + Environment.NewLine +
			$"{Symbol.BottomLeftCorner}{new (Symbol.HorizontalLine, phraseLength+2)}{Symbol.BottomRightCorner}" + Environment.NewLine +
			StickWithOffset(phraseLength + 4) + Environment.NewLine +
			AppearanceWithOffset(phraseLength + 7)
		);
	}

	/// <summary>
	/// Stick part of the ASCII art.
	/// </summary>
	/// <param name="offsetLength">Length of the offset by which the stick is shifted.</param>
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
	/// <see cref="Appearance"/> with added offset.
	/// </summary>
	/// <param name="offsetLength">Length of the offset by which the <see cref="Appearance"/> is shifted.</param>
	/// <returns><see cref="Appearance"/> with added offset.</returns>
	private string AppearanceWithOffset(int offsetLength)
	{
		var offset = new string(Symbol.Space, offsetLength);
		return $"{offset}{this._appearance.Replace(Environment.NewLine, $"{Environment.NewLine}{offset}")}";
	}
}