using System;

namespace OrderingSystem.Exceptions
{
    public class DuplicateException : Exception
    {

        public DuplicateException(string ts) : base(ts)
        {

        }
    }
}
