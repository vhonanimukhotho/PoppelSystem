using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PoppelSystem
{
public class Person
    {

        #region data members
        private string Id, name, Phone, address;
        #endregion

        #region Properties
        public string ID
        {
            get { return Id; }
            set { Id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Telephone
        {
            get { return Phone; }
            set { Phone = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        #endregion

        #region Construtor
        public Person()
        {
            Id = "";
            name = "";
            Phone = "";
            address = "";
        }

        public Person(string pID, string pName, string pPhone, string pAddress)
        {
            Id = pID;
            name = pName;
            Phone = pPhone;
            address = pAddress;
        }
        #endregion

        #region ToStringMethod
        public override string ToString()
        {
            return name + '\n' + Phone + '\n' + address;
        }

        #endregion
    }

}
