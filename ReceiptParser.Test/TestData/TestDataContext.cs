using ReceiptParser.ReceiptParser.Interface.Output;
using System.IO;
using System.Reflection;
using System.Text;
using System;

namespace ReceiptParser.Test
{
    /// <summary>
    /// Load test data from files and hard code expected results.
    /// </summary>
    internal class TestDataContext
    {
        internal TestData Fuel_Abc_Prisma_Kaleva_Tampere_2016_10_19 { get; private set; }
        internal TestData Unknown_Prisma_Kaleva_Tampere_2016_10_21 { get; private set; }
        internal TestData Unknown_Smarket_Kaukajarvi_2016_10_19 { get; private set; }

        static string AssemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        const string TestDataDir = "TestData";

        internal static TestDataContext Load()
        {
            var ctx = new TestDataContext();

            var receipt = File.ReadAllText(GetPath("Prisma_Kaleva_Tampere_2016-10-19.txt"), Encoding.UTF8);
            ctx.Fuel_Abc_Prisma_Kaleva_Tampere_2016_10_19 = new TestData(receipt,
                ReceiptFormat.Fuel_Abc, "ABC PRISMA KALEVA", 31.05f, 44.68f, "2016-10-19");//dd.mm.yy is the date format in the receipt

            receipt = File.ReadAllText(GetPath("Prisma_Kaleva_Tampere_2016-10-21.txt"), Encoding.UTF8);
            ctx.Unknown_Prisma_Kaleva_Tampere_2016_10_21 = new TestData(receipt, ReceiptFormat.Unknown);


            receipt = File.ReadAllText(GetPath("S-market_Kaukajärvi_Tampere_2016-11-01.txt"), Encoding.UTF8);
            ctx.Unknown_Smarket_Kaukajarvi_2016_10_19 = new TestData(receipt, ReceiptFormat.Unknown);

            return ctx;
            
        }

        private static string GetPath(string testDataFile)
        {
            return Path.Combine(AssemblyDir, TestDataDir, testDataFile);
        }
    }
}
