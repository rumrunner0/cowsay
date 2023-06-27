using System;

namespace Rumble.Cowsay.Tool.Runnable;

/// <summary>
/// Predefined echoing entities.
/// </summary>
internal static class EchoingEntities
{
	/// <summary>
	/// Cow echo entity.
	/// </summary>
	internal static EchoEntity Cow => new ()
	{
		Name = nameof(Cow),
		DefaultPhrase = "Moo!",
		Appearance =
		(
			"""^__^"""             + Environment.NewLine +
			"""(oo)\_______"""     + Environment.NewLine +
			"""(__)\       )\/\""" + Environment.NewLine +
			"""    ||----W |"""    + Environment.NewLine +
			"""    ||     ||"""
		)
	};

	/// <summary>
	/// Elephant echo entity.
	/// </summary>
	internal static EchoEntity Elephant => new ()
	{
		Name = nameof(Elephant),
		DefaultPhrase = "Pawoo!",
		Appearance =
		(
			"""  __     __"""           + Environment.NewLine +
			""" /  \~~~/  \"""          + Environment.NewLine +
			"""(    . .    )----."""    + Environment.NewLine +
			""" \__     __/      \"""   + Environment.NewLine +
			"""   )|  /)         |\"""  + Environment.NewLine +
			"""    | /\  /___\   / ^""" + Environment.NewLine +
			"""     "-|__|   |__|"""
		)
	};
}