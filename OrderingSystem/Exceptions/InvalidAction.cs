using System;

namespace OrderingSystem.Exceptions
{
    public class InvalidAction : Exception
    {
        public InvalidAction(string txt) : base(txt) { }
    }
}
