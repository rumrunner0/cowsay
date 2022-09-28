using System.Text;


namespace CreativeTrager.CowSay.Library.Related;
public abstract class RepeatingEntity : IRepeatingEntity 
{
	#region Data

	private const int _MIN_PHRASE_LENGTH = 1;
	private const int _MAX_PHRASE_LENGTH = 60;

	private string? _lastPhrase;

	#endregion

	#region Interface

	public string Repeat() => Repeat(phrase: _lastPhrase);
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

	#endregion

	#region Utils

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

	protected abstract string CreateAppearance();

	private string CreateAppearanceWithOffset(int offsetLength) 
	{
		var offset = CreateString(symbol: ' ', offsetLength);
		return $"{offset}{CreateAppearance().Replace(oldValue: Environment.NewLine, newValue: $"{Environment.NewLine}{offset}")}";
	}

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
			throw new ArgumentNullException(
				paramName: nameof(value),
				message: new StringBuilder()
					.Append($"Phrase {nameof(value)} can't be NULL! ")
					.Append($"Maybe you should override the {nameof(DefaultPhrase)} ")
					.Append($"property and set the specific value to be returned.")
					.ToString()
			);
		}
		if(value.Length < _MIN_PHRASE_LENGTH) 
		{
			throw new ArgumentOutOfRangeException(
				paramName: nameof(value),
				message: new StringBuilder()
					.Append($"Phrase row length can't be less than {_MIN_PHRASE_LENGTH}! ")
					.Append($"Available row length is {_MIN_PHRASE_LENGTH}-{_MAX_PHRASE_LENGTH}.")
					.ToString()
			);
		}
		if(value.Length > _MAX_PHRASE_LENGTH) 
		{
			throw new ArgumentOutOfRangeException(
				paramName: nameof(value),
				message: new StringBuilder()
					.Append($"Phrase row length can't be greater than {_MAX_PHRASE_LENGTH}! ")
					.Append($"Available row length is {_MIN_PHRASE_LENGTH}-{_MAX_PHRASE_LENGTH}.")
					.ToString()
			);
		}
	}

	#endregion
}
