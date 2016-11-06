using PdfParser.Interface.Output;
using ReceiptParser.ReceiptParser.Interface.Output;

namespace ParserFacade
{
    public class ParseResult
    {
        public readonly PdfTextOut PdfText;
        public readonly FuelReceiptData ReceiptData;

        public ParseResult(PdfTextOut pdfAsText, FuelReceiptData receiptData)
        {
            PdfText = pdfAsText;
            ReceiptData = receiptData;
        }
    }
}
