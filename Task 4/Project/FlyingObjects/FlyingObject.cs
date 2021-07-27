using System;
namespace _3D
{
    public abstract class FlyingObject : IFlyable
    {
        private double speed;

        public Coordinate CurrentPosition { get; set; }

        public double Speed
        {
            get
            {
                return speed;
            }

            set
            {
                if (value <= 0)
                {
                    throw new Exception("The property Speed can't be negative or zero");
                }
                else
                {
                    speed = value;
                }
            }
        }

        protected FlyingObject(Coordinate CurrentPosition)
        {
            this.CurrentPosition = CurrentPosition;
        }

        public abstract void FlyTo(Coordinate coordinates);

        public abstract double GetFlyTime(Coordinate coordinates);
    }
}
