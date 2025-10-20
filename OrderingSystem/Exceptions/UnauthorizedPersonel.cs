using System;

namespace OrderingSystem.Exceptions
{
    public class UnauthorizedPersonel : Exception
    {
        public UnauthorizedPersonel(string txt) : base(txt) { }
    }
}
