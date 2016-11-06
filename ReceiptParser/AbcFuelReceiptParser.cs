using System;
using ReceiptParser.ReceiptParser.Interface;
using ReceiptParser.ReceiptParser.Interface.Input;
using ReceiptParser.ReceiptParser.Interface.Output;
using ReceiptParser.Unit;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ReceiptParser
{
    /// <summary>
    /// A naive implementation relying on exactly known format.
    /// </summary>
    public class AbcFuelReceiptParser : IReceiptParser<FuelReceiptData>
    {
        private Regex _utfNonBreakingSpace = new Regex(@"\u00A0", RegexOptions.Compiled);

        private const int STATION_NAME_LINE_IX = 0;
        private const int DATE_LINE_IX = 8;
        private const int QUANTITY_AND_PRICE_LINE_IX = 10;
        
        private Regex _dateRegex = new Regex(@"\d+\.\d+\.\d+", RegexOptions.Compiled);
        private const string DATETIME_FORMAT = "dd.MM.yy";

        private Regex _decimalDigitRegex = new Regex(@"\d+\,\d+", RegexOptions.Compiled);
        private const int QTY_MATCH_IX = 0;

        //Results in 3  groups: 1) "11,11 EUR" 2) "11,11" 3) "EUR"
        private Regex _priceRegex = new Regex(@"(\d+\,\d+)(\sEUR)", RegexOptions.Compiled);
        private const int PRICE_AMOUNT_GROUP_IX = 1;



        public FuelReceiptData ParseReceipt(ReceiptDataIn receipt)
        {
            if (receipt == null)
            {
                throw new ArgumentNullException("receipt");
            }
            if (string.IsNullOrWhiteSpace(receipt.RawText))
            {
                throw new ArgumentException("receipt.RawText is null or white space");
            }

            var rawTextNormalizedSpaces = _utfNonBreakingSpace.Replace(receipt.RawText, " ");

            string[] lines = rawTextNormalizedSpaces.Split('\n');

            if(lines.Length < 11)
            {
                throw new ArgumentException("receipt content incomplete or unrecognized format");
            }

            FuelReceiptData data = ParseReceiptLines(lines);

            return data;           

        }

        /*
         * The minimum set of data that can be used to parse required info, 
         * starting from the beginning of the receipt.
         * 
         * ABC PRISMA KALEVA    

           KORTTIAUTOMAATTI             

           Pirkanmaan Osuuskauppa  Y­Tun:536307­0964   
           Rieväkatu 6, 33540 Tampere                
           010­7670140                               

           REF.  251762E  19.10.16 19:07:09  AUT: 14 

           2 BE 95 E10  31,05   1,4390    44,68 EUR
        */
        private FuelReceiptData ParseReceiptLines(string[] lines)
        {
            var stationLine = lines[STATION_NAME_LINE_IX].Trim();
            var station = ExtractStation(stationLine);

            var dateLine = lines[DATE_LINE_IX].Trim();
            var date = ExtractDate(dateLine);

            var qtyPriceLine = lines[QUANTITY_AND_PRICE_LINE_IX].Trim();
            var quantity = ExtractQuantity(qtyPriceLine);

            var price = ExtractPrice(qtyPriceLine);

            return new FuelReceiptData(station, quantity, price, date);
        }

        private Station ExtractStation(string stationLine)
        {
            return new Station(stationLine);
        }

        private DateTime ExtractDate(string dateLine)
        {
            var match = _dateRegex.Match(dateLine);
            if(match.Success)
            {
                return DateTime.ParseExact(match.Value, DATETIME_FORMAT,
                    CultureInfo.InvariantCulture);
            }
            throw new ReceiptParseException("invalid date format", dateLine);
        }

        private Quantity ExtractQuantity(string qtyPriceLine)
        {
            var matches = _decimalDigitRegex.Matches(qtyPriceLine);
            if(matches.Count > QTY_MATCH_IX)
            {
                var qtyMatch = matches[QTY_MATCH_IX];
                if (qtyMatch.Success)
                {

                    return new Quantity(ParseWithComma(qtyMatch.Value));
                }
            }
            throw new ReceiptParseException("invalid quantity format", qtyPriceLine);
        }


        private Currency ExtractPrice(string qtyPriceLine)
        {
            var match = _priceRegex.Match(qtyPriceLine);
            if (match.Success)
            {
                var priceValue = match.Groups[PRICE_AMOUNT_GROUP_IX];
                return new Currency(ParseWithComma(priceValue.Value));
            }
            throw new ReceiptParseException("invalid price format", qtyPriceLine);
        }

        private decimal ParseWithComma(string value)
        {
            var numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "," };
            return decimal.Parse(value, numberFormatInfo);
        }
    }
}
