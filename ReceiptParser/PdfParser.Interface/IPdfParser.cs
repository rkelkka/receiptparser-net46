using ReceiptParser.PdfParser.Interface.Input;
using ReceiptParser.PdfParser.Interface.Output;

namespace ReceiptParser.PdfParser.Interface
{
    interface IPdfParser
    {
        /// <summary>
        /// Attempt to parse pdf input as text.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="InvalidArgumentException">when input data is unsupported format</exception>
        PdfTextOut Parse(PdfIn input);
    }
}
