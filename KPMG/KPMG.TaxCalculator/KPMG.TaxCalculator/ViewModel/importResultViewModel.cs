using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPMG.TaxCalculator.ViewModel
{
    public class ImportResultViewModel
    {
        public string FileImportCompletionResult { get; set; }

        public ImportResultViewModel()
        {
            FileImportCompletionResult = "";
        }
    }
}