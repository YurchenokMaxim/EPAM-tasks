using System;

namespace _3D
{
    public class Bird : FlyingObject
    {
        public Bird(Coordinate coordinates) : base(coordinates) { }

        public override void FlyTo(Coordinate coordinate)
        {
            double L = CurrentPosition.CountCoordinateDifference(coordinate);
            if (L >= 4000)
            {
                throw new System.Exception("The Distance too far for bird");
            }
            CurrentPosition = coordinate;
        }

        public override double GetFlyTime(Coordinate coordinate)
        {
            Random rnd = new Random();
            Speed = Convert.ToDouble(rnd.Next(1, 200)) / 10.0;
            double L = CurrentPosition.CountCoordinateDifference(coordinate);

            if (L >= 4000)
            {
                throw new System.Exception("The Distance too far for bird");
            }

            double time = L / Speed;
            return time;
        }
    }
}
