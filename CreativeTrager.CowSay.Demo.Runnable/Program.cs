using System;
using System.Text;
using Cocona;
using CreativeTrager.CowSay.Library;
using CreativeTrager.CowSay.Library.Related;
using Rumble.Essentials;
using Serilog;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Log.Logger = Essential.OfType<ILogger>();
CoconaApp.Run((string? phrase, int? lineLength) =>
{
	var logger = Log.Logger.ForContext<Program>();
	logger.Information("Application has been started");

	var repeatingEntity = new RepeatingCow() as IRepeatingEntity;
	var repeatedPhrase = phrase is null ? repeatingEntity.Speak() : repeatingEntity.Repeat(phrase);
	Console.WriteLine(repeatedPhrase);

	logger.Information("Application has been shut down");
	logger.Information("");
});

Log.CloseAndFlush();
Environment.Exit(EnvironmentExitCode.Success);