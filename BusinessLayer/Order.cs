using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;


namespace PoppelSystem.BusinessLayer
{
    public class Order
    {
        #region data members
        private string orderNumber, deliveryAddress;
        private decimal totalCost, beforeDiscount, discount;
        private DateTime orderDate;
        private Customer customer;
        private Employee employee;
        private Branch branch;
        private Account account;
        private OrderStatus orderStatus;
        private int numberOfItems;


        public enum OrderStatus
        {
            OnHold = 0,
            Processing = 1,
            InTransit = 2,
            Completed = 3
        }
        
        #endregion

        #region Properties
        public string OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }
        public string DeliveryAddress
        {
            get { return deliveryAddress; }
            set { deliveryAddress = value; }
        }
        public decimal TotalCost 
        { 
            get { return totalCost; } 
        }
        public decimal Discount
        {
            get { return discount; }
        }
        public decimal BeforeDiscount
        {
            get { return beforeDiscount; }
        }
        public int NumberOfItems
        {
            get { return numberOfItems; }
        }
        public DateTime OrderDate
        {
            get { return orderDate; }
        }
        public OrderStatus getOrderStatus
        {
            get { return orderStatus; }
            set { orderStatus = value; }
        }
        public Customer GetCustomer
        {
            get { return customer; }
        }
        public Employee GetEmployee
        {
            get { return employee; }
        }
        public Account GetAccount
        {
            get { return account; }
        }

        public Branch GetBranch
        {
            get { return branch; }
        }
        #endregion

        #region Constructor
        public Order()
        {
            orderNumber = "";
            this.customer = new Customer();
            this.employee = new Employee();
            this.branch = new Branch();
            this.account = new Account();
            totalCost = 0;
            discount = 0;
            beforeDiscount = 0;
            orderDate = DateTime.MinValue;
            deliveryAddress = "";
            numberOfItems = 0;
            
        }

        public Order(string orderNo, Customer customer, Employee employee, Branch branch, Account account)
        {
            this.orderNumber = orderNo;
            this.customer = customer;
            this.employee = employee;
            this.branch = branch;
            this.account = account;
            totalCost = 0;
            discount = 0;
            numberOfItems=0;
            beforeDiscount = 0;
            orderDate = DateTime.Now;
            deliveryAddress = branch.Address;
            
        }
        #endregion

        #region Add Items
        public void AddItems(Collection<OrderItem> orderItems)
        {
            numberOfItems = orderItems.Count;

            decimal tempTotal = 0;
            decimal tempDiscount = 0;
            decimal tempBeforeDiscount = 0;
            
            foreach(OrderItem item in orderItems)
            {
                tempTotal = tempTotal + item.TotalPrice();
                tempDiscount = tempDiscount + item.TotalDiscountAmount();
                tempBeforeDiscount = tempBeforeDiscount + item.TotalBeforeDiscount();
            }

            totalCost = tempTotal;
            discount = tempDiscount;
            beforeDiscount = tempBeforeDiscount;
            
        }
        #endregion

        #region To String
        public override string ToString()
        {

            return "---Order Details---\n" +
                "Order number: " + orderNumber + '\n' +
                "Account number: " + account.AccountNo + '\n' +
                "Customer ID: " + customer.CustomerID + '\n' +
                "Branch ID: " + branch.BranchID + '\n' +
                "Number of items: " + numberOfItems + '\n' +
                "BeforeDiscount: " + beforeDiscount + '\n' +
                "Discount: " + discount + '\n' +
                "Total: " + totalCost + '\n' +
                "Order status: " + orderStatus + '\n' +
                "Delivery address: " + deliveryAddress + '\n' +
                "Sales Person: " + employee.Name + " - " + employee.GetRoleVal +
                "Order date: " + orderDate.ToString();
        }
        #endregion
    }
}
