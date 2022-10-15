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
        private string name;
        private Collection<Customer> entitledCustomers;
        private Collection<Product> products;
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Collection<Customer> GetAllEntitledCustomers
        {
            get { return entitledCustomers; }
        }

        public Collection<Product> GetAllProducts
        {
            get { return products; }
        }
        #endregion

        #region Constructors
        public Catalogue()
        {
            this.name = "";
            this.entitledCustomers = new Collection<Customer>();
            this.products = new Collection<Product>();
        }

        public Catalogue(string name)
        {
            this.name = name;
            this.entitledCustomers = new Collection<Customer>();
            this.products = new Collection<Product>();
        }
        #endregion

        #region Entitlement
        public void AddEntitledCustomer(Customer c)
        {
            entitledCustomers.Add(c);
        }

        public void RemoveEntitledCustomer(Customer c)
        {
            foreach(Customer customer in entitledCustomers)
            {
                if (customer.CustomerID.Equals(c.CustomerID))
                {
                    entitledCustomers.Remove(customer);
                }
            }
        }

        public bool isEntitled(Customer c)
        {
            foreach (Customer customer in entitledCustomers)
            {
                if (customer.CustomerID.Equals(c.CustomerID))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region To String
        #endregion


    }
}
