using System;
using System.Text;
using Cocona;
using Rumble.Cowsay.Tool.Runnable;
using Rumble.Essentials;
using Serilog;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Log.Logger = Essential.OfType<ILogger>();
CoconaApp.Run((string? phrase, int? lineLength) =>
{
	var logger = Log.Logger.ForContext<Program>();
	logger.Information("Application has been started");

	var repeatingEntity = EchoingEntities.Cow;
	Console.WriteLine
	(
		(phrase, lineLength) switch
		{
			{ phrase: not null, lineLength: not null } => repeatingEntity.Echo(phrase, lineLength.Value),
			{ phrase: not null } => repeatingEntity.Echo(phrase),
			_ => repeatingEntity.Speak()
		}
	);

	logger.Information("Application has been shut down");
	logger.Information("");
});

Log.CloseAndFlush();
Environment.Exit(EnvironmentExitCode.Success);