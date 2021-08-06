using System;

namespace CarPark
{
    public class GetAutoByParameterException : Exception
    {
        public GetAutoByParameterException(string message) : base(message) { }
    }
}
