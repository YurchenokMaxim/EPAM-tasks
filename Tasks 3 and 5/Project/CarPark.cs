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
        public List<Vehicle> Park = new List<Vehicle>();

        public CarPark() { }

        /// <summary>
        /// Creates a passing object within an object of this class.
        /// </summary>
        /// <param name="transport"></param>
        public void AddNewVehicle(Vehicle transport)
        {
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
