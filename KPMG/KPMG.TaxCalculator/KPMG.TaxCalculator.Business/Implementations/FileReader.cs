using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPMG.TaxCalculator.Business.Interfaces;
using KPMG.TaxCalculator.DbLayer;
using KPMG.TaxCalculator.Model;
using System.Data.Entity;


namespace KPMG.TaxCalculator.Business.Implementations
{
    public class FileReader : StreamReader, IFileReader
    {
        public static readonly string[] CURRENCYCODES =
        {
            "GBP","INR","AED","AFN","ALL","AMD","ANG","AOA","ARS","AUD","AWG","AZN","BAM","BBD","BDT","BGN","JPY","FRF","USD","GRD","PKR"
        };
        public string fileName { get; set; }
        private TransactionContext db = new TransactionContext();

        public FileReader(Stream stream)
            : base(stream)
        {

        }
        public FileReader(string fileName)
            : base(fileName)
        {
            this.fileName = fileName;
        }
        public bool ReadRow(string record)
        {
            bool success = false;

            try
            {
                string[] fields = record.ToString().Split(',');

                success = ValidateTransactionData(fields);
            }
            catch (NullReferenceException)
            {
                success = false;
            }
            return success;
        }
        public bool ValidateTransactionData(string[] transactionData)
        {
            bool success = true;
            success = string.IsNullOrEmpty(transactionData[0]) ? false : true;
            success = string.IsNullOrEmpty(transactionData[1]) ? false : true;
            success = string.IsNullOrEmpty(transactionData[2]) ? false : true;
            success = string.IsNullOrEmpty(transactionData[3]) ? false : true;
            success = ValidateCurrencyCode(transactionData[2]);
            if (success == true)
            {
                db.Transaction.Add(getTransaction(transactionData));
                db.Save();
            }
            return success;
        }
        private bool ValidateCurrencyCode(string code)
        {
            bool success = false;
            for (int strNumber = 0; strNumber < CURRENCYCODES.Length; strNumber++)
            {
                if (CURRENCYCODES[strNumber] == code)
                {
                    success = true;
                }
            }
            return success;
        }
        private Transaction getTransaction(string[] transactionData)
        {
            Transaction transaction = new Transaction();
            transaction.Account = transactionData[0];
            transaction.Description = transactionData[1];
            transaction.CurrencyCode = transactionData[2];
            transaction.Amount = Convert.ToDecimal(transactionData[3]);
            return transaction;
        }

    }
}
