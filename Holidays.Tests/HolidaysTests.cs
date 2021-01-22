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
    }
}
