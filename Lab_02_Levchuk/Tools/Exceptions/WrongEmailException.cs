using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_02_Levchuk.Tools.Exceptions
{
    class WrongEmailException : Exception
    {
        public WrongEmailException() { }

        public WrongEmailException(string message)
            : base(message) { }

        public WrongEmailException(string message, Exception inner)
            : base(message, inner) { }
    }
}
