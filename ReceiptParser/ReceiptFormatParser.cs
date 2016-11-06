using System;
using ReceiptParser.ReceiptParser.Interface;
using ReceiptParser.ReceiptParser.Interface.Input;
using ReceiptParser.ReceiptParser.Interface.Output;

namespace ReceiptParser
{
    public class ReceiptFormatParser : IReceiptFormatParser
    {
        public ReceiptFormat ParseReceiptFormat(ReceiptDataIn receipt)
        {
            if(receipt == null)
            {
                throw new ArgumentNullException("receipt");
            }
            if(string.IsNullOrWhiteSpace(receipt.RawText))
            {
                throw new ArgumentException("receipt.RawText is null or white space");
            }

            var rawText = receipt.RawText;
            string[] lines = rawText.Split('\n');

            if (lines.Length >= 3)
            {
                if (lines[0].StartsWith("ABC") && 
                    lines[2].StartsWith("KORTTIAUTOMAATTI"))
                {
                    return ReceiptFormat.Fuel_Abc;
                }
            }

            return ReceiptFormat.Unknown;

        }
    }
}
