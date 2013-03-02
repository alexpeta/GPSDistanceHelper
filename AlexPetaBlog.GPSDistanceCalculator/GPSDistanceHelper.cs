using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexPetaBlog.GPSDistanceCalculator
{
    /// <summary>
    /// This uses the ‘haversine’ formula to calculate the great-circle distance between two points – that is, the shortest distance over the earth’s surface – giving an ‘as-the-crow-flies’ distance between the points (ignoring any hills, of course!).
    /// </summary>
    public class GPSDistanceHelper
    {

        #region Private Members
        //represents the radius of the Earth in KM
        private readonly int R = 6371;
        private GPSPoint _start;
        private GPSPoint _end;
        private double _distance;
        #endregion Private Members

        #region Public Properties
        public GPSPoint Start
        {
            get { return _start; }
            set { _start = value; }
        }
        public GPSPoint End
        {
            get { return _end; }
            set { _end = value; }
        }
        public double Distance
        {
            get
            {
                return _distance;   
            }
            set
            {
                _distance = value;
            }
        }
        #endregion Public Properties

        #region Constructors
        public GPSDistanceHelper(): this(GPSPoint.NullPoint,GPSPoint.NullPoint)
        {
        }
        public GPSDistanceHelper(GPSPoint start,GPSPoint end)
        {
            Start = start;
            End = end;

            CalculateDistance();
        }
        #endregion Constructors



        #region Statics
        public static  double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }
        #endregion Statics

        #region Private Methods
        private void CalculateDistance()
        {
            double dLat = GPSDistanceHelper.DegreesToRadians(End.Latitude - Start.Latitude);
            double dLon = GPSDistanceHelper.DegreesToRadians(End.Longitude - Start.Longitude);

            double lat1 = GPSDistanceHelper.DegreesToRadians(Start.Latitude);
            double lat2 = GPSDistanceHelper.DegreesToRadians(End.Latitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            this.Distance = R * c;
        }
        #endregion Private Methods
    }
}
