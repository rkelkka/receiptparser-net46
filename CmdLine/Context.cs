using ReceiptParser.PdfParser.Interface;

namespace CmdLine
{
    internal class Context
    {
        public readonly IPdfParser PdfParser;

        internal Context(IPdfParser pdfParser)
        {
            PdfParser = pdfParser;
        }

        public static Context Create()
        {
            var pdfParser = new PdfParser.Impl.PdfParser();
            var ctx = new Context(pdfParser);
            return ctx;

        }
    }
}
