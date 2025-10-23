using System;

namespace OrderingSystem.Exceptions
{
    public class InvalidInput : Exception
    {
        public InvalidInput(string txt) : base(txt) { }
    }
}
