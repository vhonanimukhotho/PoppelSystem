using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelSystem.BusinessLayer
{
    public class Catalogue
    {
        #region data members
        private string catalogueID;
        private Product product;
        private Customer customer;
        private string productCode;
        private string customerID;
        #endregion

        #region Properties
        public string CatalogueID
        {
            get { return catalogueID; }
            set { catalogueID = value; }
        }

        public Product GetProduct
        {
            get { return product; }
        }

        public string ProductCode
        {
            get { return product.ProductCode; }
        }

        public string CustomerID
        {
            get { return customer.CustomerID; }
        }

        public Customer GetCustomer
        {
            get { return customer; }
        }
        #endregion

        #region Constructors
        public Catalogue()
        {
            this.catalogueID = "";
            this.customer = new Customer();
            this.product= new Product();
        }

        public Catalogue(string catalogueID, Product p, Customer c)
        {
            this.catalogueID = catalogueID;
            this.customer = c;
            this.product = p;
        }
        #endregion

        #region To String
        public override string ToString()
        {
            return "CatalogueID: " + catalogueID+"CustomerID: " + customer.CustomerID + ", ProductCode: " + product.ProductCode;
        }
        #endregion


    }
}
