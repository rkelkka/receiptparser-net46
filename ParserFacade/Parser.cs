using PdfParser.Interface.Input;
using PdfParser.Interface.Output;
using ReceiptParser.PdfParser.Interface;
using ReceiptParser.ReceiptParser.Interface.Input;
using ReceiptParser.ReceiptParser.Interface.Output;
using System;

namespace ParserFacade
{
    public class Parser
    {
        private readonly Context _ctx;

        public Parser()
        {
            _ctx = Context.Create();
        }

        public ParseResult ProcessBytes(byte[] bytes)
        {
            var pdfAsText = ParseBytesAsPdf(_ctx, bytes);

            var receiptInput = new ReceiptDataIn(pdfAsText.RawText);
            var format = ParseReceiptFormat(_ctx, receiptInput);
            var receiptData = ParseReceipt(_ctx, format, receiptInput);
            return new ParseResult(pdfAsText, receiptData);
        }

        private static PdfTextOut ParseBytesAsPdf(Context ctx, byte[] bytes)
        {

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

        private static PdfTextOut ParseBytes(IPdfParser pdfParser, byte[] bytes)
        {
            var input = new PdfIn(bytes);
            var output = pdfParser.Parse(input);
            return output;
        }
    }
}
