using System;

namespace CrossCutting.Core.Guards
{
    public class GuardValidationException : Exception
    {
        public GuardValidationException(string message): base(message)
        {

        }
    }
}
