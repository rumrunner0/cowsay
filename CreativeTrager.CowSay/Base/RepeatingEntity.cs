using System;
using System.Text;


namespace CreativeTrager.CowSay.Base;
public abstract class RepeatingEntity : IRepeatingEntity 
{
	private const int _cMinPhraseLength = 1;
	private const int _cMaxPhraseLength = 60;

	private string? _lastPhrase;

	protected abstract string DefaultPhrase { get; }
	protected string? LastPhrase 
	{
		get => _lastPhrase;
		set 
		{
			ValidatePhrase(value);
			_lastPhrase = value;
		}
	}

	public string Repeat() => Repeat(_lastPhrase);
	public string Repeat(string? phrase) 
	{
		ValidatePhrase(phrase);
		this._lastPhrase = phrase;

		var phraseLength = phrase!.Length;
		return new StringBuilder()
			.AppendLine($@"  {CreateString(symbol: '_', phraseLength)}  ")
			.AppendLine($@"< {phrase} >")
			.AppendLine($@"  {CreateString(symbol: '=', phraseLength)}  ")

			.Append(CreateStickWithOffset(offsetLength: phraseLength + 4))
			.Append(CreateAppearanceWithOffset(offsetLength: phraseLength + 7))

			.ToString();
	}

	private string CreateAppearanceWithOffset(int offsetLength) 
	{
		var offset = CreateString(symbol: ' ', offsetLength);
		return $"{offset}{CreateAppearance().Replace(oldValue: Environment.NewLine, newValue: $"{Environment.NewLine}{offset}")}";
	}

	protected abstract string CreateAppearance();

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
	private static void   ValidatePhrase(string? value) 
	{
		if(value is null) 
		{
			throw new ArgumentNullException(
				paramName: nameof(value),
				message: new StringBuilder()
					.Append($"Phrase {nameof(value)} can't be NULL! ")
					.Append($"Maybe you should override the {nameof(DefaultPhrase)} ")
					.Append($"property and set the specific value to be returned.")
					.ToString()
			);
		}
		if(value.Length < _cMinPhraseLength) 
		{
			throw new ArgumentOutOfRangeException(
				paramName: nameof(value),
				message: new StringBuilder()
					.Append($"Phrase row length can't be less than {_cMinPhraseLength}! ")
					.Append($"Available row length is {_cMinPhraseLength}-{_cMaxPhraseLength}.")
					.ToString()
			);
		}
		if(value.Length > _cMaxPhraseLength) 
		{
			throw new ArgumentOutOfRangeException(
				paramName: nameof(value),
				message: new StringBuilder()
					.Append($"Phrase row length can't be greater than {_cMaxPhraseLength}! ")
					.Append($"Available row length is {_cMinPhraseLength}-{_cMaxPhraseLength}.")
					.ToString()
			);
		}
	}
}
