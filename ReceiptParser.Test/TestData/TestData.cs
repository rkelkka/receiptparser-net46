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
        public readonly ReceiptCategory Category;
        public readonly string StationName;
        public readonly float Qty;
        public readonly float Price;
        public readonly string Date;

        internal TestData(string receipt, ReceiptCategory cat, string station, float qty, float price, string date)
        {
            Receipt = receipt;
            Category = cat;
            StationName = station;
            Qty = qty;
            Price = price;
            Date = date;
        }
    }
}
