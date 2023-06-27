using System;
using System.Text;
using Cocona;
using Rumble.Cowsay;
using Rumble.Essentials;
using Serilog;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Log.Logger = Essential.OfType<ILogger>();
CoconaApp.Run((string? phrase, int? lineLength) =>
{
	var logger = Log.Logger.ForContext<Program>();
	logger.Information("Application has been started");

	var repeatingEntity = new EchoCow() as IEchoEntity;
	var repeatedPhrase = repeatingEntity.Echo(phrase ?? string.Empty, lineLength ?? 0);
	Console.WriteLine(repeatedPhrase);

	logger.Information("Application has been shut down");
	logger.Information("");
});

Log.CloseAndFlush();
Environment.Exit(EnvironmentExitCode.Success);