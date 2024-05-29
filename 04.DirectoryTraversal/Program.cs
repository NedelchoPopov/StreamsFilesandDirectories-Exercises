namespace DirectoryTraversal
{
    using System;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath);

            Dictionary<string, Dictionary<string, double>> filesInfo
                = new Dictionary<string, Dictionary<string, double>>();
            foreach (string file in files)
            {

                string fileName = Path.GetFileName(file);

                string extension = Path.GetExtension(file);

                double size = new FileInfo(file).Length / 1024d;

                if (!filesInfo.ContainsKey(extension))
                {
                    filesInfo.Add(extension, new Dictionary<string, double>());
                }

                filesInfo[extension].Add(fileName, size);
            }

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var file in filesInfo
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {

                stringBuilder.AppendLine(file.Key);

                foreach (var fileInfo in file.Value.OrderBy(x => x.Key))
                {
                    stringBuilder.AppendLine($"--{fileInfo.Key} - {Math.Round(fileInfo.Value, 3)}.kb");
                }
            }
            return stringBuilder.ToString()
                .TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(path, textContent);
        }
    }
}
