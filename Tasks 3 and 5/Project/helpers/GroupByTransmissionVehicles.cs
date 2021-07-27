using System;
using System.Collections.Generic;

namespace CarPark
{
    [Serializable]
    public class VehiclesGroupByTransmissionVehicles
    {
        private Transmission transmission;

        private List<Vehicle> vehicles;

        private string name;

        public Transmission Transmission
        {
            get
            {
                return transmission;
            }

            set
            {
                if (value == null)
                {
                    throw new Exception("The property Transmission is null");
                }
                else
                {
                    transmission = value;
                }
            }
        }

        public List<Vehicle> Vehicles
        {
            get
            {
                return vehicles;
            }

            set
            {
                if (value == null)
                {
                    throw new Exception("The property Vehicles is null");
                }
                else
                {
                    vehicles = value;
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value == null)
                {
                    throw new Exception("The property Name is null");
                }
                else
                {
                    name = value;
                }
            }
        }

        public VehiclesGroupByTransmissionVehicles() { }

        public VehiclesGroupByTransmissionVehicles(Transmission transmission, List<Vehicle> vehicles)
        {
            Transmission = transmission;
            Vehicles = vehicles;
        }
    }
}