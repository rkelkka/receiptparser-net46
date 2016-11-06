using ReceiptParser.ReceiptParser.Interface.Output;

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
        public readonly float? Qty;
        public readonly float? Price;
        public readonly string Date;

        internal TestData(string receipt, ReceiptFormat format = ReceiptFormat.Unknown, 
            string station = null, float? qty = null, float? price = null, string date = null)
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
