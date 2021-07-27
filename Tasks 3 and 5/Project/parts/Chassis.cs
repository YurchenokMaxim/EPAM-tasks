using System;

namespace CarPark
{
    public class Chassis : IInformation
    {
        private int number;

        private int numberOfWheels;

        private double permisiibleLoad;

        public int NumberOfWheels
        {
            get
            {
                return numberOfWheels;
            }

            set
            {
                if (value < 1)
                {
                    throw new Exception("The property Number of wheels can't be less than 1");
                }
                else
                {
                    numberOfWheels = value;
                }
            }
        }

        public double PermissibleLoad
        {
            get
            {
                return permisiibleLoad;
            }

            set
            {
                if (value <= 0)
                {
                    throw new Exception("The property Permissible Load can't be less than or equal to 0");
                }
                else
                {
                    permisiibleLoad = value;
                }
            }
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                if (value <= 0)
                {
                    throw new Exception("The property Number can't be less than less than or equal to 0");
                }
                else
                {
                    number = value;
                }
            }
        }

        public Chassis(int numberOfWheels, double permissibleLoad, int number)
        {
            Number = number;
            NumberOfWheels = numberOfWheels;
            PermissibleLoad = permissibleLoad;
        }

        public Chassis() { }

        public string GetFullInfo()
        {
            return " CHASSIS number of wheels: " + NumberOfWheels.ToString() + " permissible load: " + PermissibleLoad.ToString() + " Number: " + Number.ToString();
        }
    }
}