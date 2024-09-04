List<string> history = new List<string>();
Random random = new Random();
string option;

do
{
    Console.WriteLine("Choose a game:");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. View History");
    Console.WriteLine("6. Exit");
    option = Console.ReadLine();

    switch (option)
    {
        case "1":
        case "2":
        case "3":
        case "4":
            PlayMathGame(option, random, history);
            break;

        case "5":
            if (history.Count > 0)
            {
                Console.WriteLine("Game History:");
                foreach (var item in history)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No games have been played yet.");
            }
            break;

        case "6":
            Console.WriteLine("Exiting the game. Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid option selected.");
            break;
    }
} while (option != "6");

static void PlayMathGame(string option, Random random, List<string> history)
{
    int firstNum = random.Next(1, 9);
    int secondNum = random.Next(1, 9);
    int correctAnswer = 0;
    string operation = "";
    string question = "";

    switch (option)
    {
        case "1": // Addition
            operation = "+";
            correctAnswer = firstNum + secondNum;
            question = $"{firstNum} + {secondNum}";
            break;

        case "2": // Subtraction
            operation = "-";
            correctAnswer = firstNum - secondNum;
            question = $"{firstNum} - {secondNum}";
            break;

        case "3": // Multiplication
            operation = "*";
            correctAnswer = firstNum * secondNum;
            question = $"{firstNum} * {secondNum}";
            break;

        case "4": // Division
            operation = "/";
            while (firstNum % secondNum != 0) // No non integer results
            {
                secondNum = random.Next(1, 9);
            }
            correctAnswer = firstNum / secondNum;
            question = $"{firstNum} / {secondNum}";
            break;
    }

    Console.WriteLine($"Solve: {question}");
    int userAnswer = int.Parse(Console.ReadLine());

    if (userAnswer == correctAnswer)
    {
        Console.WriteLine("Correct!");
        history.Add($"{question} = {userAnswer} (Correct) - Game: {operation}");
    }
    else
    {
        Console.WriteLine($"Incorrect. The correct answer was {correctAnswer}.");
        history.Add($"{question} = {userAnswer} (Incorrect, correct answer was {correctAnswer} - Game: {operation})");
    }
}