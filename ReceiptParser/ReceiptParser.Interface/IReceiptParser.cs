using ReceiptParser.ReceiptParser.Interface.Input;
using System;

namespace ReceiptParser.ReceiptParser.Interface
{
    public interface IReceiptParser<T>
    {
        /// <summary>
        /// Attempt to parse a receipt.
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns>T</returns>
        /// /// <exception cref="ArgumentNullException">when input data is null</exception>
        /// <exception cref="ArgumentException">when input data is empty or unrecognized format</exception>
        /// <exception cref="ReceiptParseException">when input data cannot be parsed</exception>
        T ParseReceipt(ReceiptDataIn receipt);
    }
}
