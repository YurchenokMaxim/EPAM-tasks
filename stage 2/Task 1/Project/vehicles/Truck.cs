using System;

namespace CarPark
{
    [Serializable]
    public class Truck : Vehicle
    {
        private string carrying;

        public string Carrying
        {
            get
            {
                return carrying;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new InitializationException("The property Carrying of Truck");
                }
                else
                {
                    carrying = value;
                }
            }
        }

        public Truck(string carrying, double speed, Transmission transmission, Chassis chassis, Engine engine) : base(speed, transmission, chassis, engine)
        {
            Carrying = carrying;
        }

        public Truck() { }

        public override string GetFullInfo()
        {
            return " TRUCK " + "Carrying: " + Carrying + base.GetFullInfo();
        }

    }
}
