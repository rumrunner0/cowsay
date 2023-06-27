using System;
using System.Text;

namespace Rumble.Cowsay;

public abstract class RepeatingEntity : IRepeatingEntity
{
	private const int _minPhraseLength = 1;
	private const int _maxPhraseLength = 60;

	private string? _lastPhrase = null;

	public string Speak(string phrase, int lineLength)
	{
		ValidatePhrase(phrase);
		this._lastPhrase = phrase;

		var phraseLength = phrase!.Length;
		return new StringBuilder()
			.AppendLine($@"  {CreateString(symbol: '_', phraseLength)}  ")
			.AppendLine($@"< {phrase} >")
			.AppendLine($@"  {CreateString(symbol: '=', phraseLength)}  ")

			.Append(CreateStickWithOffset(offsetLength: phraseLength+4))
			.Append(CreateAppearanceWithOffset(offsetLength: phraseLength+7))

			.ToString();
	}

	public RepeatingEntity() { }
	public RepeatingEntity(string phrase)
		=> this.LastPhrase = phrase;

	private string CreateAppearanceWithOffset(int offsetLength)
	{
		var offset = CreateString(symbol: ' ', offsetLength);
		return $"{offset}{Appearance.Replace(oldValue: Environment.NewLine, newValue: $"{Environment.NewLine}{offset}")}";
	}

	protected string? LastPhrase
	{
		get => this._lastPhrase;
		private init
		{
			ValidatePhrase(value);
			this._lastPhrase = value;
		}
	}

	protected abstract string DefaultPhrase { get; }

	protected abstract string Appearance { get; }

	private static string CreateStickWithOffset(int offsetLength)
	{
		var offset = CreateString(symbol: ' ', offsetLength);
		return new StringBuilder()
			.AppendLine($@"{offset}\")
			.AppendLine($@"{offset} \")
			.ToString();
	}

	private static string CreateString(char symbol, int length)
	{
		return new (symbol, length);
	}

	private static void ValidatePhrase(string? value)
	{
		if(value is null)
		{
			throw new ArgumentNullException( paramName: nameof(value), message:
				$"Phrase {nameof(value)} can't be NULL! " +
				$"Maybe you should override the {nameof(RepeatingEntity.DefaultPhrase)} " +
				$"property and set the specific value to be returned."
			);
		}

		if(value.Length < _minPhraseLength)
		{
			throw new ArgumentOutOfRangeException(paramName: nameof(value), message:
				$"Phrase row length can't be less than {RepeatingEntity._minPhraseLength}! " +
				$"Available row length is {RepeatingEntity._minPhraseLength}-{RepeatingEntity._maxPhraseLength}."
			);
		}

		if(value.Length > _maxPhraseLength)
		{
			throw new ArgumentOutOfRangeException(paramName: nameof(value), message:
				$"Phrase row length can't be greater than {RepeatingEntity._maxPhraseLength}! " +
				$"Available row length is {RepeatingEntity._minPhraseLength}-{RepeatingEntity._maxPhraseLength}."
			);
		}
	}
}