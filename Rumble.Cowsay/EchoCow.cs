using System;

namespace Rumble.Cowsay;

public sealed class EchoCow : EchoEntity
{
	public EchoCow() : base() { }
	public EchoCow(string phrase) : base(phrase) { }

	protected override string DefaultPhrase => "Moo!";
	protected override string Appearance =>
		@"^__^" + Environment.NewLine +
		@"(oo)\_______" + Environment.NewLine +
		@"(__)\       )\/\" + Environment.NewLine +
		@"    ||----W |" + Environment.NewLine +
		@"    ||     ||";
}