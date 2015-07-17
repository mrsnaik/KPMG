using KPMG.TaxCalculator.Business.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.TaxCalculator.Business.Interfaces
{
    public interface IFileWriter
    {
        bool WriteRow(List<string> record);
    }
}
