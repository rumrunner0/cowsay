using System;

namespace Rumble.Cowsay.Tool.Runnable;

/// <summary>
/// Predefined echoing entities.
/// </summary>
internal static class EchoingEntities
{
	internal static EchoEntity Cow => new ()
	{
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

	internal static EchoEntity Elephant => new ()
	{
		DefaultPhrase = "Pawoo!",
		Appearance =
		(
			"""  __     __"""           + Environment.NewLine +
			""" /  \~~~/  \"""          + Environment.NewLine +
			"""(    ..     )----."""    + Environment.NewLine +
			""" \__     __/      \"""   + Environment.NewLine +
			"""   )|  /)         |\"""  + Environment.NewLine +
			"""    | /\  /___\   / ^""" + Environment.NewLine +
			"""     "-|__|   |__|"""
		)
	};
}