using System;
using System.Globalization;
using System.Linq;
using System.Text;
using CreativeTrager.CowSay;
using CreativeTrager.CowSay.Base;
using CreativeTrager.CowSay.Demo.Entities;
using CreativeTrager.CowSay.Demo.Utils.Extensions;


Console.InputEncoding =
	Console.OutputEncoding =
		Encoding.UTF8;

var input = default(string);
if(args.Any()) 
{
	if(args.Length > 1) 
	{
		Console.WriteLine(new StringBuilder()
			.Append($"Oops! It seems you've passed more than one argument ")
			.Append($"to the argument list. If your phrase has multiple words, ")
			.Append($"you may have missed quotes (\"<phrase>\"). ")
			.Append($"Please run the program again with single argument ")
			.Append($"which will be your quoted phrase.")
			.ToString()
		);
		return (int)EnvironmentExitCode.InvalidInputData;
	}

	input = args.First();
	if(input.IsEmptyOrWhitespace()) 
	{
		Console.WriteLine(new StringBuilder()
			.Append($"Oops! It seems you haven't passed the phrase to repeat ")
			.Append($"as first argument or passed something wrong! ")
			.Append($"Please run the program again with single argument ")
			.Append($"which will be your quoted phrase.")
			.ToString()
		);
		return (int)EnvironmentExitCode.InvalidInputData;
	}

} else 
{
	Console.WriteLine(new StringBuilder()
		.Append($"Hi there! Moo! I'm the ASCII Cow. ")
		.Append($"Enter the phrase you wanna me to repeat. Moo!")
		.ToString()
	);

	while(true) 
	{
		Console.Write($"Your phrase: ");
		input = Console.ReadLine();
		if(input is null || input.IsEmptyOrWhitespace()) 
		{
			Console.WriteLine(new StringBuilder()
				.Append($"Oops! It seems you've entered something wrong! ")
				.Append($"{CultureInfo.InvariantCulture.TextInfo.ToTitleCase(nameof(input))} ")
				.Append($"can't be NULL or empty or whitespace. ")
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

Console.Write($"Press <Enter> to exit the program... ");
Console.ReadKey();

return (int)EnvironmentExitCode.Success;