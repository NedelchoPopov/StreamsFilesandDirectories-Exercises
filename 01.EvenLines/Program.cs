namespace EvenLines
{
    using System;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using var reader = new StreamReader(inputFilePath);

            int counter = 0;

            StringBuilder sb = new StringBuilder();

            while (true)
            {



                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                if (counter % 2 == 0)
                {


                    string[] words = line.Split()
                        .Reverse()
                        .ToArray();

                    string text = string.Join(" ", words);

                    sb.AppendLine(text);


                }

                counter++;
            }

            char[] specialSybols = { '-', ',', '.', '!', '?' };

            foreach (char c in specialSybols)
            {
                sb = sb.Replace(c, '@');
            }

            return sb.ToString().TrimEnd();
        }

    }
}

