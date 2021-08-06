using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task7
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void PositiveTestOfSingleTon()
        {
            Vehicle vehicle = new Vehicle("opel", "astra", 3, 3500);
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(vehicle);
            CarPark s1 = CarPark.GetCarPark(vehicles);
            CarPark s2 = CarPark.GetCarPark(vehicles);

            if (s1 == s2)

            Assert.AreEqual(s1, s2);
        }

        [TestMethod]
        [DataRow("count types  ", "Count of car makes: 2")]
        [DataRow("  count all", "Count of cars: 10")]
        [DataRow("average price", "Average price: 2100")]
        [DataRow(" average price opel", "Average price of opel:2900")]
        [DataRow("exit ", "")]
        public void PositiveTestOfCarParkMethodsAndCommands(string value, string result)
        {
            Vehicle vehicle = new Vehicle("opel", "astra", 3, 3500);
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(vehicle);
            vehicle = new Vehicle("seat", "toledo", 5, 1300);
            vehicles.Add(vehicle);
            vehicle = new Vehicle("opel", "vectra", 2, 2000);
            vehicles.Add(vehicle);
            Invoker invoker = new Invoker();
            CarPark receiver = CarPark.GetCarPark(vehicles);
            ConcreteCommandForCarPark command = new ConcreteCommandForCarPark(receiver, value);

            invoker.SetCommand(command);

            Assert.AreEqual(invoker.Run(), result);
        }

        [TestMethod]
        [DataRow("coUnt types")]
        [DataRow("Count alL")]
        [DataRow("average Price")]
        [DataRow("averageprice opel")]
        [DataRow("ex it")]
        public void NegativeTestOfCarParkMethodsAndCommands(string value)
        {
            Vehicle vehicle = new Vehicle("opel", "astra", 3, 3500);
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(vehicle);
            vehicle = new Vehicle("seat", "toledo", 5, 1300);
            vehicles.Add(vehicle);
            vehicle = new Vehicle("opel", "vectra", 2, 2000);
            vehicles.Add(vehicle);
            Invoker invoker = new Invoker();
            CarPark receiver = CarPark.GetCarPark(vehicles);
            ConcreteCommandForCarPark command = new ConcreteCommandForCarPark(receiver, value);

            invoker.SetCommand(command);

            Assert.AreEqual(invoker.Run(), "This command is wrong");
        }
    }
}
