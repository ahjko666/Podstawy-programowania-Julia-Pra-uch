using System;
using System.Linq;

string[] availableSigns = { "rock", "paper", "scissors", "lizard", "spock" };
int firstPlayerPoints = 0;
int secondPlayerPoints = 0;
bool playingSolo = true;


string firstPlayerName = GetName(1);
string secondPlayerName = GetName(2);

Random rng = new Random();

// for (int i = 0; i < 10; i++)
// {
// 	int randomNumber = rng.Next(3);
// 	Console.WriteLine(randomNumber);
// }

Console.WriteLine("How many wins to win?");
bool parsingResult = int.TryParse(Console.ReadLine(), out int winsToWin);
if (!parsingResult)
{
	winsToWin = 3;
}

Console.WriteLine(winsToWin);

while (firstPlayerPoints < winsToWin && secondPlayerPoints < winsToWin)
{
	string firstSign = GetSign(firstPlayerName);
	if (firstSign == "quit")
	{
		break;
	}

	string secondSign;

	if (playingSolo)
	{
		int signIndex = rng.Next(availableSigns.Length);
		secondSign = availableSigns[signIndex];
		Console.WriteLine($"Computer chose {secondSign}");

		// secondSign = availableSigns[rng.Next(availableSigns.Length)];
	}
	else
	{
		secondSign = GetSign(secondPlayerName);

		if (secondSign == "quit")
		{
			break;
		}
	}

	

	if (firstSign == secondSign)
	{
		Console.WriteLine("It's a draw");
	}
	else if (firstSign == "rock" && secondSign == "lizard" ||
	firstSign == "rock" && secondSign == "scissors" ||
	firstSign == "paper" && secondSign == "spock" ||
	firstSign == "paper" && secondSign == "rock" ||
	firstSign == "scissors" && secondSign == "paper" ||
	firstSign == "scissors" && secondSign == "lizard" ||
	firstSign == "lizard" && secondSign == "paper" ||
	firstSign == "lizard" && secondSign == "spock" ||
	firstSign == "spock" && secondSign == "rock" ||
	firstSign == "spock" && secondSign == "scissors"
	)
	{
		firstPlayerPoints += 1;
		Console.WriteLine($"{firstPlayerName} won");
	}
	else
	{
		secondPlayerPoints += 1;
		Console.WriteLine($"{secondPlayerName} won");
	}

	Console.WriteLine($"[{firstPlayerName}] {firstPlayerPoints} : {secondPlayerPoints} [{secondPlayerName}]");
}
Console.WriteLine("Did you have fun?");
Console.ReadLine();
Console.WriteLine("Cool");
Console.WriteLine("Thanks for playing");
Console.WriteLine("Press any key to close");
Console.ReadKey();

string GetName(int playerNumber)
{
	Console.WriteLine($"What's your name, player {playerNumber}?");
	// string name = Console.ReadLine() ?? $"Player {playerNumber}";
	string? input = Console.ReadLine();

	return string.IsNullOrWhiteSpace(input) ? $"Player {playerNumber}" : input;
}

string GetSign(string playerName)
{
	Console.WriteLine($"Provide sign {playerName}");
	string sign = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;

	while (!availableSigns.Contains(sign) && sign != "quit")
	{
		Console.WriteLine("wrong sign");
		sign = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
	}
	return sign;
}