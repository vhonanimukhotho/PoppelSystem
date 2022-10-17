using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoppelSystem.Properties;

namespace PoppelSystem.DatabaseLayer
{
    public class DB
    {
        #region Variable declaration
        #region Define a variable strConn of type string to store the string connection 
        //***Once the database is created you can find the correct connection string by using the Settings.Default object to select the correct connection string
        /* Property
           used to get connection to the database source which is specified in SqlConnection: https://www.c-sharpcorner.com/UploadFile/718fc8/working-with-sqlconnection-and-sqlcommand-class-in-ado-net/
         */
        private string strConn = Settings.Default.PoppelDatabaseConnectionString;
        #endregion

        #region Declare a variable cnMain of type SqlConnection.
        protected SqlConnection cnMain;
        /*SqlConnection
          Represents/initiates a connection to a SQL Server database... handles database connections. 
          The connection tells the rest of the ADO.NET code which database it is talking to        
         A SqlConnection object represents a unique session to a SQL Server data source. 
         https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection?view=dotnet-plat-ext-5.0
         A SqlConnection is an object, just like any other C# object.  Most of the time, you just declare and instantiate the SqlConnection
                    Instantiate the SqlConnection.
                    Open the connection.
                    Pass the connection to other ADO.NET objects.
                    Perform database operations with the other ADO.NET objects.
                    Close the connection.
                    http://csharp-station.com/Tutorial/AdoDotNet/Lesson02
       Two important methods of SqlConnection will be used:
         Open() : The open() method  is used to open the Database connection.
         Close() : The close() method is used to close the Database connection.
         https://www.c-sharpcorner.com/UploadFile/718fc8/working-with-sqlconnection-and-sqlcommand-class-in-ado-net/
        */
        #endregion

        #region Declare a variable dsMain of type DataSet
        protected DataSet dsMain;
        /* Data set
         Represents an in-memory cache of data. https://docs.microsoft.com/en-us/dotnet/api/system.data.dataset?view=net-5.0
         It represent records in the form of Database table (Row and Column) format. 
         It stores record of one or more tables https://www.c-sharpcorner.com/UploadFile/718fc8/working-with-dataset-and-its-methods-in-ado-net/
         The DataSet represents a complete set of data that includes tables, constraints, and relationships
         among the tables. Because the DataSet is independent of the data source, a DataSet can 
         include data local to the application, and data from multiple data sources. https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/populating-a-dataset-from-a-dataadapter
         */
        #endregion

        #region Declare a variable daMain of type SqlDataAdapter
        protected SqlDataAdapter daMain;
        /*Data Adapter
         DataAdapter serves as a bridge between a DataSet and a data source for retrieving and saving data.
         The Fill operation then adds the rows to destination DataTable objects in the DataSet, 
         creating the DataTable objects if they do not already exist.
         The Fill method retrieves rows from the data source using the SELECT statement specified 
         by an associated SelectCommand property. 
         DataAdapter adds or refreshes rows in the DataSet to match those in the data source using 
         the DataSet name, and creates a DataTable named "Table". 
         http://net-informations.com/csprj/dataadapter/cs-dataAdapter-fill.htm
         //https://www.c-sharpcorner.com/uploadfile/61b832/sqldataadapter-fill-method/
         */
        #endregion

        #endregion

        #region Constructor
        public DB()
        {
            try
            {
                //Open a connection & create a new dataset object
                cnMain = new SqlConnection(strConn);// A SqlConnection is an object, just like any other C# object
                dsMain = new DataSet();
            }
            catch (SystemException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Error");
                return;
            }
        }
        #endregion

         #region Fills dataset fresh from the db for a specific table and with a specific Query        
        public void FillDataSet(string aSQLstring, string aTable)
        {// The method receives two parameters: the SQL statement aSQLstring and the Table from which the query will emanate from.Within this method:

            try
            {
                daMain = new SqlDataAdapter(aSQLstring, cnMain);// Create an instance of the data adapter (daMain). 
                cnMain.Open();// Opens a database connection with the property settings specified by the ConnectionString.  https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection.open?view=dotnet-plat-ext-5.0      
                              //https://www.c-sharpcorner.com/UploadFile/201fc1/sql-server-database-connection-in-csharp-using-adonet/
                dsMain.Clear();//This method clears (removes) all rows from a DataSet. 
                               //https://www.c-sharpcorner.com/UploadFile/718fc8/working-with-dataset-and-its-methods-in-ado-net/
                daMain.Fill(dsMain, aTable);//Adds or refreshes rows in the DataSet to match those in the data source. https://docs.microsoft.com/en-us/dotnet/api/system.data.common.dataadapter.fill?view=net-5.0
                                                   //is used to populate a DataSet with the results of the SelectCommand of the DataAdapter.
                                                   //Fill takes as its arguments a DataSet to be populated, and a DataTable object, or the name of the DataTable to be filled with the rows returned from the SelectCommand. https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/populating-a-dataset-from-a-dataadapter

                cnMain.Close();//close the connection
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);//https://docs.microsoft.com/en-us/dotnet/api/system.exception.stacktrace?view=net-5.0
            }
        }
        #endregion

        #region Update the data source 
        protected bool UpdateDataSource(string sqlLocal, string table)
        { //The method has two parameters SQL statement to be used to do the update and the table which needs to be updated.
            bool success;//Declare a Boolean variable success that will signal the successful update
            try
            {

                cnMain.Open();   // open the connection

                #region Update the database table via the data adapter
                daMain.Update(dsMain, table);
                /*
                 The Update method of the DataAdapter is called to resolve changes from a DataSet
                 back to the data source. The Update method, like the Fill method, takes as arguments
                 an instance of a DataSet, and an optional DataTable object or DataTable name.
                 When you call the Update method, the DataAdapter analyzes the changes that have been made and
                 executes the appropriate command (INSERT, UPDATE, or DELETE). When the DataAdapter encounters a 
                 change to a DataRow, it uses the InsertCommand, UpdateCommand, or DeleteCommand to process the change. 
                 */

                #endregion

                cnMain.Close(); // close the connection

                #region  Fill the dataset with the SQL statement sqlLocal and the specific table table
                FillDataSet(sqlLocal, table); //refresh the dataset using the SQL statement; and the Table from which the query will emanate from
                #endregion

                success = true;// The variable success returns true (Assign true to the variable success).
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
                success = false;
            }
            finally
            {
            }
            return success;
        }
        #endregion

    }
}
