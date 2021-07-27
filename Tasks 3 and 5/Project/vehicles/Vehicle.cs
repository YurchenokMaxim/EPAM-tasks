using System;
using System.Xml.Serialization;

namespace CarPark
{
    [Serializable]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Motocycle))]
    [XmlInclude(typeof(Truck))]
    public abstract class Vehicle : IInformation
    {
        private double maxSpeed;

        private Transmission transmissionType;

        private Engine engine;

        private Chassis chassis;

        public double MaxSpeed
        {
            get
            {
                return maxSpeed;
            }

            set
            {
                if (value <= 0)
                {
                    throw new Exception("The property Max Speed can't be less than or equal to 0");
                }
                else
                {
                    maxSpeed = value;
                }
            }
        }

        public Transmission TransmissionType
        {
            get
            {
                return transmissionType;
            }

            set
            {
                if (value == null)
                {
                    throw new Exception("The property TransmissionType in Vehicle is null");
                }
                else
                {
                    transmissionType = value;
                }
            }
        }

        public Chassis Chassis
        {
            get
            {
                return chassis;
            }

            set
            {
                if (value == null)
                {
                    throw new Exception("The property Chassis in Vehicle is null");
                }
                else
                {
                    chassis = value;
                }
            }
        }

        public Engine Engine
        {
            get
            {
                return engine;
            }

            set
            {
                if (value == null)
                {
                    throw new Exception("The property Engine in Vehicle is null");
                }
                else
                {
                    engine = value;
                }
            }
        }

        protected Vehicle(double speed, Transmission transmission, Chassis chassis, Engine engine)
        {
            TransmissionType = transmission;
            MaxSpeed = speed;
            Chassis = chassis;
            Engine = engine;
        }

        public Vehicle() { }

        public virtual string GetFullInfo()
        {
            return Engine.GetFullInfo() + TransmissionType.GetFullInfo() + Chassis.GetFullInfo()
            + " Max Speed: " + MaxSpeed.ToString();
        }
    }
}