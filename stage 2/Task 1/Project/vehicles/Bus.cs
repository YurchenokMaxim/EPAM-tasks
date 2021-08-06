using System;

namespace CarPark
{
    [Serializable]
    public class Bus : Vehicle
    {
        private int numberOfPassengerSeats;

        public int NumberOfPassengerSeats
        {
            get
            {
                return numberOfPassengerSeats;
            }

            set
            {
                if (value <= 0)
                {
                    throw new InitializationException("The property Number Of Passenger Seats can't be less than or equal to 0");
                }
                else
                {
                    numberOfPassengerSeats = value;
                }
            }
        }

        public Bus(int number, double speed, Transmission transmission, Chassis chassis, Engine engine) : base(speed, transmission, chassis, engine)
        {
            NumberOfPassengerSeats = number;
        }

        public Bus() { }

        public override string GetFullInfo()
        {
            return " BUS " + "Number of passanger seats: " + NumberOfPassengerSeats.ToString() + base.GetFullInfo();
        }
    }
}
