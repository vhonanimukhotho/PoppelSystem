using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PoppelSystem.BusinessLayer
{
    public class Customer : Person
    {
        #region data members
        private string customerID, customerEmail;
        private DateTime registrationDate;
        private Collection<Branch> branches;
        #endregion

        #region  Properties
        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string CustomerEmail
        {
            get { return customerEmail; }
            set { customerEmail = value; }
        }

        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set { registrationDate = value; }
        }

        public Collection<Branch> AllBranches
        {
            get
            {
                return branches;
            }
        }
        #endregion

        #region Construtors
        public Customer():base()
        {
            customerID = "";
            customerID = "";
            registrationDate = DateTime.MinValue;
            branches = new Collection<Branch>();
        }

        public Customer(string id, string name, string phone, string address, string customerEmail)
            :base(id, name, phone, address)
        {
            this.customerEmail = customerEmail;
            customerID = "PPL" + id;
            registrationDate = DateTime.Now;
            branches = new Collection<Branch>();

        }
        #endregion

        #region Add branch
        public bool AddBranch(string bName, string bAddress)
        {
            branches.Add(new Branch(bName,bAddress));
            return true;
        }
        #endregion

        #region delete branch
        public bool DeleteBranch(string accountNo)
        {
            if (branches != null)
            {
                foreach (Branch b in branches)
                {
                    if (b.AccountNo.Equals(accountNo))
                    {
                        branches.Remove(b);
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region ToStringMethod
        public override string ToString()
        {
            string branchesStr = "";
            if(branches != null) { 
                foreach (Branch b in branches)
                {
                   branchesStr = branchesStr +" [ " + b.ToString() +" ] ";
                }
            }

            return "ID: " + ID + '\n'+
                "Name: " + Name + '\n' +
                "Phone: " + Telephone + '\n' +
                "Address: " + Address + '\n' +
                "CustomerID: " + customerID + '\n' +
                "Email: " + customerEmail + '\n' +
                "Registration date: " + registrationDate.ToString() + '\n' +
                "Braches: "+ branchesStr;
               
           
        }

        #endregion
    }
}
