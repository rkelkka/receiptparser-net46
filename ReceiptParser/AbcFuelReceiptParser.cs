using System;
using ReceiptParser.ReceiptParser.Interface;
using ReceiptParser.ReceiptParser.Interface.Input;
using ReceiptParser.ReceiptParser.Interface.Output;

namespace ReceiptParser
{
    public class AbcFuelReceiptParser : IReceiptParser<FuelReceiptData>
    {
        public FuelReceiptData ParseReceipt(ReceiptDataIn receipt)
        {
            throw new NotImplementedException();
        }
    }
}
