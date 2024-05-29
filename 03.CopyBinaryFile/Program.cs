namespace CopyBinaryFile
{
    using System;
    using System.Xml;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            //File.Copy(inputFilePath, outputFilePath);

            using FileStream reader = new FileStream(inputFilePath, FileMode.Open);
            using FileStream write = new FileStream(outputFilePath, FileMode.Create);

            byte[] buffer = new byte[1024];
            while (true)
            {
                int readbytes = reader.Read(buffer, 0, buffer.Length);

                if (readbytes == 0) 
                {
                    break;
                }

                write.Write(buffer, 0, readbytes);
            }
        }
    }
}

