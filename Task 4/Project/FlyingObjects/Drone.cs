using System;

namespace _3D
{
    public class Drone : FlyingObject
    {
        public Drone(Coordinate coordinates, double speed) : base(coordinates)
        {
            Speed = speed;
        }

        public override void FlyTo(Coordinate coordinate)
        {
            double L = CurrentPosition.CountCoordinateDifference(coordinate);
            if (L >= 1000)
            {
                Console.WriteLine("The drone cannot fly more than 1000 km");
            }
            else
            {
                CurrentPosition = coordinate;
            }

        }

        public override double GetFlyTime(Coordinate coordinate)
        {
            double L = CurrentPosition.CountCoordinateDifference(coordinate);
            if (L >= 1000)
            {
                throw new Exception("The drone cannot fly more than 1000 km");
            }

            double time = L / Speed;
            if (time > 0.16)
            {
                time = time + (time / 10);
            }
            CurrentPosition = coordinate;
            return time;
        }
    }
}
