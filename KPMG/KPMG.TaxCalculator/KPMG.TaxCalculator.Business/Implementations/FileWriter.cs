using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPMG.TaxCalculator.Business.Interfaces;
namespace KPMG.TaxCalculator.Business.Implementations
{
    public class FileWriter : StreamReader, IFileWriter
    {
        public string FileName { get; set; }

        public FileWriter(Stream stream):base(stream)
        {
        }
        public FileWriter(string fileName):base(fileName)
        {
            this.FileName = FileName;
        }
        public bool WriteRow(List<String> record)
        {
            bool success = false;
            return success;
        }
    }
}
