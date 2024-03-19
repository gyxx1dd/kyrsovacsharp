using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsovapocsharp
{
    public class Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public Time(int hour, int minute, int second)
        {
            if (!IsValidTime(hour, minute, second))
            {
                throw new ArgumentException("Invalid time");
            }

            Hour = hour;
            Minute = minute;
            Second = second;
        }

        private bool IsValidTime(int hour, int minute, int second)
        {
            return (hour >= 0 && hour < 24 && minute >= 0 && minute < 60 && second >= 0 && second < 60);
        }

        public static Time operator +(Time time, int seconds)
        {
            time.Second += seconds;
            return time;
        }

        public static Time operator -(Time time, int seconds)
        {
            time.Second -= seconds;
            return time;
        }

        


        public Time(Time other)
        {
            Hour = other.Hour;
            Minute = other.Minute;
            Second = other.Second;
        }

        public Time(Time other, bool move)
        {
            if (move)
            {
                Hour = other.Hour;
                Minute = other.Minute;
                Second = other.Second;
            }
        }

        public void SetHour(int hour)
        {
            Hour = hour;
        }

        public void SetMinute(int minute)
        {
            Minute = minute;
        }

        public int GetSecond()
        {
            return Second;
        }



        public override string ToString()
        {
            return $"{Hour}:{Minute}:{Second}";
        }
        
        
    }
}
