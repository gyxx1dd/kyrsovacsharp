using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyrsovapocsharp
{
    public class Catalog
    {
        private File[] files;

        public Catalog()
        {
            files = new File[10];
            files[0] = new File(14, 2, 2024, 6, 30, 15, "example.txt", 1024, "read/write");
        }

        public void AddFile(File newFile)
        {
            try
            {
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i] == null)
                    {
                        files[i] = newFile;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void AddToFileInfo(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                foreach (File file in files)
                {
                    if (file != null)
                    {
                        sw.WriteLine($"{file.CreationDate.Day} {file.CreationDate.Month} {file.CreationDate.Year} " +
                                     $"{file.CreationTime.Hour} {file.CreationTime.Minute} {file.CreationTime.Second} " +
                                     $"{file.FileName} {file.Size} {file.Attributes}");
                    }
                }
            }
        }

        // Метод для пошуку файлу за назвою
        public File FindFile(string fileName)
        {
            foreach (File file in files)
            {
                if (file != null && file.FileName == fileName)
                {
                    return file;
                }
            }
            return null; // Якщо файл не знайдено
        }
    }
}
