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
        private string accountNo, name, address;
        #endregion

        #region  Properties
        public string AccountNo
        {
            get { return accountNo; }
            set { accountNo = value; }
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
        #endregion

        #region Constructors
        public Branch()
        {
            accountNo = "";
            name = "";
            address = "";
        }
        public Branch(string name,string address)
        {
            this.name = name;
            this.address = address;
            this.accountNo = AccountNoGenerator();
        }
        #endregion

        #region account number generator
        private string AccountNoGenerator()
        {
            string acc="";
            DateTime creationTime = DateTime.Now;

            string y = creationTime.Year.ToString();
            string m = creationTime.Month.ToString();
            string d = creationTime.Day.ToString();
            string h = creationTime.Hour.ToString();
            string mi = creationTime.Minute.ToString();
            string s = creationTime.Second.ToString();
            string mls = creationTime.Millisecond.ToString();

            acc = y + m + d + h + mi + s + mls;
            return acc;
        }
        #endregion

        #region To string
        public override string ToString()
        {
            return "Name: " + name + ". Account :" + accountNo + ". Address :" + address;
        }

        #endregion
    }
}
