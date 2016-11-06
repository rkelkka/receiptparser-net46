using ReceiptParser.ReceiptParser.Interface.Output;
using System;

namespace ReceiptParser.Test
{
    /// <summary>
    /// Bind test data with excpected results.
    /// </summary>
    internal class TestData
    {
        public readonly string Receipt;

        //Expected parse result
        public readonly ReceiptFormat Format;
        public readonly string StationName;
        public readonly decimal? Qty;
        public readonly decimal? Price;
        public readonly DateTime? Date;

        internal TestData(string receipt, ReceiptFormat format = ReceiptFormat.Unknown, 
            string station = null, decimal? qty = null, decimal? price = null, DateTime? date = null)
        {
            Receipt = receipt;
            Format = format;
            StationName = station;
            Qty = qty;
            Price = price;
            Date = date;
        }
    }
}
