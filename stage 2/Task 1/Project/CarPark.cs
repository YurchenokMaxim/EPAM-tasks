using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace CarPark
{
    [Serializable]
    [XmlInclude(typeof(Vehicle))]
    public class CarPark : IInformation
    {
        private List<Vehicle> Park = new List<Vehicle>();

        public CarPark() { }

        /// <summary>
        /// This method returns count of vehicles
        /// </summary>
        /// <returns></returns>
        public int GetCountOfVehicles()
        {
            return Park.Count();
        }

        /// <summary>
        /// This method returns list of selected by parameter vehicles.
        /// </summary>
        /// <param name of parameter="parameter"></param>
        /// <param value of parameter="value"></param>
        /// <returns></returns>
        public List<Vehicle> GatAutoByParameter(string parameter, string value)
        {
            List<Vehicle> selectedVehicles = new List<Vehicle>();
            switch (parameter.ToLower())
            {
                case "maxspeed":
                    selectedVehicles = (from transport in Park
                                        where transport.MaxSpeed.ToString().Equals(value)
                                        select transport).ToList();
                    break;
                case "transmissiontype":
                    selectedVehicles = (from transport in Park
                                        where transport.TransmissionType.Type.ToString().Equals(value)
                                        select transport).ToList();
                    break;
                case "numberofgears":
                    selectedVehicles = (from transport in Park
                                        where transport.TransmissionType.NumberOfGears.ToString().Equals(value)
                                        select transport).ToList();
                    break;
                case "manufacture":
                    selectedVehicles = (from transport in Park
                                        where transport.TransmissionType.Manufacture.ToString().Equals(value)
                                        select transport).ToList();
                    break;
                case "power":
                    selectedVehicles = (from transport in Park
                                        where transport.Engine.Power.ToString().Equals(value)
                                        select transport).ToList();
                    break;
                case "volume":
                    selectedVehicles = (from transport in Park
                                        where transport.Engine.Volume.ToString().Equals(value)
                                        select transport).ToList();
                    break;
                case "enginetype":
                    selectedVehicles = (from transport in Park
                                        where transport.Engine.Type.ToString().Equals(value)
                                        select transport).ToList();
                    break;
                case "serialnumber":
                    selectedVehicles = (from transport in Park
                                        where transport.Engine.SerialNumber.ToString().Equals(value)
                                        select transport).ToList();
                    break;
                case "number":
                    selectedVehicles = (from transport in Park
                                        where transport.Chassis.Number.ToString().Equals(value)
                                        select transport).ToList();
                    break;
                case "numberofwheels":
                    selectedVehicles = (from transport in Park
                                        where transport.Chassis.NumberOfWheels.ToString().Equals(value)
                                        select transport).ToList();
                    break;
                case "permisiibleload":
                    selectedVehicles = (from transport in Park
                                        where transport.Chassis.PermissibleLoad.ToString().Equals(value)
                                        select transport).ToList();
                    break;
                default:
                    throw new GetAutoByParameterException("This parameter does not exist");
            }
            return selectedVehicles;
        }

        /// <summary>
        /// This method deletes an element by index.
        /// </summary>
        /// <param index of element that will delete="index"></param>
        public void RemoveAuto(int index)
        {
            if (index < 0 || index >= Park.Count)
            {
                throw new RemoveAutoException("Attempt to delete a non-existent vehicle");
            }
            Park.RemoveAt(index);
        }

        /// <summary>
        /// This method replaces the old vehicle with a new one.
        /// </summary>
        /// <param index of vehicle that will update="index"></param>
        /// <param new vehicle in this position="vehicle"></param>
        public void UpdateAuto(int index, Vehicle vehicle)
        {
            if (index < 0 || index >= Park.Count)
            {
                throw new UpdateAutoException("Attempt to replace a non-existent vehicle");
            }
            Park[index] = vehicle;
        }

        /// <summary>
        /// Creates a passing object within an object of this class.
        /// </summary>
        /// <param name="transport"></param>
        public void AddNewVehicle(Vehicle transport)
        {
            if (transport == null || transport.Chassis == null || transport.Engine == null || transport.TransmissionType == null)
            {
                throw new AddException("The vehicle that is being added does not exist");
            }
            Park.Add(transport);
        }

        /// <summary>
        /// Returns the vehicle at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Vehicle we need</returns>
        public IInformation GetElement(int index)
        {
            if (index > Park.Count || index < 0)
            {
                throw new Exception("Index outside of bounds of array");
            }
            return Park[index];
        }

        public string GetFullInfo()
        {
            string result = "";
            foreach (IInformation index in Park)
            {
                result += index.GetFullInfo();
            }
            return result;
        }

        /// <summary>
        /// This wethod save all vehicles that object of class CarPark exist.
        /// </summary>
        /// <param name="filename"></param>
        public void SaveAllCarParkToXML(string filename)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Vehicle>), new Type[] { typeof(Car), typeof(Bus), typeof(Truck), typeof(Motocycle) });
            using (FileStream fs = new FileStream($"{filename}.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Park);
            }
        }

        /// <summary>
        /// This method save in XML file information about vehicles by method.
        /// </summary>
        /// <param Name of XML file ="filename"></param>
        /// <param Name of method that will use="method"></param>
        public void SaveToXMLWithEngineVolumeMore(string filename, double EngineVolume)
        {
            List<Vehicle> result = new List<Vehicle>();
            result = (from transport in Park
                      where transport.Engine.Volume > EngineVolume
                      select transport).ToList();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Vehicle>), new Type[] { typeof(Car), typeof(Bus), typeof(Truck), typeof(Motocycle) });
            using (FileStream fs = new FileStream($"{filename}.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, result);
            }
        }

        /// <summary>
        /// This method stores complete information about all vehicles, grouped by transmission type.
        /// </summary>
        /// <param Name of the file="filename"></param>
        public void SaveVehiclesGroupByTransmissionTypeToXML(string filename)
        {
            var result = (from transport in Park
                          group transport by transport.TransmissionType into g
                          select new VehiclesGroupByTransmissionVehicles
                          (
                              g.Key,
                              (from transport in g select transport).ToList()
                          )).ToList();

            XmlSerializer formatter = new XmlSerializer(typeof(List<VehiclesGroupByTransmissionVehicles>), new Type[] { typeof(Transmission), typeof(Vehicle) });
            using (FileStream fs = new FileStream($"{filename}.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, result);
            }
        }

        /// <summary>
        /// This method return type of engine, serial number and engine power of buses and trucks.
        /// </summary>
        /// <param name of the file="filename"></param>
        public void SaveSomeInformationAboutBusesAndTrucksToXML(string filename)
        {
            var result = (from transport in Park
                          where transport.GetType() == typeof(Bus) || transport.GetType() == typeof(Truck)
                          select new InformationAboutBusesAndTrucks
                          (
                              transport.Engine.Type,
                              transport.Engine.SerialNumber,
                              transport.Engine.Power
                          )).ToList();

            XmlSerializer formatter = new XmlSerializer(typeof(List<InformationAboutBusesAndTrucks>));
            using (FileStream fs = new FileStream($"{filename}.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, result);
            }
        }
    }
}
