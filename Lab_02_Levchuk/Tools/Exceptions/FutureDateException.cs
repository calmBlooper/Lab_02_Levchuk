using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_02_Levchuk.Tools.Exceptions
{
    class FutureDateException : Exception
    {
        public FutureDateException() { }

        public FutureDateException(string message)
            : base(message) { }

        public FutureDateException(string message, Exception inner)
            : base(message, inner) { }
    }
}
