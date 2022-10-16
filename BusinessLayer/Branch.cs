using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PoppelSystem.BusinessLayer
{
    public class Branch
    {

        #region data members
        private string branchID, customerID, name, address;
        #endregion

        #region  Properties
        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string BranchID
        {
            get { return branchID; }
            set { branchID = value; }
        }
        #endregion

        #region Constructors
        public Branch()
        {
            customerID = "";
            name = "";
            address = "";
            branchID = "";
        }
        public Branch(string branchID, string customerID, string name,string address)
        {
            this.customerID = customerID;
            this.name = name;
            this.address = address;
            this.branchID = branchID;
        }
        #endregion

        #region To string
        public override string ToString()
        {
            return "CustomerID: " + customerID + "Name: " + name + ". Address :" + address;
        }

        #endregion
    }
}
