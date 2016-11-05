using ReceiptParser.ReceiptParser.Interface.Input;
using ReceiptParser.ReceiptParser.Interface.Output;

namespace ReceiptParser.ReceiptParser.Interface
{
    interface IReceiptCategoryParser
    {

        /// <summary>
        /// Attempt to figure out what kind of receipt it is.
        /// </summary>
        /// <param name="recipt"></param>
        /// <returns></returns>
        ReceiptCategory ParseReceiptCategory(ReceiptDataIn fuelReceipt);
    }
}
