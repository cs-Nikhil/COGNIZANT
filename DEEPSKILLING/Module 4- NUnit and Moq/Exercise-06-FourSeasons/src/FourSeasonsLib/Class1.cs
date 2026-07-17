using System;

namespace FourSeasonsLib
{
    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    public class SeasonService
    {
        public Season GetSeason(int month)
        {
            switch (month)
            {
                case 3:
                case 4:
                case 5:
                    return Season.Spring;
                case 6:
                case 7:
                case 8:
                    return Season.Summer;
                case 9:
                case 10:
                case 11:
                    return Season.Autumn;
                case 12:
                case 1:
                case 2:
                    return Season.Winter;
                default:
                    throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");
            }
        }
    }
}
