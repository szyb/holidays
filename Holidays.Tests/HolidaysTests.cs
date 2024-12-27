using System;
using System.Linq;
using Xunit;

namespace Szyb.Holidays.Tests
{
    public class HolidaysTests
    {
        [Fact]
        public void GetPolishHolidays_ShouldReturnValidSortedTupleCollection()
        {
            var list = Core.Holidays.GetPolishHolidays(2019);

            Assert.Equal(13, list.Count());
            DateTime previousDay = DateTime.MinValue;
            foreach (var holiday in list)
            {
                Assert.True(previousDay < holiday.Date);
                Assert.Equal(2019, holiday.Date.Year);
            }
        }

        [InlineData(2023, false)]
        [InlineData(2024, false)]
        [InlineData(2025, true)]
        [InlineData(2026, true)]
        [Theory]
        public void GetPolishHolidays_NewHolidayChristmasEve(int year, bool christmasEveIsHoliday)
        {
            var list = Core.Holidays.GetPolishHolidays(year);
            var christmasEve = list.FirstOrDefault(x => x.Date.Month == 12 && x.Date.Day == 24);
            if (christmasEveIsHoliday)
                Assert.NotNull(christmasEve);
            else
                Assert.Null(christmasEve);
        }
    }
}
