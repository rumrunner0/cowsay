using System.Text;
using CreativeTrager.CowSay.Library.Related;


namespace CreativeTrager.CowSay.Library;
public sealed class RepeatingCow : RepeatingEntity 
{
	public RepeatingCow() => base.LastPhrase = this.DefaultPhrase;
	public RepeatingCow(string phrase) => base.LastPhrase = phrase;

	protected override string DefaultPhrase => "Moo!";
	protected override string CreateAppearance()
		=> new StringBuilder()
			.AppendLine($@"^__^")
			.AppendLine($@"(oo)\_______")
			.AppendLine($@"(__)\       )\/\")
			.AppendLine($@"    ||----W |")
			.AppendLine($@"    ||     ||")
			.ToString();
}