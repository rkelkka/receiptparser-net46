using System;

namespace ReceiptParser.ReceiptParser.Interface
{
    public class ReceiptParseException : Exception
    {
        private readonly string _value;
        private readonly string _context;

        public ReceiptParseException(string message, string context)
            : this(message, null, context, null)
        {
        }


        public ReceiptParseException(string message, string value, string context)
            : this(message, value, context, null)
        {
        }

        public ReceiptParseException(string message, string value, string context, Exception inner)
            : base(message, inner)
        {
            _value = value;
            _context = context;
        }

        public override String Message
        {
            get
            {
                return base.Message + String.Format(
                    "; Value: {0}. Context: {1}", _value, _context);
            }
        }
    }
}