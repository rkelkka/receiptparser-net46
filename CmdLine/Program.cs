using PdfParser.Interface.Input;
using System.IO;
using System.Text;
using System;
using ReceiptParser.PdfParser.Interface;
using ReceiptParser.ReceiptParser.Interface.Output;
using PdfParser.Interface.Output;
using ReceiptParser.ReceiptParser.Interface.Input;

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

            var pdfAsText = ParseFile(ctx, fileName);
            Console.WriteLine(pdfAsText.RawText);
            SaveText(pdfAsText.RawText, fileName);

            var receiptInput = new ReceiptDataIn(pdfAsText.RawText);
            var format = ParseReceiptFormat(ctx, receiptInput);
            var receiptData = ParseReceipt(ctx, format, receiptInput);
            
            var formattedData = receiptData.AsFormattedString();
            Console.WriteLine(formattedData);
            SaveText(formattedData, "parsedData_" + fileName);
        }

        private static PdfTextOut ParseFile(Context ctx, string fileName)
        {
            byte[] bytes = File.ReadAllBytes(fileName);
            var text = ParseBytes(ctx.PdfParser, bytes);
            return text;
        }

        private static ReceiptFormat ParseReceiptFormat(Context ctx, ReceiptDataIn receiptInput)
        {
            return ctx.ReceiptFormatParser.ParseReceiptFormat(receiptInput);
        }


        private static FuelReceiptData ParseReceipt(Context ctx, ReceiptFormat format, ReceiptDataIn receiptInput)
        {
            switch (format)
            {
                case ReceiptFormat.Fuel_Abc:
                    return ctx.FuelReceiptParser.ParseReceipt(receiptInput);
            default:
                    throw new Exception(string.Format(
                        "Unsupported receipt format. Input:\n{0}", receiptInput.RawText));
            }
        }

        private static void SaveText(string text, string fileName)
        {
            var outputFile = Path.ChangeExtension(fileName, ".txt");
            File.WriteAllText(outputFile, text, Encoding.UTF8);
        }

        private static PdfTextOut ParseBytes(IPdfParser pdfParser, byte[] bytes)
        {
            var input = new PdfIn(bytes);
            var output = pdfParser.Parse(input);
            return output;
        }
    }
}
