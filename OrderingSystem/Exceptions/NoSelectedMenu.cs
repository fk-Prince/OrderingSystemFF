using System;

namespace OrderingSystem.Exceptions
{
    public class NoSelectedMenu : Exception
    {
        public NoSelectedMenu()
        {
        }

        public NoSelectedMenu(string message) : base(message)
        {
        }
    }
}
