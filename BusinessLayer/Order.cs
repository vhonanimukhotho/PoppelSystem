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
        private decimal totalCost, discount;
        private DateTime orderDate;
        private Collection<OrderItem> orderItems;
        private Customer customer;
        private Employee employee;
        private Branch branch;
        private Account account;
        protected OrderStatus orderStatus;

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
            set { totalCost = value; } 
        }
        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public DateTime OrderDate
        {
            get { return orderDate; }
        }
        public Collection<OrderItem> AllOrderItems
        {
            get
            {
                return orderItems;
            }
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
            orderNumber = string.Empty;
            this.customer = new Customer();
            this.employee = new Employee();
            this.branch = new Branch();
            this.account = new Account();
            totalCost = 0;
            discount = 0;
            orderDate = DateTime.MinValue;
            deliveryAddress = "";
            orderItems = new Collection<OrderItem>();

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
            orderDate = DateTime.Now;
            deliveryAddress = branch.Address;
            orderItems = new Collection<OrderItem>();
        }
        #endregion

        #region Add item
        public void AddItem(OrderItem ordItem)
        {
 
            orderItems.Add(ordItem);
        }
        #endregion

        #region Remove item
        public void RemoveItem(OrderItem ordItem)
        {
            foreach (OrderItem orderItem in orderItems)
            {
                if (ordItem.ItemID==orderItem.ItemID)
                {
                    orderItems.Remove(ordItem);
                    break;
                }
            }
        }
        #endregion

        #region Get Total
        public decimal Total()
        {
            decimal total = 0;
            foreach (OrderItem orderItem in orderItems) {
                total = total + orderItem.Price();
            }
            return total-discount;
        }
        #endregion

        #region Get discount
        public decimal GetDiscount()
        {
            decimal total = 0;
            foreach (OrderItem orderItem in orderItems)
            {
                total = total + orderItem.ItemDiscount();
            }
            return total+discount;
        }
        #endregion

        #region To String
        public override string ToString()
        {
            string items = "";
            foreach(OrderItem orderItem in orderItems)
            {
                items = items +" [ "+ orderItem.ToString()+" ] ";
            }

            return "---Order Details---\n" +
                "Order number: " + orderNumber + '\n' +
                "Delivery address: " + deliveryAddress + '\n' +
                "Total: " + Total() + '\n' +
                "Discount: " + GetDiscount() + '\n' +
                "Order date: " + orderDate.ToString() + '\n' +
                "Customer name: " + customer.Name + '\n' +
                "Branch name: " + branch.Name + '\n' +
                "Account number: " + account.AccountNo + '\n' +
                "Order status: " + orderStatus + '\n' +
                "Order items: " + items +'\n'+
                "Assited by: " + employee.Name + " - " + employee.GetRoleVal;
                
        }
        #endregion
    }
}
