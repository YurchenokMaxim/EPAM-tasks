namespace _3D
{
    public interface IFlyable
    {
        /// <summary>
        /// This method changes the coordinate of the object.
        /// </summary>
        /// <param New coordinates = "coordinates"></param>
        public void FlyTo(Coordinate coordinates);

        /// <summary>
        /// This method returns the time it takes for the object to cover the distance.
        /// </summary>
        /// <param New coordinates = "coordinates"></param>
        /// <returns>Returns the flight time of the object to the given coordinate. </returns>
        public double GetFlyTime(Coordinate coordinates);
    }
}
