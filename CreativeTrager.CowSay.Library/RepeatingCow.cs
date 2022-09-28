using System.Text;
using CreativeTrager.CowSay.Library.Related;


namespace CreativeTrager.CowSay.Library;
public sealed class RepeatingCow : RepeatingEntity 
{
	public RepeatingCow(string phrase) : base(phrase) { }
	public RepeatingCow() : base() { }

	protected override string DefaultPhrase => "Moo!";
	protected override string CreateAppearance() => new StringBuilder()
		.AppendLine($@"^__^")
		.AppendLine($@"(oo)\_______")
		.AppendLine($@"(__)\       )\/\")
		.AppendLine($@"    ||----W |")
		.AppendLine($@"    ||     ||")
		.ToString();
}