using System;

namespace CarPark
{

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            try
            {
                Transmission transmission = new Transmission("Type1", 1, "Manufacture1");
                Chassis chassis = new Chassis(4, 10, 1);
                Engine engine = new Engine(5, 5, "Type1", "Serial Number");

                Bus bus = new Bus(50, 70, transmission, chassis, engine);
                Car car = new Car("1500", 180, transmission, chassis, engine);
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

                string parameter = "maxSpeed";
                string value = "70";
                var selectedVehicle = firstPark.GatAutoByParameter(parameter, value);
                Console.ReadKey();
            }
            catch (AddException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (GetAutoByParameterException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (InitializationException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (RemoveAutoException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (UpdateAutoException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        }
    }

