using System;

namespace CarPark
{
    [Serializable]
    public class Car : Vehicle
    {
        private string weight;

        public string Weight
        {
            get
            {
                return weight;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("The property Weight of Car");
                }
                else
                {
                    weight = value;
                }
            }
        }

        public Car(string weight, double speed, Transmission transmission, Chassis chassis, Engine engine) : base(speed, transmission, chassis, engine)
        {
            Weight = weight;
        }

        public Car() { }

        public override string GetFullInfo()
        {
            return " CAR " + "Weight: " + Weight.ToString() + base.GetFullInfo();
        }
    }
}
