using System;

namespace CarPark
{
    public class AddException : Exception
    {
        public AddException(string message) : base(message) { }
    }
}
