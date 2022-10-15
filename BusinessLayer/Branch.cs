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

        #region data members
        #endregion

        #region data members
        public Branch()
        {
            accountNo = "";
            name = "";
            address = "";
        }
        public Branch(string accountNo,string name,string address)
        {
            this.accountNo = accountNo;
            this.name = name;
            this.address = address;
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
