namespace _3D
{
    public class Plane : FlyingObject
    {
        public Plane(Coordinate coordinates) : base(coordinates)
        {
            Speed = 200;
        }

        public override void FlyTo(Coordinate coordinate)
        {
            double L = CurrentPosition.CountCoordinateDifference(coordinate);
            if (L >= 7000)
            {
                throw new System.Exception("The Distance too far for plane");
            }
            CurrentPosition = coordinate;
        }

        public override double GetFlyTime(Coordinate coordinate)
        {
            double L = CurrentPosition.CountCoordinateDifference(coordinate);
            double time = 0.0;
            double index = 0;

            if (L >= 7000)
            {
                throw new System.Exception("The Distance too far for plane");
            }
            if (L < 10.0)
            {
                time += L / Speed;
                L = 0;
            }
            else
            {
                while (L >= 10.0)
                {
                    if ((Speed + 10 * index) >= 28800)
                    {
                        index--;
                    }
                    time = time + 10 / (Speed + 10 * index);
                    L -= 10;
                    index++;
                }
            }
            Speed = 200;
            return time;
        }
    }
}
