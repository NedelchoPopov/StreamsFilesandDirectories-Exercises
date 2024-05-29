namespace LineNumbers
{
    using System;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            var allLines = File.ReadAllLines(inputFilePath);

            StringBuilder stringBuilder = new StringBuilder();

            int counter = 0;

            foreach (var line in allLines)
            {
                int countOfLetters = line.Count(char.IsLetter);

                int countOfPunctuation = line.Count(char.IsPunctuation);


                stringBuilder.AppendLine($"Line {counter++}: {line} ({countOfLetters})({countOfPunctuation})");
            }
            File.WriteAllText(outputFilePath, stringBuilder.ToString().TrimEnd());
        }
    }
}
