using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDaysCalculator.Tests
{
    public class BusinessDaysBetweenTwoDatesTests
    {
        public List<DateTime> publicHolidays = new List<DateTime> { new DateTime(2013, 12, 25), new DateTime(2013, 12, 26), new DateTime(2014, 1, 1) };
        [Fact]
        public void Case1()
        {
            //Arrange
            var startDate = new DateTime(2013, 10, 7);
            var endDate = new DateTime(2013, 10, 9);
            var businessDaysCounter = new BusinessDaysCounter();

            //Act
            var resultDays = businessDaysCounter.BusinessDaysBetweenTwoDates(startDate, endDate, publicHolidays);

            //Assert
            Assert.Equal(1, resultDays);
        }
        [Fact]
        public void Case2()
        {
            //Arrange
            var startDate = new DateTime(2013, 12, 24);
            var endDate = new DateTime(2013, 12, 27);
            var businessDaysCounter = new BusinessDaysCounter();

            //Act
            var resultDays = businessDaysCounter.BusinessDaysBetweenTwoDates(startDate, endDate, publicHolidays);

            //Assert
            Assert.Equal(0, resultDays);
        }

        [Fact]
        public void Case3()
        {
            //Arrange
            var startDate = new DateTime(2013, 10, 7);
            var endDate = new DateTime(2014, 1, 1);
            var businessDaysCounter = new BusinessDaysCounter();

            //Act
            var resultDays = businessDaysCounter.BusinessDaysBetweenTwoDates(startDate, endDate, publicHolidays);

            //Assert
            Assert.Equal(59, resultDays);
        }

        [Fact]
        public void Case4()
        {
            //Arrange
            DateTime startDate = new DateTime(2025, 6, 1);
            DateTime endDate = new DateTime(2025, 6, 30);

            var publicHolidays = new List<BaseHoliday>
            {
                new DynamicPublicHoliday(2025, 6, DayOfWeek.Monday, 2, name: "King's Birthday"), // Monday
                new FixedPublicHoliday(2025, 6, 22, true, name: "Random Holiday")   // Sunday carry forward to Monday
            };

            var businessDaysCounter = new BusinessDaysCounter();

            //Act
            var resultDays = businessDaysCounter.BusinessDaysBetweenTwoDates(startDate, endDate, publicHolidays);

            //Assert
            Assert.NotNull(publicHolidays[0].Date);
            Assert.NotNull(publicHolidays[1].Date);
            Assert.Equal(new DateTime(2025, 6, 9), publicHolidays[0].Date);
            Assert.Equal(new DateTime(2025, 6, 23), publicHolidays[1].Date);
            Assert.Equal(18, resultDays);
        }
    }
}
