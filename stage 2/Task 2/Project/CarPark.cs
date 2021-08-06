using System;
using System.Collections.Generic;
using System.Linq;

namespace Task7
{
    public class CarPark
    {
        private static CarPark carPark;

        public List<Vehicle> vehicles;

        private CarPark(List<Vehicle> vehicles)
        {
            this.vehicles = vehicles;
        }

        /// <summary>
        /// This method return Car Park in this project or create them.
        /// </summary>
        /// <param this vehicles will go to the parameter if you create Car Park="vehicles"></param>
        /// <returns></returns>
        public static CarPark GetCarPark()
        {
            if (carPark == null)
            {
                string Command = "";
                Console.WriteLine("You are in the mode of adding vehicles");
                Console.WriteLine("to add, enter 'add' and then the parameters in the following sequence: Car Make, Car Model, Count, Unit Cost");
                Console.WriteLine("to leave this mode enter 'continue'");
                List<Vehicle> vehicles = new List<Vehicle>();

                Vehicle vehicle;
                string carMake;
                string carModel;
                int count;
                double unitCost;

                while (Command != "continue")
                {
                    if (Command == "add")
                    {
                        carMake = Console.ReadLine();
                        carModel = Console.ReadLine();
                        count = Convert.ToInt32(Console.ReadLine());
                        unitCost = Convert.ToDouble(Console.ReadLine());
                        vehicle = new Vehicle(carMake, carModel, count, unitCost);
                        vehicles.Add(vehicle);
                        Console.WriteLine("Enter next command");
                    }
                    Command = Console.ReadLine();
                    if (Command != "add" || Command != "continue") 
                    {
                        Console.WriteLine("This command is wrong");
                    }
                }
                carPark = new CarPark(vehicles);
            }
            return carPark;
        }

        public static CarPark GetCarPark(List<Vehicle> vehicles)
        {
            if (carPark == null)
            {
                carPark = new CarPark(vehicles);
            }
            return carPark;
        }

        /// <summary>
        /// This method returns count of vehicle types in car park.
        /// </summary>
        public string GetCountOfTypes()
        {
            var result = (from transport in vehicles
                          group transport by transport.CarMake into g
                          select new { CarMake = g.Key, SelectedVehicles = (from transport in g select transport).ToList() }).ToList();
            return "Count of car makes: " + result.Count.ToString();
        }

        /// <summary>
        /// This method returns count of all vehicles in car park.
        /// </summary>
        public string GetCountOfCars()
        {
            double result = 0;
            foreach (Vehicle transport in vehicles)
            {
                result += transport.Count;
            }
            return "Count of cars: " + result.ToString();
        }

        /// <summary>
        /// This method returns average price of all cars in car park.
        /// </summary>
        public string GetAveragePrice()
        {
            double cost = 0;
            double number = 0;
            foreach (Vehicle transport in vehicles)
            {
                number += transport.Count;
                cost += transport.UnitCost * transport.Count;
            }
            return "Average price: " + (cost / number).ToString();
        }

        /// <summary>
        /// This method returns average price of cars in car park that have a certain brand.
        /// </summary>
        /// <param brand of cars that will find="type"></param>
        public string GetAveragePriceOfType(string type)
        {
            List<Vehicle> groupedVehicles = (from transport in vehicles
                                             where transport.CarMake == type
                                             select transport).ToList();

            double number = 0;
            double sum = 0;

            foreach (var transport in groupedVehicles)
            {
                number += transport.Count;
                sum += transport.UnitCost * transport.Count;
            }

            return "Average price of " + type + ":" + (sum / number).ToString();
        }

        /// <summary>
        /// Null operation
        /// </summary>
        public string WrongOperation()
        {
            return "This command is wrong";
        }
    }
}