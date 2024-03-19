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
            MessageBox.Show("Дата: " + date.ToString() + "\nЧас: " + time.ToString() + "\nФайл: " + file.ToString());

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
    
    
}
