using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_02_Levchuk.Tools.Exceptions
{
    
    class ArentYouDeadException : Exception
    {
        public ArentYouDeadException() { }

        public ArentYouDeadException(string message)
            : base(message) { }

        public ArentYouDeadException(string message, Exception inner)
            : base(message, inner) { }
    }
}
