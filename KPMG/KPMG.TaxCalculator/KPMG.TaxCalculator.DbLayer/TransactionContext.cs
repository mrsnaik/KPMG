using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using KPMG.TaxCalculator.Model;

namespace KPMG.TaxCalculator.DbLayer
{
    public class TransactionContext : DbContext, ITransactionContext
    {
        public DbSet<Transaction> Transaction { get; set; }


        public void Save()
        {

            this.SaveChanges();

        }


    }
}
