using System;

namespace CarPark
{
    public class Transmission : IInformation
    {
        private string type;

        private int numberOfGears;

        private string manufacture;

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("The Type of transmisssion is null");
                }
                else
                {
                    type = value;
                }
            }
        }

        public int NumberOfGears
        {
            get
            {
                return numberOfGears;
            }

            set
            {
                if (value <= 0)
                {
                    throw new Exception("The property Number Of Gears can't be less than or equal to 0");
                }
                else
                {
                    numberOfGears = value;
                }
            }
        }

        public string Manufacture
        {
            get
            {
                return manufacture;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("The property Manufacture is null");
                }
                else
                {
                    manufacture = value;
                }
            }
        }

        public Transmission(string type, int numberOfGears, string manufacture)
        {
            Type = type;
            NumberOfGears = numberOfGears;
            Manufacture = manufacture;
        }

        public Transmission() { }

        public string GetFullInfo()
        {
            return " TRANSMISSION type: " + Type + " number of gears: " + NumberOfGears.ToString() + " manufacture: " + Manufacture;
        }
    }
}