// jaracoder

using System.IO;

namespace TelefonicaCodeChallenge
{
    public class RollDice
    {
        static void Main()
        {
            var fileName = "submitInput.txt";
            var lines = File.ReadAllLines(fileName);
            var totalCases = int.Parse(lines[0]);
            var results = new string[totalCases];

            for (int i = 0; i < totalCases; i++) 
            {
                string[] dices = lines[i + 1].Split(':');
                int sum = int.Parse(dices[0]) + int.Parse(dices[1]);

                if (sum == 12)
                {
                    results[i] += $"Case #{i + 1}: -";
                }
                else 
                {
                    results[i] += $"Case #{i + 1}: {sum + 1}";
                }
            }

            File.WriteAllLines("submitOutput.txt", results);
        }
    }
}
