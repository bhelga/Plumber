using System;
using System.Collections.Generic;
using System.Text;

namespace Plumber
{
    class GameObjectPlace
    {
        private double xCoordinate;
        public double XCoordinate
        {
            get
            {
                return xCoordinate;
            }
            set
            {
                xCoordinate = value;
            }
        }
        private double yCoordinate;
        public double YCoordinate
        {
            get
            {
                return yCoordinate;
            }
            set
            {
                yCoordinate = value;
            }
        }

        public GameObjectPlace(double xCoordinate, double yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
    }
}
