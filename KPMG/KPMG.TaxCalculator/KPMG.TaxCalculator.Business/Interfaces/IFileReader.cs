using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPMG.TaxCalculator.Business.Implementations;

namespace KPMG.TaxCalculator.Business.Interfaces
{
    public interface IFileReader
    {
        bool ReadRow(string record);
    }
}
