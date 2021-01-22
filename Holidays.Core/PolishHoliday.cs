using System;
using System.Collections.Generic;
using System.Text;

namespace Szyb.Holidays.Core
{
  public class PolishHoliday : IComparable<PolishHoliday>
  {
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public PolishHoliday(DateTime date, string name)
    {
      Date = date;
      Name = name;
    }

    public int CompareTo(PolishHoliday other)
    {
      return this.Date.CompareTo(other.Date);
    }
  }
}
