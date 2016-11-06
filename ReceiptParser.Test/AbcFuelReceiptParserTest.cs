using NUnit.Framework;
using ReceiptParser.ReceiptParser.Interface;
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

        private const decimal _epsilon = 0.1m;

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

            AssertWithEpsilon(testData.Qty.Value, actual.Litres.Value, _epsilon);
        }

        [Test]
        public void KnownReceipt_ShouldParse_Price()
        {
            var testData = _testCtx.Fuel_Abc_Prisma_Kaleva_Tampere_2016_10_19;
            var input = new ReceiptDataIn(_testCtx.Fuel_Abc_Prisma_Kaleva_Tampere_2016_10_19.Receipt);

            var actual = _parser.ParseReceipt(input);

            AssertWithEpsilon(testData.Price.Value, actual.Eur.Value, _epsilon);
        }

        private void AssertWithEpsilon(decimal a, decimal b, decimal e = 0.0001m)
        {
            Assert.That(Math.Abs(a - b), Is.LessThan(e));
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
        public void NotSupportedReceipt_Similar_ShouldThrow()
        {
            var input = new ReceiptDataIn(_testCtx.Unknown_Prisma_Kaleva_Tampere_2016_10_21.Receipt);

            Assert.Throws<ReceiptParseException>(() => _parser.ParseReceipt(input));
        }

        [Test]
        public void NotSupportedReceipt_CompletelyDifferent_ShouldThrow()
        {
            var input = new ReceiptDataIn(_testCtx.Unknown_Smarket_Kaukajarvi_2016_10_19.Receipt);

            Assert.Throws<ReceiptParseException>(() => _parser.ParseReceipt(input));
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
