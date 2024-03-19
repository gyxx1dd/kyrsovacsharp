using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace kyrsovapocsharp
{
    public class Catalog : IEnumerable<File> //IEnumerable це інтерфейс, який допомагає створити ітератор для перебору елементів в колекції
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
                throw new Exception("Немає вільного місця для нового файлу.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при додаванні файлу: {ex.Message}");
                throw; 
            }
        }


        public void AddToFileInfo(string filePath)
        {
            if (files == null)
            {
                throw new InvalidOperationException("Масив файлів не був ініціалізований.");
            }

            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при записі в файл: {ex.Message}");
                throw; 
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
        //повертає об'єкт, який можна використовувати для послідовного перебору елементів
        public IEnumerator<File> GetEnumerator()
        {
            foreach (File file in files)
            {
                if (file != null)
                {
                    yield return file;
                }
            }
        }
        //просто повертає результат виклику методу GetEnumerator() для коректної роботи
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
