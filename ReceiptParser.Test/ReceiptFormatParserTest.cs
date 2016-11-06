using NUnit.Framework;
using ReceiptParser.ReceiptParser.Interface.Input;
using ReceiptParser.ReceiptParser.Interface.Output;
using System;

namespace ReceiptParser.Test
{
    [TestFixture]
    class ReceiptFormatParserTest
    {
        private TestDataContext _testCtx;
        private ReceiptFormatParser _parser;

        [SetUp]
        public void SetUp()
        {
            _testCtx = TestDataContext.Load();
            _parser = new ReceiptFormatParser();
        }

        [Test]
        public void KnownReceipt_ShouldParseFormat()
        {
            var input = new ReceiptDataIn(_testCtx.Fuel_Abc_Prisma_Kaleva_Tampere_2016_10_19.Receipt);

            var actual = _parser.ParseReceiptFormat(input);

            Assert.AreEqual(ReceiptFormat.Fuel_Abc, actual);

        }

        [Test]
        public void UnknownReceipt_ShouldParseFormat()
        {
            var input = new ReceiptDataIn(_testCtx.Unknown_Prisma_Kaleva_Tampere_2016_10_21.Receipt);

            var actual = _parser.ParseReceiptFormat(input);

            Assert.AreEqual(ReceiptFormat.Unknown, actual);

        }

        [Test]
        public void UnknownReceiptTwo_ShouldParseFormat()
        {
            var input = new ReceiptDataIn(_testCtx.Unknown_Smarket_Kaukajarvi_2016_10_19.Receipt);

            var actual = _parser.ParseReceiptFormat(input);

            Assert.AreEqual(ReceiptFormat.Unknown, actual);

        }

        [Test]
        public void NullReceipt_ShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(() => _parser.ParseReceiptFormat(null));
        }

        [Test]
        public void EmptyReceipt_ShouldThrow()
        {
            var emptyReceipt = new ReceiptDataIn("");
            Assert.Throws<ArgumentException>(() => _parser.ParseReceiptFormat(emptyReceipt));
        }
    }
}
