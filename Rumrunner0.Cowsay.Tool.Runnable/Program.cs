using System;
using System.Linq;
using System.Text;
using Cocona;
using Humanizer;
using Rumrunner0.Cowsay;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

CoconaApp.Run((string? entityName, string? phrase, int? lineLength) =>
{
	var entities = (EchoEntity[]) [EchoingEntity.Cow, EchoingEntity.Elephant];
	var entity = entities.FirstOrDefault(e => e.Name.Equals(entityName?.Kebaberize())) ?? entities.First();

	Console.WriteLine
	(
		(phrase, lineLength) switch
		{
			{ phrase: not null, lineLength: not null } => entity.Echo(phrase, lineLength.Value),
			{ phrase: not null } => entity.Echo(phrase),
			_ => entity.Speak()
		}
	);
});