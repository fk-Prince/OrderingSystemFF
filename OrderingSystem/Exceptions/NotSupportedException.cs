using System;

namespace OrderingSystem.Exceptions
{
    public class NotSupportedException : Exception
    {

        public NotSupportedException(string txt) : base(txt) { }
    }
}
