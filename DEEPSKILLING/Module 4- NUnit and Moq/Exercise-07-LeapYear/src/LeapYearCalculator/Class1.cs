using System;

namespace LeapYearCalculator
{
    public class LeapYearCalculator
    {
        public bool IsLeapYear(int year)
        {
            if (year % 400 == 0)
            {
                return true;
            }

            if (year % 100 == 0)
            {
                return false;
            }

            return year % 4 == 0;
        }
    }
}
