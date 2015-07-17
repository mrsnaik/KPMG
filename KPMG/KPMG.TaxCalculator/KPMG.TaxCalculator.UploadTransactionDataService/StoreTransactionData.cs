using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KPMG.TaxCalculator.UploadTransactionDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StoreTransactionData : IStoreTransactionData
    {
        private readonly string _connectionString;

        public StoreTransactionData()
        {
               _connectionString = "Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aspnet-KPMG.TaxCalculator-20150716012214.mdf;Initial Catalog=aspnet-KPMG.TaxCalculator-20150716012214;Integrated Security=True";
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public bool SaveTransactionData(string[] fields)
        {
            bool success = false;
            string query = "insert into Transactions (account, description, currencyCode, amount) values (" + fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + ")";
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            con.ConnectionString = _connectionString;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
    
            return success;
        }
    }
}
