using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelSystem.BusinessLayer
{
    public class Account
    {

        #region data members
        private int accountNo;
        private string accountName, branchID;
        private CreditStatus creditStatus;
        private decimal balance, creditLimit;
        private decimal discountPercent;
 
        public enum CreditStatus {
            None = 0,
            Good = 1,
            Bad = 2
        }

        #endregion

        #region Properties
        public int AccountNo
        {
            get { return accountNo; }
            set { accountNo = value; }
        }

        public string AccountName
        {
            get { return accountName; }
            set { accountName = value; }
        }

        public string BranchID
        {
            get { return branchID; }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public decimal DiscountPercent
        {
            get { return discountPercent; }
            set { discountPercent = value; }
        }

        public CreditStatus GetCreditStatus
        {
            get { return creditStatus; }
            set { creditStatus = value; }
        }

        public decimal CreditLimit
        {
            get { return creditLimit; }
            set { creditLimit = value; }
        }

        #endregion

        #region Constructors
        public Account()
        {
            this.balance = 0;
            this.creditLimit = 0;
            this.discountPercent = 0;
            this.creditStatus = CreditStatus.Good;
            this.branchID = "";
            this.accountName = "";
            this.accountNo = 0;
        }
        public Account(string branchID, string accountName, decimal balance, decimal creditLimit)
        {
            this.accountName = accountName;
            this.branchID = branchID;
            this.balance = balance;
            this.creditLimit = creditLimit;
            this.discountPercent = 0;
            this.creditStatus = CreditStatus.Good;
            this.accountNo = AccountNoGenerator();
        }
        #endregion

        #region account number generator
        private int AccountNoGenerator()
        {
            string acc = "";
            DateTime creationTime = DateTime.Now;

            string y = creationTime.Year.ToString();
            string m = creationTime.Month.ToString();
            string d = creationTime.Day.ToString();
            string h = creationTime.Hour.ToString();
            string mi = creationTime.Minute.ToString();
            string s = creationTime.Second.ToString();
            string mls = creationTime.Millisecond.ToString();

            acc = y + m + d + h + mi + s + mls;
            return Int32.Parse(acc);
        }
        #endregion

        #region To String
        public override string ToString()
        {
            return "Account no: " + accountNo + "Account Name: " + accountName + "Branch ID: " + branchID +
                "Balance :"+ balance+" CreditLimit: "+creditLimit + "DiscountPercent :" + discountPercent;
        }
        #endregion
    }
}
