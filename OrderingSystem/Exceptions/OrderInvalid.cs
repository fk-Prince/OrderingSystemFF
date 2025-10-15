using System;

namespace OrderingSystem.Exceptions
{
    public class OrderInvalid : Exception
    {
        public OrderInvalid(string message) : base(message)
        {
        }
    }
}
