using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyrsovapocsharp
{
    public partial class CreateNewFile : Form
    {
        private Catalog catalog;

        public CreateNewFile(Catalog catalog)
        {
            InitializeComponent();
            this.catalog = catalog;
        }

        private void CreateNewFile_Load(object sender, EventArgs e)
        {

        }

        private void bt1_Click(object sender, EventArgs e)
        {
            int day, month, year, hour, minute, second;
            long size;
            string fileName, attributes;
            if (!int.TryParse(tb1.Text, out day) || !int.TryParse(tb2.Text, out month) || !int.TryParse(tb3.Text, out year) ||
                !int.TryParse(tb4.Text, out hour) || !int.TryParse(tb5.Text, out minute) || !int.TryParse(tb6.Text, out second) ||
                !long.TryParse(tb8.Text, out size))
            {
                MessageBox.Show("Введено некоректні значення.");
                return;
            }
            fileName = tb7.Text;
            attributes = tb9.Text;
            File newFile = new File(day, month, year, hour, minute, second, fileName, size, attributes);
            catalog.AddFile(newFile);
            MessageBox.Show("Файл успішно створено:\n" + newFile.ToString());

        }
    }
}
