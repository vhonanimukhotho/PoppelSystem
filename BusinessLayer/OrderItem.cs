using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelSystem.BusinessLayer
{
    public class OrderItem
    {
        #region data members
        private string itemID, orderNumber;
        public Product product;
        private int quantity;
        private Account account;
        private Order order;

        #endregion

        #region Properties
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public string ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        public decimal VATconstant
        {
            get { return product.getVAT; }

        }
        public string ProductCode
        {
            get {return product.ProductCode; }
        }
        public string ProductName
        {
            get { return product.ProductName; }
        }
        public decimal ProductPrice
        {
            get {return product.Price; }
        }
        public decimal Discount
        {
            get { return account.DiscountPercent; }
        }

        public Product GetProduct
        {
            get { return this.product; }
        }

        public Account GetAccount
        {
            get { return this.account; }
        }
        #endregion

        #region Constructors
        public OrderItem()
        {
            this.quantity = 0;
            this.product = new Product();
            this.account = new Account();
            this.itemID = "";
            this.order = new Order();
        }

        public OrderItem(string itemID,Order order, Product product, Account account, int quantity)
        {
            this.quantity = quantity;
            this.itemID = itemID;
            this.product = product;
            this.account = account;
            this.order = order;
        }
        #endregion

        #region Get Item Price
        public decimal GetVATAmount()
        {
            return product.Price * product.getVAT;
        }

        public decimal WithoutVAT()
        {
            return product.Price;
        }

        public decimal WithVAT()
        {
            return product.Price + GetVATAmount();
        }

        public decimal ItemDiscount()
        {
            
            if (product.HasVAT)
            {
                return WithVAT() * account.DiscountPercent;
            }
            else
            {
                return WithoutVAT() * account.DiscountPercent;
            }
        }

        public decimal PricePerItem()
        {
            decimal total;
            if (product.HasVAT)
            {
                total = WithVAT() - ItemDiscount();
            }
            else
            {
                total = WithoutVAT()- ItemDiscount();
            }
            return total;
        }

        public decimal TotalDiscountAmount()
        {
            return ItemDiscount() * quantity;
        }

        public decimal TotalBeforeDiscount()
        {
            decimal total;
            if (product.HasVAT)
            {
                total = WithVAT()*quantity;
            }
            else
            {
                total = WithoutVAT()*quantity;
            }
            return total;
        }

        public decimal TotalPrice()
        {
            return PricePerItem() * quantity;
        }
        #endregion

        #region To string
        public override string ToString()
        {
            return product.ToString() + ", Selling Price per Item:"+ PricePerItem() + ", Selling Price "+ TotalPrice() + ", Quantity :"+quantity;
        }
        #endregion
    }
}
