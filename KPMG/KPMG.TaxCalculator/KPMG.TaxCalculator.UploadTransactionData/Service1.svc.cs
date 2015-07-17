using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KPMG.TaxCalculator.UploadTransactionData
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        string _connectionString = "Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aspnet-KPMG.TaxCalculator-20150716012214.mdf;Initial Catalog=aspnet-KPMG.TaxCalculator-20150716012214;Integrated Security=True";
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
            bool success = true;
            try
            {
                string query = "insert into Transactions (account, description, currencyCode, amount) values (" + fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + ")";
                SqlConnection con = new SqlConnection(_connectionString);
                con.Open();
                con.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                success = false;            
            }
            return success;

        }
    }
}
