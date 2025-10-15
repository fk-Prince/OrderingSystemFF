using System;

namespace OrderingSystem.Exceptions
{
    public class OutOfOrder : Exception
    {

        public OutOfOrder(string message) : base(message)
        {
        }
    }
}
