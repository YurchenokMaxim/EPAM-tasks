using System;

namespace CarPark
{
    public class InitializationException : Exception
    {
        public InitializationException(string message) : base(message) { }
    }
}
