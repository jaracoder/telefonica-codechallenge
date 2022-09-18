// jaracoder

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TelefonicaCodeChallenge
{
    public class MusicalScales
    {
        static void Main()
        {
            var fileName = "submitInput.txt";
            var lines = File.ReadAllLines(fileName);
            var totalCases = int.Parse(lines[0]);
            var results = new string[totalCases];
            var count = 1;

            for (int i = 0; i < totalCases; i++) 
            {
                string rootScale = lines[count++];
                string musicalScale = lines[count++];
                string notes = string.Empty;

                var scale = musicalScales[musicalScale];
                
                if (rootScale.Length > 1)
                {
                    notes = scale.Where(x => x.Substring(0, 2) == rootScale).FirstOrDefault();
                }
                else
                {
                    notes = scale.Where(x => x.Substring(0, 1) == rootScale && 
                                             x.Substring(1, 1) != "#" && 
                                             x.Substring(1, 1) != "b").FirstOrDefault();
                }

                results[i] += $"Case #{i + 1}: {notes}";
            }

            File.WriteAllLines("submitOutput.txt", results);
        }

        static Dictionary<string, List<string>> musicalScales = new Dictionary<string, List<string>>() {
            // Jónico o Mayor
            { "TTsTTTs" ,  new List<string>(){ "CDEFGABC", "C#D#E#F#G#A#B#C#", "DbEbFGbAbBbCDb", "DEF#GABC#D", "D#E#F#G#A#B#C#D#", "EbFGAbBbCDEb", "EF#G#ABC#D#E", "FGABbCDEF", "F#G#A#BC#D#E#F#", "GbAbBbCbDbEbFGb", "GABCDEF#G", "G#A#B#C#D#E#F#G#", "AbBbCDbEbFGAb", "ABC#DEF#G#A", "A#B#C#D#E#F#G#A#", "BbCDEbFGABb", "BC#D#EF#G#A#B"} },
            // Dorico
            { "TsTTTsT" ,  new List<string>(){ "CDEbFGABbC", "C#D#EF#G#A#BC#", "DbEbFbGbAbBbCbDb", "DEFGABCD", "D#E#F#G#A#B#C#D#", "EbFGbAbBbCDbEb", "EF#GABC#DE", "FGAbBbCDEbF", "F#G#ABC#D#EF#", "GbAbBbCbDbEbFbGb", "GABbCDEFG", "G#A#BC#D#E#F#G#", "AbBbCbDbEbFGbAb", "ABCDEF#GA", "A#B#C#D#E#F#G#A#", "BbCDbEbFGAbBb", "BC#DEF#G#AB" } },
            // Frigio
            { "sTTTsTT" ,  new List<string>(){ "CDbEbFGAbBbC", "C#DEF#G#ABC#", "DbEbFbGbAbBbCbDb", "DEbFGABbCD", "D#EF#G#A#BC#D#", "EbFbGbAbBbCbDbEb", "EFGABCDE", "FGbAbBbCDbEbF", "F#GABC#DEF#", "GbAbBbCbDbEbFbGb", "GAbBbCDEbFG", "G#ABC#D#EF#G#", "AbBbCbDbEbFbGbAb", "ABbCDEFGA", "A#BC#D#E#F#G#A#", "BbCbDbEbFGbAbBb", "BCDEF#GAB" } },
            // Lidio
            { "TTTsTTs" ,  new List<string>(){ "CDEF#GABC", "C#D#E#F#G#A#B#C#", "DbEbFGAbBbCDb", "DEF#G#ABC#D", "D#E#F#G#A#B#C#D#", "EbFGABbCDEb", "EF#G#A#BC#D#E", "FGABCDEF", "F#G#A#B#C#D#E#F#", "GbAbBbCDbEbFGb", "GABC#DEF#G", "G#A#B#C#D#E#F#G#", "AbBbCDEbFGAb", "ABC#D#EF#G#A", "A#B#C#D#E#F#G#A#", "BbCDEFGABb", "BC#D#E#F#G#A#B"} },
            // Mixolidio
            { "TTsTTsT" ,  new List<string>(){ "CDEFGABbC", "C#D#E#F#G#A#BC#", "DbEbFGbAbBbCbDb", "DEF#GABCD", "D#E#F#G#A#B#C#D#", "EbFGAbBbCDbEb", "EF#G#ABC#DE", "FGABbCDEbF", "F#G#A#BC#D#EF#", "GbAbBbCbDbEbFbGb", "GABCDEFG", "G#A#B#C#D#E#F#G#", "AbBbCDbEbFGbAb", "ABC#DEF#GA", "A#B#C#D#E#F#G#A#", "BbCDEbFGAbBb", "BC#D#EF#G#AB" } },
            // Eolico
            { "TsTTsTT" , new List<string>() { "CDEbFGAbBbC", "C#D#EF#G#ABC#", "DbEbFbGbAbBbCbDb", "DEFGABbCD", "D#E#F#G#A#BC#D#", "EbFGbAbBbCbDbEb", "EF#GABCDE", "FGAbBbCDbEbF", "F#G#ABC#DEF#", "GbAbBbCbDbEbFbGb", "GABbCDEbFG", "G#A#BC#D#EF#G#", "AbBbCbDbEbFbGbAb", "ABCDEFGA", "A#B#C#D#E#F#G#A#","BbCDbEbFGbAbBb", "BC#DEF#GAB"} },
            // Locrio
            { "sTTsTTT" ,  new List<string>(){ "CDbEbFGbAbBbC", "C#DEF#GABC#", "DbEbFbGbAbBbCbDb", "DEbFGAbBbCD", "D#EF#G#ABC#D#", "EbFbGbAbBbCbDbEb", "EFGABbCDE", "FGbAbBbCbDbEbF", "F#GABCDEF#", "GbAbBbCbDbEbFbGb", "GAbBbCDbEbFG", "G#ABC#DEF#G#", "AbBbCbDbEbFbGbAb", "ABbCDEbFGA", "A#BC#D#EF#G#A#", "BbCbDbEbFbGbAbBb", "BCDEFGAB"} },
        };
    }
}
