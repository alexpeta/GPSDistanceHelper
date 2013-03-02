using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using AlexPetaBlog.GPSDistanceCalculator;

namespace AlexPetaBlog.GPSDistanceCalculator.Tests
{
    [TestClass]
    public class GPSCalculatorTests
    {
        #region Private Members
        private GPSDistanceHelper _distanceHelper;

        private GPSPoint _bucharest;
        private GPSPoint _centralPark;

        #endregion Private Members

        [TestInitialize]
        public void Setup()
        {
            _distanceHelper = new GPSDistanceHelper();
            _bucharest = new GPSPoint(44.4269D, 026.1025D);
            _centralPark = new GPSPoint(40.7939D, -073.9571D);
        }

        [TestCleanup]
        public void TearDown()
        {
            _distanceHelper = null;
            _bucharest = GPSPoint.NullPoint;
            _centralPark = GPSPoint.NullPoint;
        }
        

        [TestMethod]
        public void GPSDistanceHelper_ToRadians_ReturnsCorrectResult()
        {
            //Arrange
            double expected = 0.174532925D;
            double delta = 0.000000001D;

            //Act
            double result = GPSDistanceHelper.DegreesToRadians(10);
            //Debug.WriteLine(result);
            
            //Assert
            Assert.AreEqual(expected, result, delta);
        }

        [TestMethod]
        public void GPSDistanceHelper_Calculate_ReturnsCorrectResult()
        {
            //Arrange
            double expected = 7641D;
            double result = 0D;
            double delta = 0.9D;

            GPSDistanceHelper helper = new GPSDistanceHelper(start : _bucharest, end :_centralPark);

            //Act
            result = helper.Distance;

            //Assert
            Assert.AreEqual(expected, result,delta);
        }
    }
}
