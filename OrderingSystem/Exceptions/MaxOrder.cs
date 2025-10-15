using System;

namespace OrderingSystem.Exceptions
{
    public class MaxOrder : Exception
    {
        public MaxOrder()
        {
        }

        public MaxOrder(string message) : base(message)
        {
        }
    }
}
