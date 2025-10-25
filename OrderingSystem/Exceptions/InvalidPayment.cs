using System;

namespace OrderingSystem.Exceptions
{
    public class InvalidPayment : Exception
    {
        public InvalidPayment(string tx) : base(tx) { }
    }
}
