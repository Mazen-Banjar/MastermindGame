
class Program
{
    static void Main(String[] args) //Finding if args contain any of the following "-c" or "-t" 
    {
        string secretCode = null;
        int maxAttempts = 10;

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-c" && i + 1 < args.Length)
            {
                secretCode = args[i + 1]; // example "-c 1234" args[1] = -c --> args[1 + 1] = 1234
            }

            if (args[i] == "-t" && i + 1 < args.Length)
            {
                if (int.TryParse(args[i + 1], out int attempts))
                {
                    maxAttempts = attempts;
                }
            }
        }

        if (!string.IsNullOrEmpty(secretCode))
        {
            if (!(secretCode.Length == 4 && secretCode.All(c => c >= '0' && c <= '8') && secretCode.Distinct().Count() == 4))
            {
                secretCode = Generate();
            }

        } else {
            secretCode = Generate();
        }
        MastermindGame game = new MastermindGame(secretCode, maxAttempts);
        game.Play();
    }
    
    public static string Generate()
    {
        Random rand = new Random();
        return string.Concat("012345678".OrderBy(x => rand.Next()).Take(4));
    }

}

public class MastermindGame
{
    private string secretCode;
    private int maxAttempts;

    public MastermindGame(string secretCode, int maxAttempts)
    {
        this.secretCode = secretCode;
        this.maxAttempts = maxAttempts;

    }

    public void Play()
    {
        Console.WriteLine("Can you break the code? \nPlease enter a valid guess.");
        int roundCounter = 0;
        while (roundCounter < maxAttempts)
        {
            Console.WriteLine($"---\nRound {roundCounter}");
            Console.Write(">");
            string input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("\nEOF received. Exiting.");
                break;
            }
            else if (!IsValidCode(input))
            {
                Console.WriteLine("Wrong input please try again.");
                continue;
            }
            else if (input == secretCode)
            {
                Console.WriteLine("Congrats you did it!.");
                break;
            }
            else
            {
                roundCounter++;
                int misPlayed = CountMisplaced(input);
                int wellPlaced = CountWellPlaced(input);
                Console.WriteLine($"Well placed pieces: {wellPlaced}");
                Console.WriteLine($"Misplaced pieces: {misPlayed}");

            }
            
            if (roundCounter == maxAttempts)
                Console.WriteLine($"Game over! The secret code was: {secretCode}");
        }

    }
    
    static bool IsValidCode(string code)
    {
        return code.Length == 4 && code.All(c => char.IsDigit(c) && c >= '0' && c <= '8') && code.Distinct().Count() == 4;
    }
    
    private int CountWellPlaced(string guess)
    {
        return guess.Where((c, i) => c == secretCode[i]).Count();
    }

    private int CountMisplaced(string guess)
    {
        int misplaced = 0;
        for (int i = 0; i < guess.Length; i++)
        {
            if (guess[i] != secretCode[i] && secretCode.Contains(guess[i]))
            misplaced++;
        }
        return misplaced;
    }
    
}




