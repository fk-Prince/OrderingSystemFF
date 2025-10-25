using System;

namespace OrderingSystem.Exceptions
{
    public class InsuffiecientAmount : Exception
    {

        public InsuffiecientAmount(string message) : base(message)
        {
        }
    }
}
