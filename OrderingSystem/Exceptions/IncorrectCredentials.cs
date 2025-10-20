using System;

namespace OrderingSystem.Exceptions
{
    public class IncorrectCredentials : Exception
    {
        public IncorrectCredentials(string txt) : base(txt)
        {
        }
    }
}
