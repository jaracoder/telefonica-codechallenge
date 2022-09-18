// jaracoder

using System.Collections.Generic;
using System.IO;

namespace TelefonicaCodeChallenge
{
    public class CatchThemAll
    {
        static List<string> pokemons;
        static string map;
        
        static void Main()
        {
            var fileName = "submitInput.txt";
            var lines = File.ReadAllLines(fileName);
            var totalCases = int.Parse(lines[0]);
            var results = new string[totalCases];
            int count = 1;

            for (int i = 0; i < totalCases; i++) 
            {
                string[] aux = lines[count++].Split(' ');

                int totalPokemons = int.Parse(aux[0]);
                int rows = int.Parse(aux[1]);

                pokemons = new List<string>();
                for (int c = 0; c < totalPokemons; c++) 
                {
                    pokemons.Add(lines[count++]);
                }

                map = string.Empty; 
                for (int row = 0; row < rows; row++)
                {
                    map += lines[count++].Replace(" ", "");
                }

                CatchPokemons();

                results[i] = $"Case #{i + 1}: {map}";
            }

            File.WriteAllLines("submitOutput.txt", results);
        }

        static void CatchPokemons()
        {
            for (int numPokemon = 0; numPokemon < pokemons.Count; numPokemon++)
            {
                string pokemon = pokemons[numPokemon];

                if (map.Contains(pokemon))
                {
                    map = map.Replace(pokemon, string.Empty);

                    if (numPokemon > 0)
                        numPokemon = -1;
                }

                var mapReverse = string.Empty;
                for (int z = map.Length - 1; z >= 0; z--)
                {
                    mapReverse += map[z];
                }

                if (mapReverse.Contains(pokemon))
                {
                    mapReverse = mapReverse.Replace(pokemon, "");

                    map = string.Empty;
                    for (int z = mapReverse.Length - 1; z >= 0; z--)
                    {
                        map += mapReverse[z];
                    }

                    if (numPokemon > 0)
                        numPokemon = -1;
                }
            }
        }
    }
}
