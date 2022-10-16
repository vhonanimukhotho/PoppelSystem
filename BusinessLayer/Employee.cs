using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelSystem.BusinessLayer
{
    public class Employee : Person
    {
        #region data members
        private string employeeID,email;
        private RoleType roleVal;

        public enum RoleType{
            none = 0,
            MarkertingDirector = 1,
        }
        #endregion

        #region Properties
        public RoleType GetRoleVal {
            get { return roleVal; }
            set { roleVal = value; }
        }

        public string EmployeeID
        {
            get { return employeeID; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        #endregion

        #region Constructors
        public Employee(): base()
        {
            roleVal = RoleType.none;
            employeeID = "";
            email = "";
        }

        public Employee(string employeeID,string idNumber, string name, string phone, string address, string email):
            base(idNumber,name,phone,address)
        {
            roleVal = RoleType.none;
            this.employeeID = employeeID;
            this.email = email;
        }
        #endregion

        #region To String
        public override string ToString()
        {
            return "EmployeeID: "+ employeeID+", " + base.ToString() + "Email :"+ email;
        }
        #endregion

    }
}
