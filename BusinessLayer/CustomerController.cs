using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoppelSystem.DatabaseLayer;

namespace PoppelSystem.BusinessLayer
{
    public class CustomerController
    {
        #region Data Members
        CustomerDB customerDB;
        Collection<Customer> customers;
        #endregion

        #region Constructor
        public CustomerController()
        {
            //***instantiate the CustomerDB object to communicate with the database
            customerDB = new CustomerDB();
            customers = customerDB.Allcustomers;
        }
        #endregion

        #region Database Communication.
        public void DataMaintenance(Customer aCust)
        {
            //perform a given database operation to the dataset in memory;
            customerDB.DataSetChange(aCust);
            customers.Add(aCust);
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Customer aCust)
        {
            //***call the EmployeeDB method that will commit the changes to the database
            return customerDB.UpdateDataSource(aCust);
        }
        #endregion
    }
}
