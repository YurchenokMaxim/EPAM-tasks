using System;

namespace CarPark
{
    public class UpdateAutoException : Exception
    {
        public UpdateAutoException(string message) : base(message) { }
    }
}
