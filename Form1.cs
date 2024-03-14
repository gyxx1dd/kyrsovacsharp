using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyrsovapocsharp
{
    public partial class Form1 : Form
    {
        private Catalog catalog;

        public Form1()
        {
            InitializeComponent();
            catalog = new Catalog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Date date = new Date(14, 2, 2024);
            Time time = new Time(6, 30, 15);
            File file = new File(14, 2, 2024, 6, 30, 15, "example.txt", 1024, "read/write");
            MessageBox.Show("Дата: " + date.Read() + "\nЧас: " + time.Read() + "\nФайл: " + file.Read());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text;
            File file = catalog.FindFile(fileName);
            if (file != null)
            {
                MessageBox.Show(file.ToString());
            }
            else
            {
                MessageBox.Show("Файл не знайдено.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int hoursToAdd;
            if (!int.TryParse(textBox2.Text, out hoursToAdd))
            {
                MessageBox.Show("Введено некоректне значення для годин.");
                return;
            }
            File currentFile = catalog.FindFile(textBox1.Text);
            if (currentFile == null)
            {
                MessageBox.Show("Файл не знайдено.");
                return;
            }
            currentFile.CreationTime.Hour += hoursToAdd;
            MessageBox.Show(currentFile.ToString());
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int hoursDell;
            if (!int.TryParse(textBox3.Text, out hoursDell))
            {
                MessageBox.Show("Введено некоректне значення для годин.");
                return;
            }
            File currentFile = catalog.FindFile(textBox1.Text);
            if (currentFile == null)
            {
                MessageBox.Show("Файл не знайдено.");
                return;
            }
            if (currentFile.CreationTime.Hour - hoursDell < 0)
            {
                MessageBox.Show("Години після зменшення не можуть бути від'ємними.");
                return;
            }
            currentFile.CreationTime.Hour -= hoursDell;
            MessageBox.Show(currentFile.ToString());
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateNewFile f1 = new CreateNewFile(catalog);
            f1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string filepath = @"C:\Users\skiv0\source\repos\kyrsovapocsharp\files.txt";
            try
            {
                catalog.AddToFileInfo(filepath);
                MessageBox.Show("Інфу додано");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Сталася помилка при додаванні інформації до файлу: {ex.Message}");
            }

        }
    }
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
        // Перевантаження потокової операції виведення

        public static implicit operator string(Date date)
        {
            return $"{date.Day}/{date.Month}/{date.Year}";
        }
        // Перевантаження потокової операції введення
        public static implicit operator Date(string str)
        {
            return new Date(1, 1, 2022); 
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
        public virtual string Read()
        {
            return $"{Day}/{Month}/{Year}";
        }
        
        ~Date()
        {

        }

    }
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

        // Перевантаження потокової операції виведення
        public static implicit operator string(Time time)
        {
            return $"{time.Hour}:{time.Minute}:{time.Second}";
        }

        // Перевантаження потокової операції введення
        public static implicit operator Time(string str)
        {
            return new Time(0, 0, 0); 
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
        public string Read()
        {
            return $"{Hour}:{Minute}:{Second}";
        }
        ~Time()
        {

        }
    }
}
