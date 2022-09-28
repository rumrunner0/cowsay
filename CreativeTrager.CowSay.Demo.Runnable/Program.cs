using System.Globalization;
using System.Text;
using CreativeTrager.CowSay.Demo.Runnable;
using CreativeTrager.CowSay.Library;
using CreativeTrager.CowSay.Library.Related;


Console.InputEncoding =
	Console.OutputEncoding =
		Encoding.UTF8;

var input = default(string);
if( args.Any()) 
{
	if(args.Length > 1) 
	{
		Console.WriteLine(new StringBuilder()
			.Append($"Oops! It seems you've passed more than one argument to the argument list. ")
			.Append($"If your phrase has multiple words, you may have missed quotes (\"<phrase>\"). ")
			.Append($"Please run the program again with single argument which will be your quoted phrase.")
			.ToString()
		);

		Environment.Exit((int)EnvironmentExitCode.InvalidInputData);
	}

	input = args.First();
	if(input.IsEmptyOrWhitespace()) 
	{
		Console.WriteLine(new StringBuilder()
			.Append($"Oops! It seems you haven't passed the phrase to repeat as first argument or passed something wrong! ")
			.Append($"Please run the program again with single argument which will be your quoted phrase.")
			.ToString()
		);

		Environment.Exit((int)EnvironmentExitCode.InvalidInputData);
	}

} else {

	Console.WriteLine($"Hi there! Moo! I'm the ASCII Cow. Enter the phrase you wanna me to repeat. Moo!");

	while(true) 
	{
		Console.Write($"Your phrase: ");
		input = Console.ReadLine();
		if(input is null || input.IsEmptyOrWhitespace()) 
		{
			Console.WriteLine(new StringBuilder()
				.Append($"Oops! It seems you've entered something wrong! ")
				.Append($"{CultureInfo.InvariantCulture.TextInfo.ToTitleCase(nameof(input))} can't be NULL or empty or whitespace. ")
				.Append($"Please enter the phrase again.")
				.ToString()
			);
			continue;
		}
		break;
	}
}

{
	var repeatingEntity = new RepeatingCow() as IRepeatingEntity;
	var repeatedInput = repeatingEntity.Repeat(phrase: input);
	Console.WriteLine(repeatedInput);
}

Console.Write($"Press <Enter> to exit... ");
Console.ReadLine();