using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsovapocsharp
{
    public class File
    {
        public string FileName { get; set; }
        public long Size { get; set; }
        public string Attributes { get; set; }
        public Time CreationTime { get; set; }
        public Date CreationDate { get; set; }

        public File(int day, int month, int year, int hour, int minute, int second, string fileName, long size, string attributes)
        {
            FileName = fileName;
            Size = size;
            Attributes = attributes;
            CreationTime = new Time(hour, minute, second);
            CreationDate = new Date(day, month, year);

        }



        public override string ToString()
        {
            return $"File Name: {FileName}\n" +
                   $"Size: {Size} bytes\n" +
                   $"Attributes: {Attributes}\n" +
                   $"Date Created: {CreationDate}\n" +
                   $"Time Created: {CreationTime}";
        }
        
    }
}
