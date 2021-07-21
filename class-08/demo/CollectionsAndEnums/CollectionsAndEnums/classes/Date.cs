using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndEnums.classes
{
  class Date
  {
    public int DayOfMonth { get; set; }
    public DayOfTheWeek Day { get; set; }
  }

  enum DayOfTheWeek
  {
    Sunday = 156,
    Monday,
    Tuesday,
    Wednesday = 1000,
    Thursday,
    Friday,
    Saturday = Monday + Thursday
  }

  enum Months : byte
  {
    Jan,
    Feb,
    Mar,
    Apr,
    May,
    Jun,
    Jul,
    Aug,
    Sep,
    Oct,
    Nov,
    Dec
  }

}
