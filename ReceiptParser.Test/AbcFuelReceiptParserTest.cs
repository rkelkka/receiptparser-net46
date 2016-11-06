using NUnit.Framework;
using ReceiptParser.ReceiptParser.Interface.Input;
using ReceiptParser.ReceiptParser.Interface.Output;
using System;

namespace ReceiptParser.Test
{
    [TestFixture]
    class AbcFuelReceiptParserTest
    {
        private TestDataContext _testCtx;
        private AbcFuelReceiptParser _parser;

        [SetUp]
        public void SetUp()
        {
            _testCtx = TestDataContext.Load();
            _parser = new AbcFuelReceiptParser();
        }

        [Test]
        public void KnownReceipt_ShouldParse_StationName()
        {
            var testData = _testCtx.Fuel_Abc_Prisma_Kaleva_Tampere_2016_10_19;
            var input = new ReceiptDataIn(testData.Receipt);

            var actual = _parser.ParseReceipt(input);

            Assert.AreEqual(testData.StationName, actual.Station.Name);

        }

        [Test]
        public void KnownReceipt_ShouldParse_Qty()
        {
            var testData = _testCtx.Fuel_Abc_Prisma_Kaleva_Tampere_2016_10_19;
            var input = new ReceiptDataIn(_testCtx.Fuel_Abc_Prisma_Kaleva_Tampere_2016_10_19.Receipt);

            var actual = _parser.ParseReceipt(input);

            Assert.AreEqual(testData.Qty, actual.Litres);
        }


        [Test]
        public void KnownReceipt_ShouldParse_Price()
        {
            var testData = _testCtx.Fuel_Abc_Prisma_Kaleva_Tampere_2016_10_19;
            var input = new ReceiptDataIn(_testCtx.Fuel_Abc_Prisma_Kaleva_Tampere_2016_10_19.Receipt);

            var actual = _parser.ParseReceipt(input);

            Assert.AreEqual(testData.Price, actual.Eur);
        }


        [Test]
        public void KnownReceipt_ShouldParse_Date()
        {
            var testData = _testCtx.Fuel_Abc_Prisma_Kaleva_Tampere_2016_10_19;
            var input = new ReceiptDataIn(_testCtx.Fuel_Abc_Prisma_Kaleva_Tampere_2016_10_19.Receipt);

            var actual = _parser.ParseReceipt(input);

            Assert.AreEqual(testData.Date, actual.Date);

        }

        [Test]
        public void NotSupportedReceipt_ShouldThrow()
        {
            var input = new ReceiptDataIn(_testCtx.Fuel_Abc_Prisma_Kaleva_Tampere_2016_10_19.Receipt);

            var actual = _parser.ParseReceipt(input);

            Assert.AreEqual(ReceiptFormat.Fuel_Abc, actual);

        }

        [Test]
        public void NullReceipt_ShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(() => _parser.ParseReceipt(null));
        }

        [Test]
        public void EmptyReceipt_ShouldThrow()
        {
            var emptyReceipt = new ReceiptDataIn("");
            Assert.Throws<ArgumentException>(() => _parser.ParseReceipt(emptyReceipt));
        }
    }
}
