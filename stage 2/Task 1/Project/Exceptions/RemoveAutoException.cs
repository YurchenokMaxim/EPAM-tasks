using System;

namespace CarPark
{
    public class RemoveAutoException : Exception
    {
        public RemoveAutoException(string message) : base(message) { }
    }
}
