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
        #endregion

        #region Constructors
        public Employee(): base()
        {
            roleVal = RoleType.none;
        }

        public Employee(string id, string name, string phone, string address):
            base(id,name,phone,address)
        {
            roleVal = RoleType.none;
        }
        #endregion

        #region To String
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

    }
}
