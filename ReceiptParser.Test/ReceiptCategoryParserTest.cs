using NUnit.Framework;
using ReceiptParser.ReceiptParser.Interface.Input;
using ReceiptParser.ReceiptParser.Interface.Output;

namespace ReceiptParser.Test
{
    [TestFixture]
    class ReceiptCategoryParserTest
    {
        private TestDataContext _testCtx;
        private ReceiptCategoryParser _parser;

        [SetUp]
        public void SetUp()
        {
            _testCtx = TestDataContext.Load();
            _parser = new ReceiptCategoryParser();
        }

        [Test]
        public void ValidReceipt_ShouldParseCategory()
        {
            var input = new ReceiptDataIn(_testCtx.Prisma_Kaleva_Tampere_2016_10_19.Receipt);

            var actual = _parser.ParseReceiptCategory(input);

            Assert.AreEqual(ReceiptCategory.Fuel, actual);

        }
    }
}
