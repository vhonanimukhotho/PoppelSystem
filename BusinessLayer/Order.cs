using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;


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

        public enum OrderStatus
        {
            OnHold = 0,
            Headwaiter = 1,
            Waiter = 2,
            Runner = 3
        }
        protected OrderStatus orderStatus;
        #endregion

        #region Properties
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
        #endregion

        #region Constructor
        public Order()
        {
            orderNumber = string.Empty;
            totalCost = 0;
            discount = 0;
            orderDate = DateTime.MinValue;
        }

        public Order()
        {

        }
        #endregion
    }
}
