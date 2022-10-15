using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelSystem.BusinessLayer
{
    public class Stock
    {
        #region data members
        private string productCode, binAddress;
        private int quantity;
        private int threshold = 0;
        #endregion

        #region Properties
        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string BinAddress
        {
            get { return binAddress; }
            set { binAddress = value; }
        }

        public int Threshold
        {
            get { return threshold; }
            set { threshold = value; }
        }
        #endregion

        #region Constructors
        public Stock()
        {
            productCode = "";
            binAddress = "";
            quantity = 0;
        }

        public Stock(string productCode, string binAddress, int quantity)
        {
            this.productCode = productCode;
            this.binAddress = binAddress;
            this.quantity = quantity;
        }
        #endregion

        #region update stock
        public void AddQuantity(int amount)
        {
            quantity = quantity + amount;
        }

        public void RemoveQuantity(int amount)
        {
            quantity = quantity - amount;
            if (quantity < 0)
            {
                quantity = 0;
            }
        }
        #endregion

        #region Low stock level
        public bool isLow()
        {
            return quantity < threshold;
        }
        #endregion

        #region To string
        public override string ToString()
        {
            return "ProductCode :" + productCode + ", BinAddress :" + binAddress + ", Quantity: " + quantity.ToString() + ", StockLevel: " + isLow();
        }
        #endregion 
    }
}
