namespace Task7
{
    public class ConcreteCommandForCarPark : Command
    {
        public CarPark receiver;
        public string NameOfCommand;

        public ConcreteCommandForCarPark(CarPark carPark, string name)
        {
            if (carPark == null)
            {
                throw new System.Exception("The receiver does not exists");
            }
            receiver = carPark;
            NameOfCommand = name;
        }

        public override string Execute()
        {
            switch (NameOfCommand.Trim())
            {
                case "count types":
                    return receiver.GetCountOfTypes();
                case "count all":
                    return receiver.GetCountOfCars();
                case "average price":
                    return receiver.GetAveragePrice();
                case "exit": return "";
                default:
                    if (NameOfCommand.Trim().ToLower().IndexOf("average price ") == 0)
                    {
                        return receiver.GetAveragePriceOfType(NameOfCommand.Trim().ToLower().Substring(14));
                    }
                    else
                    {     
                        return receiver.WrongOperation();
                    };
            }
        }
    }
}
