using ReceiptParser.Unit;
using System;

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
        public readonly DateTime Date;

        public FuelReceiptData(Station station, Quantity litres, Currency eur, DateTime date)
        {
            Station = station;
            Litres = litres;
            Eur = eur;
            Date = date;
        }

        public string AsFormattedString()
        {
            return string.Format(
                "Station: {0}\n" + 
                "Quantity: {1}\n" + 
                "Price: {2}\n" + 
                "Date: {3}\n",
                Station.Name, Litres.Value, Eur.Value, Date);
        }

    }
}
