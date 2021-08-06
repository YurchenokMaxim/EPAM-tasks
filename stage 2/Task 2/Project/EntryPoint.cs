using System;
using System.Collections.Generic;

namespace Task7
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            string Command = "";
            Invoker invoker = new Invoker();
            CarPark receiver = CarPark.GetCarPark();
            ConcreteCommandForCarPark command = new ConcreteCommandForCarPark(receiver, "");
            Console.WriteLine("Next part of the solution");

            while (Command.ToLower() != "exit")
            {
                Command = Console.ReadLine();
                command = new ConcreteCommandForCarPark(receiver, Command);
                invoker.SetCommand(command);
                Console.WriteLine(invoker.Run());
            }

        }
    }
}