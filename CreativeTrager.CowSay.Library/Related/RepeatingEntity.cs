using System.Text;


namespace CreativeTrager.CowSay.Library.Related;
public abstract class RepeatingEntity : IRepeatingEntity 
{
	#region Data

	private const int _MIN_PHRASE_LENGTH = 1;
	private const int _MAX_PHRASE_LENGTH = 60;

	private string? _lastPhrase = null;

	#endregion

	#region Interface

	public string Repeat() => Repeat(phrase: this._lastPhrase ?? this.DefaultPhrase);
	public string Repeat(string? phrase) 
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

	#endregion

	#region Utils

	public RepeatingEntity() { }
	public RepeatingEntity(string phrase)
		=> this.LastPhrase = phrase;

	private string CreateAppearanceWithOffset(int offsetLength) 
	{
		var offset = CreateString(symbol: ' ', offsetLength);
		return $"{offset}{CreateAppearance().Replace(oldValue: Environment.NewLine, newValue: $"{Environment.NewLine}{offset}")}";
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

		if(value.Length < _MIN_PHRASE_LENGTH) 
		{
			throw new ArgumentOutOfRangeException(paramName: nameof(value), message:
				$"Phrase row length can't be less than {RepeatingEntity._MIN_PHRASE_LENGTH}! " +
				$"Available row length is {RepeatingEntity._MIN_PHRASE_LENGTH}-{RepeatingEntity._MAX_PHRASE_LENGTH}."
			);
		}

		if(value.Length > _MAX_PHRASE_LENGTH) 
		{
			throw new ArgumentOutOfRangeException(paramName: nameof(value), message: 
				$"Phrase row length can't be greater than {RepeatingEntity._MAX_PHRASE_LENGTH}! " +
				$"Available row length is {RepeatingEntity._MIN_PHRASE_LENGTH}-{RepeatingEntity._MAX_PHRASE_LENGTH}."
			);
		}
	}

	#endregion
}
