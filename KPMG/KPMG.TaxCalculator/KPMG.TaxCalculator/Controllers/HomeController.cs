using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KPMG.TaxCalculator.Business.Implementations;
using System.IO;
using System.Web.UI.HtmlControls;

namespace KPMG.TaxCalculator.Controllers
{
    public class HomeController : Controller
    {

        public static string ErrorMessage { get; set; }
        public static string FileImportCompletionResult { get; set; }

        public ActionResult Index()
        {
            ViewBag.CompletionResult = FileImportCompletionResult;
            ViewBag.ErrorMessage = ErrorMessage;
            ErrorMessage = "";
            FileImportCompletionResult = "";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult UploadTransaction()
        {
            string FilePath = Server.MapPath("~/CSV files/" + "CSVFile1.csv");
                
                int counter = 0;
                int importedLineCounter = 0;

                using (FileReader fileReader = new FileReader(FilePath))
                {
                    while (!fileReader.EndOfStream)
                    {
                        importedLineCounter++;
                        bool success = fileReader.ReadRow(fileReader.ReadLine().ToString());
                        if (!success)
                        {
                            counter = (counter + 1);
                            FileImportCompletionResult += "Validation failed for transaction line number # " + counter + "\n";
                            
                        }
                    }
                    FileImportCompletionResult += "Total number of failed transaction lines in validation #" + counter + "\n" + "Total number of imported transaction lines #" + (importedLineCounter - counter) + "\n";
                }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                ErrorMessage = "Please Choose file to upload before clicking on Upload button.";
            }
            else if (file.ContentType != "application/vnd.ms-excel")
            {
                ErrorMessage = "Sorry, Invalid File Type , only .csv files are supported.";
            }
            else
            {
                string FilePath = Server.MapPath("~/CSV files/" + file.FileName);
                
                int counter = 0;
                int importedLineCounter = 0;

                try
                {
                    using (FileReader fileReader = new FileReader(FilePath))
                    {
                        while (!fileReader.EndOfStream)
                        {
                            importedLineCounter++;
                            bool success = fileReader.ReadRow(fileReader.ReadLine().ToString());
                            if (!success)
                            {
                                counter = (counter + 1);
                                FileImportCompletionResult += "Validation failed for transaction line number # " + counter + "\n";

                            }
                        }
                        FileImportCompletionResult += "Total number of failed transaction lines in validation #" + counter + "\n" + "Total number of imported transaction lines #" + (importedLineCounter - counter) + "\n";
                    }
                }
                catch (FileNotFoundException e) {
                    ErrorMessage = "Please try uploading from KPMG/KPMG.TaxCalculator/KPMG.TaxCalculator/CSV files path, Thanks";
                }
            }
            return RedirectToAction("Index");
        }
    }
}