using System;

namespace CarPark
{
    public class Engine : IInformation
    {
        private double power;

        private double volume;

        private string type;

        private string serialNumber;

        public double Power
        {
            get
            {
                return power;
            }

            set
            {
                if (value <= double.Epsilon)
                {
                    throw new Exception("The property Power can't be less than or equal to 0");
                }
                else
                {
                    power = value;
                }
            }
        }

        public double Volume
        {
            get
            {
                return volume;
            }

            set
            {
                if (value <= double.Epsilon)
                {
                    throw new Exception("The property Volume can't be less than or equal to 0");
                }
                else
                {
                    volume = value;
                }
            }
        }

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
                    throw new Exception("The property Type of Engine is null");
                }
                else
                {
                    type = value;
                }
            }
        }

        public string SerialNumber
        {
            get
            {
                return serialNumber;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("The property Serial Number of Engine is null");
                }
                else
                {
                    serialNumber = value;
                }
            }
        }

        public Engine(double power, double volume, string type, string serialNumber)
        {
            Power = power;
            Volume = volume;
            Type = type;
            SerialNumber = serialNumber;
        }

        public Engine() { }

        public string GetFullInfo()
        {
            return " ENGINE power: " + Power.ToString() + " volume: " + Volume.ToString() + " type: " + Type + " Serial Number: " + SerialNumber;
        }
    }
}