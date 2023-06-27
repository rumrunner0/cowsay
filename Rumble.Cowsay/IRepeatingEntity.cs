namespace Rumble.Cowsay;

public interface IRepeatingEntity
{
	string Speak(string phrase, int lineLength);
}