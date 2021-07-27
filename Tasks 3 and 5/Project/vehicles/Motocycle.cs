using System;

namespace CarPark
{
    [Serializable]
    public class Motocycle : Vehicle
    {
        private string type;

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
                    throw new Exception("The property Type of Motocycle is null");
                }
                else
                {
                    type = value;
                }
            }
        }

        public Motocycle(string type, double speed, Transmission transmission, Chassis chassis, Engine engine) : base(speed, transmission, chassis, engine)
        {
            Type = type;
        }

        public Motocycle() { }

        public override string GetFullInfo()
        {
            return " MOTOCYCLE " + "Type: " + Type.ToString() + base.GetFullInfo();
        }
    }
}
