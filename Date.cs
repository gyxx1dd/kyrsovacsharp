using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsovapocsharp
{
    public class Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Date(int day, int month, int year)
        {
            if (!IsValidDate(day, month, year))
            {
                throw new ArgumentException("Invalid date");
            }

            Day = day;
            Month = month;
            Year = year;

        }

        private bool IsValidDate(int day, int month, int year)
        {
            if (year < 1 || month < 1 || month > 12 || day < 1)
                return false;

            int maxDay = DateTime.DaysInMonth(year, month);
            return day <= maxDay;
        }

        public static Date operator +(Date date, int daysToAdd)
        {
            date.Day += daysToAdd;
            return date;
        }

        public static Date operator -(Date date, int daysToSubtract)
        {
            date.Day -= daysToSubtract;
            return date;
        }
        

        //копіювання
        public Date(Date other)
        {
            Day = other.Day;
            Month = other.Month;
            Year = other.Year;
        }
        //переміщення
        public Date(Date other, bool move)
        {
            if (move)
            {
                Day = other.Day;
                Month = other.Month;
                Year = other.Year;
            }
        }
        public void SetDay(int day)
        {
            Day = day;
        }

        public void SetMonth(int month)
        {
            Month = month;
        }

        public int GetYear()
        {
            return Year;
        }
        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }



        


    }
}
