using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexPetaBlog.GPSDistanceCalculator
{
    public struct GPSPoint
    {
        #region Private Members
        private double _latitude;
        private double _longitude;
        #endregion Private Members

        #region Public Properties
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
        #endregion Public Properties

        #region Constructors
        public GPSPoint(double latitude, double longitude)
        {
            _latitude = latitude;
            _longitude = longitude;
        }
        #endregion Constructors

        #region NullObject Pattern
        private static GPSPoint _empty = new GPSPoint(0, 0);
        public static GPSPoint NullPoint = _empty;
        #endregion NullObject Pattern
    }
}
