using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarPark;
using System;

namespace CarParkTests
{
    [TestClass]
    public class CarParkTest
    {
        [TestMethod]
        public void PositiveTestOfCarParkMethodsAndAllVehicles()
        {
            Transmission transmission = new Transmission("Type1", 1, "Manufacture1");
            Chassis chassis = new Chassis(4, 10, 1);
            Engine engine = new Engine(5, 5, "Type1", "Serial Number");
            Bus bus = new Bus(50, 70, transmission, chassis, engine);
            Car car = new Car("1500", 180, transmission, chassis, engine);
            Motocycle motocycle = new Motocycle("Type1", 200, transmission, chassis, engine);
            Truck truck = new Truck("5 t.", 110, transmission, chassis, engine);
            CarPark.CarPark firstPark = new CarPark.CarPark();

            firstPark.AddNewVehicle(bus);
            firstPark.AddNewVehicle(motocycle);
            firstPark.AddNewVehicle(truck);
            firstPark.AddNewVehicle(car);

            Assert.AreEqual(firstPark.GetFullInfo(), " BUS Number of passanger seats: 50 ENGINE power: 5 volume: 5 type: Type1 Serial Number: Serial Number TRANSMISSION type: Type1 number of gears: 1 manufacture: Manufacture1 CHASSIS number of wheels: 4 permissible load: 10 Number: 1 Max Speed: 70 " +
                "MOTOCYCLE Type: Type1 ENGINE power: 5 volume: 5 type: Type1 Serial Number: Serial Number TRANSMISSION type: Type1 number of gears: 1 manufacture: Manufacture1 CHASSIS number of wheels: 4 permissible load: 10 Number: 1 Max Speed: 200 " +
                "TRUCK Carrying: 5 t. ENGINE power: 5 volume: 5 type: Type1 Serial Number: Serial Number TRANSMISSION type: Type1 number of gears: 1 manufacture: Manufacture1 CHASSIS number of wheels: 4 permissible load: 10 Number: 1 Max Speed: 110 " +
                "CAR Weight: 1500 ENGINE power: 5 volume: 5 type: Type1 Serial Number: Serial Number TRANSMISSION type: Type1 number of gears: 1 manufacture: Manufacture1 CHASSIS number of wheels: 4 permissible load: 10 Number: 1 Max Speed: 180");
        }

        [TestMethod]
        public void PositiveTestOfCarParkRemove()
        {
            Transmission transmission = new Transmission("Type1", 1, "Manufacture1");
            Chassis chassis = new Chassis(4, 10, 1);
            Engine engine = new Engine(5, 5, "Type1", "Serial Number");
            Bus bus = new Bus(50, 70, transmission, chassis, engine);
            Car car = new Car("1500", 180, transmission, chassis, engine);
            Motocycle motocycle = new Motocycle("Type1", 200, transmission, chassis, engine);
            Truck truck = new Truck("5 t.", 110, transmission, chassis, engine);
            CarPark.CarPark firstPark = new CarPark.CarPark();

            firstPark.AddNewVehicle(bus);
            firstPark.AddNewVehicle(motocycle);
            firstPark.AddNewVehicle(truck);
            firstPark.AddNewVehicle(car);
            firstPark.RemoveAuto(2);

            Assert.AreEqual(firstPark.GetCountOfVehicles(), 3);
        }

        [TestMethod]
        public void PositiveTestOfCarParkUpdate()
        {
            Transmission transmission = new Transmission("Type1", 1, "Manufacture1");
            Chassis chassis = new Chassis(4, 10, 1);
            Engine engine = new Engine(5, 5, "Type1", "Serial Number");
            Bus bus = new Bus(50, 70, transmission, chassis, engine);
            Car car = new Car("1500", 180, transmission, chassis, engine);
            Motocycle motocycle = new Motocycle("Type1", 200, transmission, chassis, engine);
            Truck truck = new Truck("5 t.", 110, transmission, chassis, engine);
            CarPark.CarPark firstPark = new CarPark.CarPark();

            firstPark.AddNewVehicle(bus);
            firstPark.AddNewVehicle(motocycle);
            firstPark.AddNewVehicle(truck);
            firstPark.AddNewVehicle(car);
            firstPark.UpdateAuto(2, bus);

            Assert.AreEqual(firstPark.GetElement(2), bus);
        }

        [TestMethod]
        public void PositiveTestOfCarParkAdd()
        {
            Transmission transmission = new Transmission("Type1", 1, "Manufacture1");
            Chassis chassis = new Chassis(4, 10, 1);
            Engine engine = new Engine(5, 5, "Type1", "Serial Number");
            Bus bus = new Bus(50, 70, transmission, chassis, engine);
            Car car = new Car("1500", 180, transmission, chassis, engine);
            Motocycle motocycle = new Motocycle("Type1", 200, transmission, chassis, engine);
            Truck truck = new Truck("5 t.", 110, transmission, chassis, engine);
            CarPark.CarPark firstPark = new CarPark.CarPark();

            firstPark.AddNewVehicle(bus);
            firstPark.AddNewVehicle(motocycle);
            firstPark.AddNewVehicle(truck);
            firstPark.AddNewVehicle(car);

            Assert.AreEqual(firstPark.GetCountOfVehicles(), 4);
        }

        [TestMethod]
        public void PositiveTestOfCarParkAddAndGetAutoByParameter()
        {
            Transmission transmission = new Transmission("Type1", 1, "Manufacture1");
            Chassis chassis = new Chassis(4, 10, 1);
            Engine engine = new Engine(5, 5, "Type1", "Serial Number");
            Bus bus = new Bus(50, 70, transmission, chassis, engine);
            Car car = new Car("1500", 180, transmission, chassis, engine);
            Motocycle motocycle = new Motocycle("Type1", 200, transmission, chassis, engine);
            Truck truck = new Truck("5 t.", 110, transmission, chassis, engine);
            CarPark.CarPark firstPark = new CarPark.CarPark();
            string parameter = "maxSpeed";
            string value = "70";
            CarPark.CarPark result = new CarPark.CarPark();

            firstPark.AddNewVehicle(bus);
            firstPark.AddNewVehicle(motocycle);
            firstPark.AddNewVehicle(truck);
            firstPark.AddNewVehicle(car);
            var selectedVehicles = firstPark.GatAutoByParameter(parameter, value);

            Assert.AreEqual(selectedVehicles[0], bus);
        }

        [TestMethod]
        [ExpectedException(typeof(UpdateAutoException))]
        [DataRow(-1)]
        [DataRow(4)]
        public void NegativeTestOfCarParkUpdateAuto(int value)
        {
            Transmission transmission = new Transmission("Type1", 1, "Manufacture1");
            Chassis chassis = new Chassis(4, 10, 1);
            Engine engine = new Engine(5, 5, "Type1", "Serial Number");
            Bus bus = new Bus(50, 70, transmission, chassis, engine);
            Car car = new Car("1500", 180, transmission, chassis, engine);
            Motocycle motocycle = new Motocycle("Type1", 200, transmission, chassis, engine);
            Truck truck = new Truck("5 t.", 110, transmission, chassis, engine);
            CarPark.CarPark firstPark = new CarPark.CarPark();

            firstPark.AddNewVehicle(bus);
            firstPark.AddNewVehicle(motocycle);
            firstPark.AddNewVehicle(truck);
            firstPark.AddNewVehicle(car);
            firstPark.UpdateAuto(value, bus);
        }

        [TestMethod]
        [ExpectedException(typeof(RemoveAutoException))]
        [DataRow(-1)]
        [DataRow(4)]
        public void NegativeTestOfCarParkRemoveVehicle(int value)
        {
            Transmission transmission = new Transmission("Type1", 1, "Manufacture1");
            Chassis chassis = new Chassis(4, 10, 1);
            Engine engine = new Engine(5, 5, "Type1", "Serial Number");
            Bus bus = new Bus(50, 70, transmission, chassis, engine);
            Car car = new Car("1500", 180, transmission, chassis, engine);
            Motocycle motocycle = new Motocycle("Type1", 200, transmission, chassis, engine);
            Truck truck = new Truck("5 t.", 110, transmission, chassis, engine);
            CarPark.CarPark firstPark = new CarPark.CarPark();

            firstPark.AddNewVehicle(bus);
            firstPark.AddNewVehicle(motocycle);
            firstPark.AddNewVehicle(truck);
            firstPark.AddNewVehicle(car);
            firstPark.RemoveAuto(value);
        }

        [TestMethod]
        [ExpectedException(typeof(AddException))]
        public void NegativeTestOfCarParkAddAuto()
        {
            Transmission transmission = new Transmission("Type1", 1, "Manufacture1");
            Chassis chassis = new Chassis(4, 10, 1);
            Engine engine = new Engine(5, 5, "Type1", "Serial Number");
            Bus bus = new Bus(50, 70, transmission, chassis, engine);
            Car car = new Car();
            Motocycle motocycle = new Motocycle("Type1", 200, transmission, chassis, engine);
            Truck truck = new Truck("5 t.", 110, transmission, chassis, engine);
            CarPark.CarPark firstPark = new CarPark.CarPark();

            firstPark.AddNewVehicle(bus);
            firstPark.AddNewVehicle(motocycle);
            firstPark.AddNewVehicle(truck);
            firstPark.AddNewVehicle(car);
        }

        [TestMethod]
        [ExpectedException(typeof(GetAutoByParameterException))]
        public void NegativeTestOfCarParkGetAutoByParameter()
        {
            Transmission transmission = new Transmission("Type1", 1, "Manufacture1");
            Chassis chassis = new Chassis(4, 10, 1);
            Engine engine = new Engine(5, 5, "Type1", "Serial Number");
            Bus bus = new Bus(50, 70, transmission, chassis, engine);
            Car car = new Car("1500", 180, transmission, chassis, engine);
            Motocycle motocycle = new Motocycle("Type1", 200, transmission, chassis, engine);
            Truck truck = new Truck("5 t.", 110, transmission, chassis, engine);
            CarPark.CarPark firstPark = new CarPark.CarPark();
            string parameter = "1111";
            string value = "70";
            CarPark.CarPark result = new CarPark.CarPark();
            var selectedVehicles = firstPark.GatAutoByParameter(parameter, value);

            firstPark.AddNewVehicle(bus);
            firstPark.AddNewVehicle(motocycle);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow("", 1, "1")]
        [DataRow("1", 1, "")]
        [DataRow("1", 0, "1")]
        public void NegativeTestWrongEntryDataOfTransmission(string type, int number, string manufacture)
        {
            Transmission transmission = new Transmission(type, number, manufacture);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow(0, 1, 1)]
        [DataRow(1, 0, 1)]
        [DataRow(1, 1, 0)]
        public void NegativeTestWrongEntryDataOfChassis(int NumberOfWheels, double PermissibleLoad, int Number)
        {
            Chassis chassis = new Chassis(NumberOfWheels, PermissibleLoad, Number);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow(0, 1, "1", "1")]
        [DataRow(1, 0, "1", "1")]
        [DataRow(1, 1, "", "1")]
        [DataRow(1, 1, "1", "")]

        public void NegativeTestWrongEntryDataOfEngine(double Power, double Volume, string Type, string SerialNumber)
        {
            Engine engine = new Engine(Power, Volume, Type, SerialNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(InitializationException))]
        [DataRow(0, 1)]
        [DataRow(1, 0)]
        public void NegativeTestWrongEntryDataOfBus(int number, double speed)
        {
            Transmission transmission = new Transmission("Type1", 1, "Manufacture1");
            Chassis chassis = new Chassis(4, 10, 1);
            Engine engine = new Engine(5, 5, "Type1", "Serial Number");
            Bus bus = new Bus(number, speed, transmission, chassis, engine);
        }

        [TestMethod]
        [ExpectedException(typeof(InitializationException))]
        [DataRow("", 1)]
        [DataRow("1", 0)]
        public void NegativeTestWrongEntryDataOfMotocycle(string type, double speed)
        {
            Transmission transmission = new Transmission("Type1", 1, "Manufacture1");
            Chassis chassis = new Chassis(4, 10, 1);
            Engine engine = new Engine(5, 5, "Type1", "Serial Number");
            Motocycle motocycle = new Motocycle(type, speed, transmission, chassis, engine);
        }

        [TestMethod]
        [ExpectedException(typeof(InitializationException))]
        [DataRow("", 1)]
        [DataRow("1", 0)]
        public void NegativeTestWrongEntryDataOfTruck(string carrying, double speed)
        {
            Transmission transmission = new Transmission("Type1", 1, "Manufacture1");
            Chassis chassis = new Chassis(4, 10, 1);
            Engine engine = new Engine(5, 5, "Type1", "Serial Number");
            Truck truck = new Truck(carrying, speed, transmission, chassis, engine);
        }

        [TestMethod]
        [ExpectedException(typeof(InitializationException))]
        [DataRow("", 1)]
        [DataRow("1", 0)]
        public void NegativeTestWrongEntryDataOfCar(string weight, double speed)
        {
            Transmission transmission = new Transmission("Type1", 1, "Manufacture1");
            Chassis chassis = new Chassis(4, 10, 1);
            Engine engine = new Engine(5, 5, "Type1", "Serial Number");
            Car car = new Car(weight, speed, transmission, chassis, engine);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow(5)]
        [DataRow(-1)]
        public void NegativeTestOfGetElement(int index)
        {
            Transmission transmission = new Transmission("Type1", 1, "Manufacture1");
            Chassis chassis = new Chassis(4, 10, 1);
            Engine engine = new Engine(5, 5, "Type1", "Serial Number");
            Bus bus = new Bus(50, 70, transmission, chassis, engine);
            Car car = new Car("1500", 180, transmission, chassis, engine);
            Motocycle motocycle = new Motocycle("Type1", 200, transmission, chassis, engine);
            Truck truck = new Truck("5 t.", 110, transmission, chassis, engine);
            CarPark.CarPark firstPark = new CarPark.CarPark();

            firstPark.AddNewVehicle(bus);
            firstPark.AddNewVehicle(motocycle);
            firstPark.AddNewVehicle(truck);
            firstPark.AddNewVehicle(car);
            firstPark.GetElement(index);
        }
    }
}