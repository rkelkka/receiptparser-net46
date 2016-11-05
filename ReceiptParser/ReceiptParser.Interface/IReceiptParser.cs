using ReceiptParser.ReceiptParser.Interface.Input;

namespace ReceiptParser.ReceiptParser.Interface
{
    interface IReceiptParser
    {
        /// <summary>
        /// Attempt to parse a receipt.
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns>T</returns>
        /// <exception cref="InvalidArgumentException">when input data is unsupported format</exception>
        T ParseReceipt<T>(ReceiptDataIn receipt);
    }
}
