using System;
using System.Collections.Generic;
using System.Linq;

namespace Szyb.Holidays.Core
{
    public static class Holidays
    {
        private static IList<PolishHolidayDefinition> polishHolidays = new List<PolishHolidayDefinition>();

        static Holidays()
        {
            polishHolidays.Add(new PolishHolidayDefinition(1, 1, "Nowy Rok"));
            polishHolidays.Add(new PolishHolidayDefinition(1, 6, "Święto Trzech Króli"));
            polishHolidays.Add(new PolishHolidayDefinition(5, 1, "Święto Pracy"));
            polishHolidays.Add(new PolishHolidayDefinition(5, 3, "Święto Konstytucji Trzeciego Maja"));
            polishHolidays.Add(new PolishHolidayDefinition(8, 15, "Wniebowzięcie Najświętszej Maryi Panny"));
            polishHolidays.Add(new PolishHolidayDefinition(11, 1, "Wszystkich Świętych"));
            polishHolidays.Add(new PolishHolidayDefinition(11, 11, "Dzień Niepodległości"));
            polishHolidays.Add(new PolishHolidayDefinition(12, 25, "Boże Narodzenie"));
            polishHolidays.Add(new PolishHolidayDefinition(12, 26, "Boże Narodzenie"));

        }
        public static IEnumerable<PolishHoliday> GetPolishHolidays(int year)
        {
            var easterDate = Szyb.Computus.Core.Computus.GetEasterDate(year);
            var easterMondayDay = easterDate.AddDays(1);
            var pentecostDay = easterDate.AddDays(49);
            var corpusChristiDay = easterDate.AddDays(60);
            List<PolishHoliday> polishHolidaysResult = new List<PolishHoliday>();
            foreach (var day in polishHolidays)
            {
                polishHolidaysResult.Add(new PolishHoliday(new DateTime(year, day.Month, day.Day), day.Name));
            }
            if (year >= 2025)
            {
                polishHolidaysResult.Add(new PolishHoliday(new DateTime(year, 12, 24), "Wigilia Bożego Narodzenia"));
            }
            polishHolidaysResult.Add(new PolishHoliday(easterDate, "Niedziela Wielkanocna"));
            polishHolidaysResult.Add(new PolishHoliday(easterMondayDay, "Poniedziałek Wielkanocny"));
            polishHolidaysResult.Add(new PolishHoliday(pentecostDay, "Zielone Świątki"));
            polishHolidaysResult.Add(new PolishHoliday(corpusChristiDay, "Boże Ciało"));

            polishHolidaysResult.Sort((x, y) => { return x.CompareTo(y); });

            return polishHolidaysResult;
        }
    }
}
