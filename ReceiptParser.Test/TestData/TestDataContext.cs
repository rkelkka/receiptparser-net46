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
        internal TestData Prisma_Kaleva_Tampere_2016_10_19 { get; private set; }

        static string AssemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        const string TestDataDir = "TestData";

        internal static TestDataContext Load()
        {
            var ctx = new TestDataContext();

            var receipt = File.ReadAllText(GetPath("Prisma_Kaleva_Tampere_2016-10-19.txt"), Encoding.UTF8);

            ctx.Prisma_Kaleva_Tampere_2016_10_19 = new TestData(receipt,
                ReceiptCategory.Fuel, "ABC PRISMA KALEVA", 31.05f, 44.68f, "2016-10-19");//dd.mm.yy is the date format in the receipt

            return ctx;
            
        }

        private static string GetPath(string testDataFile)
        {
            return string.Format("{0}\\{1}\\{2}",
                AssemblyDir, TestDataDir, testDataFile);
        }
    }
}
