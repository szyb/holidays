using System;
using Xunit;

namespace Szyb.Holidays.Tests
{
    public class HolidaysTests
    {
        [Fact]
        public void GetPolishHolidays_ShouldReturnValidSortedTupleCollection()
        {
            var list = Core.Holidays.GetPolishHolidays(2019);

            Assert.Equal(13, list.Count);
            DateTime previousDay = DateTime.MinValue;
            foreach (var (date, name) in list)
            {
                Assert.True(previousDay < date);
                Assert.Equal(2019, date.Year);
            }
        }
    }
}
