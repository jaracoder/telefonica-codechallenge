// jaracoder

using System;
using System.IO;
using System.Text;

namespace TelefonicaCodeChallenge
{
    public class Invictus
    {
        static void Main()
        {
            var fileName = "Invictus.txt";
        //    var lines = File.ReadAllLines(fileName, System.Text.Encoding.UTF8);
            var text = string.Empty;

            foreach (EncodingInfo ei in Encoding.GetEncodings())
            {
                Encoding encoding = ei.GetEncoding();
                var lines = File.ReadAllLines(fileName, encoding);

                File.WriteAllLines($"5_Invictus/Encodings/{ei.Name}invictusOutput.txt", lines, encoding);
            }
        }
    }
}
