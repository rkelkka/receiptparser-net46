﻿using ReceiptParser.ReceiptParser.Interface.Input;
using ReceiptParser.ReceiptParser.Interface.Output;

namespace ReceiptParser.ReceiptParser.Interface
{
    public interface IReceiptFormatParser
    {

        /// <summary>
        /// Attempt to figure out what kind of receipt it is.
        /// </summary>
        /// <param name="recipt"></param>
        /// <returns></returns>
        ReceiptFormat ParseReceiptFormat(ReceiptDataIn receipt);
    }
}
