using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.TaxCalculator.Business.Implementations
{
    class Record : List<string>
    {
        public string LineText { get; set; }
    }
}
