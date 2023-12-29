using System;

namespace Rumrunner0.Cowsay;

/// <summary>
/// Predefined echoing entities.
/// </summary>
public static class EchoingEntity
{
	/// <summary>
	/// Cow echo entity.
	/// </summary>
	public static EchoEntity Cow => new ()
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
	public static EchoEntity Elephant => new ()
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