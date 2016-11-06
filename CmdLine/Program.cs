using System.IO;
using System.Text;
using System;
using ParserFacade;

namespace CmdLine
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentException("Specify file name");
            }

            var fileName = args[0];
            byte[] bytes = File.ReadAllBytes(fileName);

            Parser parser = new Parser();
            var result = ProcessBytes(parser, bytes);

            var rawText = result.PdfText.RawText;
            SaveText(rawText, fileName);
            Console.WriteLine(rawText);

            var formattedResult = result.ReceiptData.AsFormattedString();
            SaveText(formattedResult, "parsedData_" + fileName);
            Console.WriteLine(formattedResult);
        }

        private static ParseResult ProcessBytes(Parser parser, byte[] bytes)
        {
            return parser.ProcessBytes(bytes);
        }

        private static void SaveText(string text, string fileName)
        {
            var outputFile = Path.ChangeExtension(fileName, ".txt");
            File.WriteAllText(outputFile, text, Encoding.UTF8);
        }

    }
}
