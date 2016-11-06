using NUnit.Framework;
using ReceiptParser.ReceiptParser.Interface.Input;
using ReceiptParser.ReceiptParser.Interface.Output;

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
        public void ValidReceipt_ShouldParseFormat()
        {
            var input = new ReceiptDataIn(_testCtx.Prisma_Kaleva_Tampere_2016_10_19.Receipt);

            var actual = _parser.ParseReceiptFormat(input);

            Assert.AreEqual(ReceiptFormat.Fuel_Abc, actual);

        }
    }
}
