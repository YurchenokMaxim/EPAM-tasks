using System;

namespace CarPark
{

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            Transmission transmission = new Transmission("Type1", 1, "Manufacture1");
            Chassis chassis = new Chassis(4, 10, 1);
            Engine engine = new Engine(5, 5, "Type1", "Serial Number");

            Car car = new Car("1500", 180, transmission, chassis, engine);
            Bus bus = new Bus(50, 70, transmission, chassis, engine);
            Motocycle motocycle = new Motocycle("Type1", 200, transmission, chassis, engine);
            Truck truck = new Truck("5 t.", 110, transmission, chassis, engine);

            CarPark firstPark = new CarPark();
            firstPark.AddNewVehicle(bus);
            firstPark.AddNewVehicle(motocycle);
            firstPark.AddNewVehicle(truck);
            firstPark.AddNewVehicle(car);
            string result = firstPark.GetFullInfo();
            firstPark.SaveAllCarParkToXML("All Vehicles");
            firstPark.SaveToXMLWithEngineVolumeMore("Filtered by engine power vehicles", 1.5);
            firstPark.SaveVehiclesGroupByTransmissionTypeToXML("Vehicles which group by transmission type");
            firstPark.SaveSomeInformationAboutBusesAndTrucksToXML("Some information about buses and trucks");
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}

