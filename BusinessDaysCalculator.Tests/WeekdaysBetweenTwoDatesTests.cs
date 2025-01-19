using System;

namespace BusinessDaysCalculator.Tests
{
    public class WeekdaysBetweenTwoDatesTests
    {
        [Fact]
        public void Case1()
        {
            //Arrange
            var startDate = new DateTime(2013, 10, 7);
            var endDate = new DateTime(2013, 10, 9);
            var businessDaysCounter = new BusinessDaysCounter();

            //Act
            var resultDays = businessDaysCounter.WeekdaysBetweenTwoDates(startDate, endDate);

            //Assert
            Assert.Equal(1, resultDays);
        }

        [Fact]
        public void Case2()
        {
            //Arrange
            var startDate = new DateTime(2013, 10, 5);
            var endDate = new DateTime(2013, 10, 14);
            var businessDaysCounter = new BusinessDaysCounter();

            //Act
            var resultDays = businessDaysCounter.WeekdaysBetweenTwoDates(startDate, endDate);

            //Assert
            Assert.Equal(5, resultDays);
        }

        [Fact]
        public void Case3()
        {
            //Arrange
            var startDate = new DateTime(2013, 10, 7);
            var endDate = new DateTime(2014, 1, 1);
            var businessDaysCounter = new BusinessDaysCounter();

            //Act
            var resultDays = businessDaysCounter.WeekdaysBetweenTwoDates(startDate, endDate);

            //Assert
            Assert.Equal(61, resultDays);
        }

        [Fact]
        public void Case4()
        {
            //Arrange
            var startDate = new DateTime(2013, 10, 7);
            var endDate = new DateTime(2013, 10, 5);
            var businessDaysCounter = new BusinessDaysCounter();

            //Act
            var resultDays = businessDaysCounter.WeekdaysBetweenTwoDates(startDate, endDate);

            //Assert
            Assert.Equal(0, resultDays);
        }
    }
}