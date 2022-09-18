// jaracoder

using System.IO;
using System.Text.RegularExpressions;

namespace TelefonicaCodeChallenge
{
    public class NightHunter
    {
        static void Main()
        {
            var fileName = "submitInput.txt";
            var lines = File.ReadAllLines(fileName);
            var totalCases = int.Parse(lines[0]);
            var results = new string[totalCases];

            for (int i = 0; i < totalCases; i++) 
            {
                string[] aux = lines[i + 1].Split('|');
                string[] words = aux[0].Split('-');
                string[] values = ParserValues(aux[1]).Split(',');
                string word = GetBestWord(words[0], words[1], values);

                results[i] += $"Case #{i + 1}: {word}";
            }

            File.WriteAllLines("submitOutput.txt", results);
        }


        static string GetBestWord(string wordLeft, string wordRight, string[] values)
        {
            double valueWordLeft = 0f, valueWordRight = 0f;

            foreach (string value in values)
            {
                string[] letterTotal = value.Split('=');

                char letter = char.Parse(letterTotal[0].Trim());
                double total = 0f;

                if (letterTotal[1].Contains("/"))
                {
                    var division = letterTotal[1].Split('/');
                    total += double.Parse(division[0]) / double.Parse(division[1]);
                }
                else
                {
                    total += double.Parse(letterTotal[1]);
                }

                valueWordLeft += GetSumLettersWord(wordLeft, letter, total);
                valueWordRight += GetSumLettersWord(wordRight, letter, total);
            }

            if (valueWordLeft > valueWordRight)
                return wordLeft;
            else if (valueWordRight > valueWordLeft)
                return wordRight;
            else
                return "-";
        }


        static string ParserValues(string strValues)
        {
            string values = strValues.Replace(": ", "=")
                                     .Replace("', ", "=");

            return Regex.Replace(values, @"(\s+|'|\(|\)|\[|\]|{|})", "");
        }


        static double GetSumLettersWord(string word, char letter, double value)
        {
            double sum = 0f;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == letter)
                    sum += value;
            }

            return sum;
        }
    }
}
