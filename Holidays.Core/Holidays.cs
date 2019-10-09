using System;
using System.Collections.Generic;

namespace Szyb.Holidays.Core
{
    public static class Holidays
    {
        private static List<(int month, int day, string name)> polishHolidays = new List<(int month, int day, string name)>();
        
        static Holidays()
        {
            polishHolidays.Add((1, 1, "Nowy Rok"));
            polishHolidays.Add((1, 6, "Święto Trzech Króli"));
            polishHolidays.Add((5, 1, "Święto Pracy"));
            polishHolidays.Add((5, 3, "Święto Konstytucji Trzeciego Maja"));
            polishHolidays.Add((8, 15, "Wniebowzięcie Najświętszej Maryi Panny"));
            polishHolidays.Add((11, 1, "Wszystkich Świętych"));
            polishHolidays.Add((11, 11, "Dzień Niepodległości"));
            polishHolidays.Add((12, 25, "Boże Narodzenie"));
            polishHolidays.Add((12, 26, "Boże Narodzenie"));

        }
        public static List<(DateTime date, string name)> GetPolishHolidays(int year)
        {
            var easterDate = Szyb.Computus.Core.Computus.GetEasterDate(year);
            var easterMondayDay = easterDate.AddDays(1);
            var pentecostDay = easterDate.AddDays(49);
            var corpusChristiDay = easterDate.AddDays(60);
            List<(DateTime date, string name)> polishHolidaysResult = new List<(DateTime date, string name)>();
            foreach(var day in polishHolidays)
            {
                polishHolidaysResult.Add((new DateTime(year, day.month, day.day), day.name));
            }
            polishHolidaysResult.Add((easterDate, "Niedziela Wielkanocna"));
            polishHolidaysResult.Add((easterMondayDay, "Poniedziałek Wielkanocny"));
            polishHolidaysResult.Add((pentecostDay, "Zielone Świątki"));
            polishHolidaysResult.Add((corpusChristiDay, "Boże Ciało"));

            polishHolidaysResult.Sort((x, y) => { return x.CompareTo(y); });

            return polishHolidaysResult;
        }
    }
}
