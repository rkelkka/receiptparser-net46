using ReceiptParser;
using ReceiptParser.PdfParser.Interface;
using ReceiptParser.ReceiptParser.Interface;
using ReceiptParser.ReceiptParser.Interface.Output;

namespace CmdLine
{
    internal class Context
    {
        public readonly IPdfParser PdfParser;
        public readonly IReceiptFormatParser ReceiptFormatParser;
        public readonly IReceiptParser<FuelReceiptData> FuelReceiptParser;

        internal Context(IPdfParser pdfParser, IReceiptFormatParser formatParser, IReceiptParser<FuelReceiptData> fuelReceiptParser)
        {
            PdfParser = pdfParser;
            ReceiptFormatParser = formatParser;
            FuelReceiptParser = fuelReceiptParser;
        }

        public static Context Create()
        {
            var pdfParser = new PdfParser.Impl.PdfParser();
            var formatParser = new ReceiptFormatParser();
            var abcFuelReceiptParser = new AbcFuelReceiptParser();
            var ctx = new Context(pdfParser, formatParser, abcFuelReceiptParser);
            return ctx;

        }
    }
}
