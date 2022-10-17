using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoppelSystem.BusinessLayer;

namespace PoppelSystem.DatabaseLayer
{
    public class CustomerDB : DB
    {
        #region  Data members 
        private string table1 = "Customer";
        private string sqlLocal1 = "SELECT * FROM Customer";
        private Collection<Customer> customers;
        #endregion

        #region Property Method: Collection
        public Collection<Customer> Allcustomers
        {
            get
            {
                return customers;
            }
        }
        #endregion

        #region Constructor
        public CustomerDB() : base()
        {
            customers = new Collection<Customer>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);
        }
        #endregion

        #region Utility Methods
        public DataSet GetDataSet()
        {
            return dsMain;
        }
        private void Add2Collection(string table)
        {
            //Declare references to a myRow object and a Customer object
            DataRow myRow = null;
            Customer aCust;
            //READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Customer object
                    aCust = new Customer();
                    //Obtain each customer attribute from the specific field in the row in the table
                    aCust.ID = Convert.ToString(myRow["idNumber"]).TrimEnd();
                    aCust.CustomerID = Convert.ToString(myRow["CustomerID"]).TrimEnd();
                    aCust.Name = Convert.ToString(myRow["Name"]).TrimEnd();
                    aCust.Telephone = Convert.ToString(myRow["Phone"]).TrimEnd();
                    aCust.Address = Convert.ToString(myRow["Address"]).TrimEnd();
                    aCust.CustomerEmail = Convert.ToString(myRow["Email"]).TrimEnd();
                    aCust.RegistrationDate = Convert.ToDateTime(myRow["RegistrationDate"]);
                    //anEmp.role.getRoleValue = (Role.RoleType)Convert.ToByte(myRow["Role"]);

                    customers.Add(aCust);
                }
            }
        }
        private void FillRow(DataRow aRow, Customer aCust)
        {
            aRow["idNumber"] = aCust.ID; //Square brackets to indicate index of collections of fields in row.
            aRow["CustomerID"] = aCust.CustomerID;
            aRow["Name"] = aCust.Name;
            aRow["Phone"] = aCust.Telephone;
            aRow["Address"] = aCust.Address;
            aRow["Email"] = aCust.CustomerEmail;
            aRow["RegistrationDate"] = aCust.RegistrationDate;
        }
        #endregion

        #region Database Operations CRUD
        public void DataSetChange(Customer aCust)
        {
            DataRow aRow = null;
            string dataTable = table1;

            aRow = dsMain.Tables[dataTable].NewRow();
            FillRow(aRow, aCust);
            //Add to the dataset
            dsMain.Tables[dataTable].Rows.Add(aRow);
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Customer aCust)
        {
            //Create Parameters to communicate with SQL INSERT...add the input parameter and set its properties.
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@idNumber", SqlDbType.NVarChar,50, "idNumber");
            daMain.InsertCommand.Parameters.Add(param);//Add the parameter to the Parameters collection.

            param = new SqlParameter("@CustomerID", SqlDbType.NVarChar, 50, "CustomerID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Name", SqlDbType.NVarChar, 50, "Name");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 50, "Phone");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Address", SqlDbType.NVarChar, 100, "Address");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Email", SqlDbType.NVarChar, 50, "Email");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@RegistrationDate", SqlDbType.DateTime);
            param.SourceColumn = "RegistrationDate";
            daMain.InsertCommand.Parameters.Add(param);

        }

        private void Create_INSERT_Command(Customer aCust)
        {
            //Create the command that must be used to insert values into the Customer table..
            daMain.InsertCommand = new SqlCommand("INSERT into Customer (idNumber, CustomerID, Name, Phone, Address, Email, RegistrationDate) VALUES (@idNumber, @CustomerID, @Name, @Phone, @Address, @Email, @RegistrationDate)", cnMain);
            Build_INSERT_Parameters(aCust);
        }

        public bool UpdateDataSource(Customer aCust)
        {
            bool success = true;
            Create_INSERT_Command(aCust);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }

        #endregion

    }
}
