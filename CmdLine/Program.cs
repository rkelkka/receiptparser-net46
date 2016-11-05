using PdfParser.Interface.Input;
using System.IO;
using System.Text;
using System;
using ReceiptParser.PdfParser.Interface;

namespace CmdLine
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = Context.Create();

            if (args.Length == 0)
            {
                throw new ArgumentException("Specify file name");
            }

            var fileName = args[0];
            ProcessFile(ctx, fileName);
        }

        private static void ProcessFile(Context ctx, string fileName)
        {
            byte[] bytes = File.ReadAllBytes(fileName);
            var text = ParseBytes(ctx.PdfParser, bytes);
            var outputFile = Path.ChangeExtension(fileName, ".txt");
            File.WriteAllText(outputFile, text, Encoding.UTF8);
        }

        private static string ParseBytes(IPdfParser pdfParser, byte[] bytes)
        {
            var input = new PdfIn(bytes);
            var output = pdfParser.Parse(input);

            return output.RawText;
        }
    }
}
