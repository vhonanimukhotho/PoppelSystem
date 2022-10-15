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
        private string itemID;
        public Product product;
        private int quantity;
        private Account account;
        private decimal VAT=0.15M;
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
            get { return VAT; }
            set { VAT = value; }
        }
        #endregion

        #region Constructors
        public OrderItem()
        {
            this.quantity = 0;
            this.product = new Product();
            this.account = new Account();
            this.itemID = "";
        }

        public OrderItem(string itemID, Product product, Account account, int quantity)
        {
            this.quantity = quantity;
            this.itemID = itemID;
            this.product = product;
            this.account = account;
        }
        #endregion

        #region Get Item Price
        public decimal GetVATAmount()
        {
            return product.Price * VAT;
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
                return WithVAT() * account.DiscountPercent*quantity;
            }
            else
            {
                return product.Price * account.DiscountPercent*quantity;
            }
        }

        public decimal PricePerItem()
        {
            decimal total = product.Price;
            if (product.HasVAT)
            {
                decimal tempTotal = WithVAT();
                decimal discountAmount = tempTotal * account.DiscountPercent;
                total = tempTotal - discountAmount;
            }
            else
            {
                decimal tempTotal = WithoutVAT();
                decimal discountAmount = account.DiscountPercent;
                total = tempTotal - discountAmount;
            }
            return total;
        }

        public decimal Price()
        {
            return PricePerItem() * quantity;
        }
        #endregion

        #region To string
        public override string ToString()
        {
            return product.ToString() + ", Selling Price per Item:"+ PricePerItem() + ", Selling Price "+Price()+", Quantity :"+quantity;
        }
        #endregion
    }
}
