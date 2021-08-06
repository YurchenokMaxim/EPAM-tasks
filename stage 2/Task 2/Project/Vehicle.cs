namespace Task7
{
    public class Vehicle
    {
        public string CarMake { get; private set; }

        public string CarModel { get; private set; }

        public int Count { get; private set; }

        public double UnitCost { get; private set; }

        public Vehicle(string CarMake, string CarModel, int Count, double UnitCost)
        {
            if (CarMake.Equals(string.Empty) || CarModel.Equals(string.Empty) || Count < 0 || UnitCost <= 0)
            {
                throw new System.Exception("Erroneous parameters in Vehicle initialization");
            }
            this.CarMake = CarMake;
            this.CarModel = CarModel;
            this.Count = Count;
            this.UnitCost = UnitCost;
        }
    }
}
