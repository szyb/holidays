using System;
using System.Collections.Generic;
using System.Text;

namespace Szyb.Holidays.Core
{
  public class PolishHolidayDefinition
  {
    public int Month { get; set; }
    public int Day { get; set; }
    public string Name { get; set; }
    public PolishHolidayDefinition(int month, int day, string name)
    {
      Month = month;
      Day = day;
      Name = name;
    }
   
  }
}
