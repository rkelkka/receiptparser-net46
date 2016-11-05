using ReceiptParser.Unit;

namespace ReceiptParser.ReceiptParser.Interface.Output
{
    /// <summary>
    /// Container for fueling data extracted from a receipt.
    /// </summary>
    public class FuelReceiptData
    {
        public readonly Station Station;
        public readonly Quantity Litres;
        public readonly Currency Eur;

        public FuelReceiptData(Station station, Quantity litres, Currency eur)
        {
            Station = station;
            Litres = litres;
            Eur = eur;
        }

    }
}
