using System;
using System.Linq;
using System.Text;
using Cocona;
using Humanizer;
using Rumble.Cowsay.Tool.Runnable;
using Rumble.Essentials;
// using Serilog;

// ReSharper disable MissingIndent

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

// Log.Logger = Essential.OfType<ILogger>();
CoconaApp.Run((string? entityName, string? phrase, int? lineLength) =>
{
	// var logger = Log.Logger.ForContext<Program>();
	// logger.Information("Application has been started");

	var existingEntities = new []
	{
		EchoingEntities.Cow,
		EchoingEntities.Elephant
	};

	var entity =
	(
		entityName is not null &&
		existingEntities.SingleOrDefault(entity => entity.Name.Equals(entityName.Kebaberize())) is { } entry
	)
	? entry
	: existingEntities.First();

	Console.WriteLine
	(
		(phrase, lineLength) switch
		{
			{ phrase: not null, lineLength: not null } => entity.Echo(phrase, lineLength.Value),
			{ phrase: not null } => entity.Echo(phrase),
			_ => entity.Speak()
		}
	);

	// logger.Information("Application has been shut down");
	// logger.Information("");
});

// Log.CloseAndFlush();
Environment.Exit(EnvironmentExitCode.Success);