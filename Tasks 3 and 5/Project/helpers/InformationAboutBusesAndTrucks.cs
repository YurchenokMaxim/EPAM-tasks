using System;

namespace CarPark
{
    [Serializable]
    public class InformationAboutBusesAndTrucks
    {
        private string typeOfEngine;

        private string serialNumber;

        private double power;

        public string TypeOfEngine
        {
            get
            {
                return typeOfEngine;
            }

            set
            {
                if (value == null)
                {
                    throw new Exception("The property TypeOfEngine is null");
                }
                else
                {
                    typeOfEngine = value;
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
                if (value == null)
                {
                    throw new Exception("The property SerialNumber is null");
                }
                else
                {
                    serialNumber = value;
                }
            }
        }

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
                    throw new Exception("The property Power is null");
                }
                else
                {
                    power = value;
                }
            }
        }

        public InformationAboutBusesAndTrucks() { }

        public InformationAboutBusesAndTrucks(string typeOfEngine, string serialNumber, double power)
        {
            TypeOfEngine = typeOfEngine;
            SerialNumber = serialNumber;
            Power = power;
        }
    }
}