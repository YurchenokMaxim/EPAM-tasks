using System;

namespace _3D
{
    public struct Coordinate
    {
        private double x;
        private double y;
        private double z;

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("The Coordinate X can't be negative");
                }
                else
                {
                    x = value;
                }
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("The Coordinate Y can't be negative");
                }
                else
                {
                    y = value;
                }
            }
        }

        public double Z
        {
            get
            {
                return z;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("The Coordinate Z can't be negative");
                }
                else
                {
                    z = value;
                }
            }
        }

        /// <summary>
        /// This method calculates the distance between two points according to the Pythagorean theorem.
        /// </summary>
        /// <param Coordinates of the object = "coordinate"></param>
        /// <returns>Return difference between two coordinates</returns>
        public double CountCoordinateDifference(Coordinate coordinate)
        {
            return Math.Sqrt((x - coordinate.x) * (x - coordinate.x) + (y - coordinate.y) * (y - coordinate.y) + (z - coordinate.z) * (z - coordinate.z));
        }
    }
}