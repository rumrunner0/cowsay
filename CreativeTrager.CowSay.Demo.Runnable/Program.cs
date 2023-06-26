using System.Text;
using CreativeTrager.CowSay.Demo.Runnable.Utils;
using CreativeTrager.CowSay.Library;
using CreativeTrager.CowSay.Library.Related;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;


Console.InputEncoding =
	Console.OutputEncoding =
		Encoding.Unicode;

Log.Information(messageTemplate: "Application has been started");

var input = default(string);
if( args.Any()) 
{
	const int INVALID_INPUT_DATA_EXIT_CODE = 1;
	if(args.Length > 1) 
	{
		Log.Warning(messageTemplate:
			"Oops! It seems you've passed more than one argument to the argument list. " +
			"If your phrase has multiple words, you may have missed quotes (\"<phrase>\"). " +
			"Please run the program again with single argument which will be your quoted phrase"
		);

		Environment.Exit(exitCode: INVALID_INPUT_DATA_EXIT_CODE);
	}

	input = args.First();
	if(input.IsEmptyOrWhitespace()) 
	{
		Log.Warning(messageTemplate:
			"Oops! It seems you haven't passed the phrase to repeat as first argument or passed something wrong! " +
			"Please run the program again with single argument which will be your quoted phrase"
		);

		Environment.Exit(exitCode: INVALID_INPUT_DATA_EXIT_CODE);
	}

} else 
{
	Log.Information(messageTemplate: "Hi there! Moo! I'm the ASCII Cow. Enter the phrase you wanna me to repeat. Moo!");

	while(true) 
	{
		Log.Information(messageTemplate: "Your phrase: ");
		input = Console.ReadLine();
		Log.Information(messageTemplate: "You entered phrase \"{EnteredPhrase}\" using console interface", input);

		if(input is null || input.IsEmptyOrWhitespace()) 
		{
			Log.Warning(messageTemplate:
				"Oops! It seems you've entered something wrong! " +
				"{ParameterName} can't be null or empty or whitespace. " + 
				"Please enter the phrase again",
				propertyValue: nameof(input)
			);

			continue;
		}

		break;
	}

}

{
	var repeatingEntity = new RepeatingCow() as IRepeatingEntity;
	var repeatedInput = repeatingEntity.Repeat(phrase: input);
	Log.Information(messageTemplate: "{NewLine}{RepeatedInput}", Environment.NewLine, repeatedInput);
}

Log.Information(messageTemplate: "Application has been stopped");
Log.Information(messageTemplate: "Press <Enter> to exit...");
Console.ReadLine();