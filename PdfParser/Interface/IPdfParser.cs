using PdfParser.Interface.Output;
using PdfParser.Interface.Input;

namespace ReceiptParser.PdfParser.Interface
{
    public interface IPdfParser
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
