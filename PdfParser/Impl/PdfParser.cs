using PdfParser.Interface.Input;
using PdfParser.Interface.Output;
using ReceiptParser.PdfParser.Interface;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace PdfParser.Impl
{
    class PdfParser : IPdfParser
    {
        public PdfTextOut Parse(PdfIn input)
        {
            var reader = new PdfReader(input.Data);
            var numberOfPages = reader.NumberOfPages;

            var sb = new StringBuilder();
            for (var currentPageIndex = 1; currentPageIndex <= numberOfPages; currentPageIndex++)
            {
                sb.Append(PdfTextExtractor.GetTextFromPage(reader, currentPageIndex));
            }
            
            return new PdfTextOut(sb.ToString());
        }
    }
}
