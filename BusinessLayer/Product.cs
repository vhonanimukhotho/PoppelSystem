﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelSystem.BusinessLayer
{
    public class Product
    {
        #region data members
        private string productCode, productName,productSize, productDescription, productCategory;
        private decimal price, VAT;
        private bool hasVAT;
        private DateTime expiryDate;
        #endregion

        #region Properties
        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public string ProductSize
        {
            get { return productSize; }
            set { productSize = value; }
        }

        public string ProductDescription
        {
            get { return productDescription; }
            set { productDescription = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public string ProductCategory
        {
            get { return productCategory; }
            set { productCategory = value; }
        }

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value;}
        }

        public bool HasVAT
        {
            get { return hasVAT; }
            set { hasVAT = value;}
        }

        public decimal getVAT
        {
            get { return VAT; }
            set { VAT = value; }
        }
        #endregion

        #region Constructors
        public Product()
        {
            productCode = "";
            productName = "";
            productDescription = "";
            productCategory = "";
            price = 0;
            hasVAT = false;
            expiryDate = DateTime.MinValue;
            productSize = "";
            VAT = 0;    
        }

        public Product(string productCode, string productName,string productSize, string productDescription, string productCategory, decimal price, bool hasVat, DateTime expiryDate, decimal VAT = 0m)
        {
            this.productCode = productCode;
            this.productName = productName;
            this.productDescription = productDescription;
            this.productCategory = productCategory;
            this.price = price;
            this.hasVAT = hasVat;
            this.expiryDate = expiryDate;
            this.VAT = VAT;
            this.productSize = productSize;
        }
        #endregion

        #region To String
        public override string ToString()
        {
            return "ProductCode :" + productCode + '\n' +
                "ProductName :" + productName + '\n' +
                "ProductDescription :" + productDescription + '\n' +
                "ProductCategory :" + productCategory + '\n' +
                "Price :" + price.ToString() + '\n' +
                "HasVAT :" + hasVAT + '\n' +
                "VAT :" + VAT + '\n' +
                "ExpiryDate :" + expiryDate;
        }
        #endregion
    }
}
