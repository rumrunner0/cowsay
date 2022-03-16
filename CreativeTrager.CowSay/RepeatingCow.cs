using System.Text;
using CreativeTrager.CowSay.Base;


namespace CreativeTrager.CowSay;
public sealed class RepeatingCow : RepeatingEntity 
{
	public RepeatingCow() => base.LastPhrase = this.DefaultPhrase;
	public RepeatingCow(string phrase) => base.LastPhrase = phrase;

	protected override string DefaultPhrase => "Moo!";
	protected override string CreateAppearance() 
	{
		return new StringBuilder()
			.AppendLine($@"^__^")
			.AppendLine($@"(oo)\_______")
			.AppendLine($@"(__)\       )\/\")
			.AppendLine($@"    ||----W |")
			.AppendLine($@"    ||     ||")
			.ToString();
	}
}