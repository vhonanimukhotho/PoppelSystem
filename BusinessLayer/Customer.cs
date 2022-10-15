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

        #region Construtor
        public Customer():base()
        {
            customerID = "";
            customerID = "";
            registrationDate = DateTime.MinValue;
        }

        public Customer(string id, string name, string phone, string address, string customerEmail)
            :base(id, name, phone, address)
        {
            this.customerEmail = customerEmail;
            customerID = "PPL" + id;
            registrationDate = DateTime.Now;

        }
        #endregion

        #region Add branch
        public void addBranch(Branch b)
        {
            branches.Add(b);
        }
        #endregion

        #region delete branch
        public void deleteBranch(Branch b)
        {
            branches.Remove(b);
        }
        #endregion

        #region ToStringMethod
        public override string ToString()
        {
            string branchesStr = "";
            foreach (Branch b in branches)
            {
               branchesStr = branchesStr +" [ " + b.ToString() +" ] ";
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
