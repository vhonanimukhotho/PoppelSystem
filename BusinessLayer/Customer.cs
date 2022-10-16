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
        #endregion

        #region Construtors
        public Customer():base()
        {
            customerEmail = "";
            customerID = "";
            registrationDate = DateTime.MinValue;
        }

        public Customer(string idNumber,string customerID, string name, string phone, string address, string customerEmail)
            :base(idNumber, name, phone, address)
        {
            this.customerEmail = customerEmail;
            this.customerID = customerID;
            registrationDate = DateTime.Now;

        }
        #endregion

        #region ToStringMethod
        public override string ToString()
        {
            return "ID: " + ID + '\n' +
                "Name: " + Name + '\n' +
                "Phone: " + Telephone + '\n' +
                "Address: " + Address + '\n' +
                "CustomerID: " + customerID + '\n' +
                "Email: " + customerEmail + '\n' +
                "Registration date: " + registrationDate.ToString();           
        }

        #endregion
    }
}
