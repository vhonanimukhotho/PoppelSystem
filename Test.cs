using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PoppelSystem.BusinessLayer;

namespace PoppelSystem
{
    public class Test
    {
        
        private Collection<Customer> customerDB;
        private Collection<Product> productDB;
        private Collection<Stock> stockDB;
        private Collection<Order> orderDB;
        private Collection<Catalogue> catalogueDB;
        private Collection<Branch> branchDB;
        private Collection<Account> accountDB;

        public Test()
        {
            productDB = new Collection<Product>();
            customerDB = new Collection<Customer>();
            stockDB = new Collection<Stock>();
            orderDB = new Collection<Order>();
            catalogueDB = new Collection<Catalogue>();
            branchDB = new Collection<Branch>();
            accountDB = new Collection<Account>();

            Storage();
            inputMethod();

        }
        public void Storage()
        {
            /**************** Customer - Branc - Account ******************/
            Customer c1 = new Customer("0102236014084", "vhonani", "0713686231", "Obz Square", "mukhothovhonani23@gmail.com");
            Customer c2 = new Customer("0303970880082", "christopher", "0713686231", "Forest Hill", "MKHVHO002@myuct.ac.za");
            customerDB.Add(c1);
            customerDB.Add(c2);

            Branch c1Branch1 = new Branch(c1.CustomerID, "PD Clar", "Claremont");
            Account c1Account1 = new Account(c1Branch1.BranchID,c1Branch1.Name,700);

            Branch c2Branch1 = new Branch(c2.CustomerID, "UCT upper", "Rondebosch");
            Account c2Account1 = new Account(c2Branch1.BranchID,c2Branch1.Name,4500);
            Branch c2Branch2 = new Branch(c2.CustomerID, "UCT middle", "Mowbray");
            Account c2Account2 = new Account(c2Branch2.BranchID,c2Branch2.Name, 1869);

            c2Account2.AccountNo = "123456789";
            branchDB.Add(c1Branch1);
            branchDB.Add(c2Branch1);
            branchDB.Add(c2Branch2);

            accountDB.Add(c1Account1);
            accountDB.Add(c2Account1);
            accountDB.Add(c2Account2);
  
            /**************** Products *******************/
            Product p1 = new Product("ML0021","coke","black and sweet","drink",21,true,new DateTime(2022,12,31));
            Product p2 = new Product("HE003", "fanta orange", "orange, colorful and sweet", "drink", 24, true, new DateTime(2022, 11, 25));
            Product p3 = new Product("3", "sprite", "carbonated,colourless and sweet", "drink", 28, false, new DateTime(2023, 2, 5));
            Product p4 = new Product("4", "stoney", "peri peri and sweet", "drink", 21, false, new DateTime(2022, 7, 29));
            productDB.Add(p1);
            productDB.Add(p2);
            productDB.Add(p3);
            productDB.Add(p4);

            /************** Catalogue *****************/
            Catalogue cat1 = new Catalogue("Top level");
            Catalogue cat2 = new Catalogue("Middle level");
            catalogueDB.Add(cat1);
            catalogueDB.Add(cat2);

            /*************     Stock      ***************/
            Stock s1 = new Stock(p1.ProductCode, "A4", 150);
            Stock s2 = new Stock(p2.ProductCode, "J7", 5691);
            Stock s3 = new Stock(p3.ProductCode, "A2", 41);
            Stock s4 = new Stock(p4.ProductCode, "F1", 89);
            stockDB.Add(s1);
            stockDB.Add(s2);
            stockDB.Add(s3);
            stockDB.Add(s4);
        }

        public void inputMethod()
        {
            /**********    ORDERING Form    ******************
             * customerNo = "PPL0102236014084"               *
             * customerName = "vhonani"                      *
             * accountNo = "123456789"                       *
             *                                               *
             * productCode1 = "ML0021"  product1Qty = 30     *
             * productCode2 = "HE003"   product2Qty = 10     *
             *                                               *
             *************************************************/


            /***************      admin details*****************************/
            Customer customer = null; ;
            Employee employee = new Employee("79125592302884", "Mrs Ples", "08245785425", "Table View");
            employee.GetRoleVal = Employee.RoleType.MarkertingDirector;
            /************************************************/

            /******** check customer details ********/
            string customerNo = "PPL0102236014084";
            string customerName = "vhonani";
            
            bool customerFound = false;
            foreach (Customer c in customerDB)
            {
                if (c.CustomerID.Equals(customerNo))
                {
                    customer = c;
                    customerFound = true;
                }
            }

            if (!customerFound)
            {
                //create customer
            }
            /********************   end   **************************/

            /************* check credit status ***************/
            string accountNo = "123456789";
            bool goodCredit = false;
            Branch branch = null;
            Account account = null;
            foreach(Branch b in branchDB)
            {
                if (b.CustomerID.Equals(customerNo)) //branches that belong to the customer
                {
                    foreach(Account acc in accountDB)
                    {
                        if (acc.AccountNo.Equals(accountNo)) // account match
                        {
                            branch = b;
                            account = acc;
                            if (acc.GetCreditStatus == Account.CreditStatus.Good)// credit checker
                            {
                                goodCredit = true;
                            }
                            break;
                        }
                    }
                }
            }
            /****************   end   *****************/

            /************* Add Create Order ***************/
            account.DiscountPercent=0.0m;        
            Order order = new Order("20010223",customer,employee,branch,account);
            /*********************************************************************/

            /******** Add items ***************/
            Product product1 = null;
            Product product2 = null;

            string productCode1 = "ML0021";
            int product1Qty = 30;
            foreach(Product p in productDB)
            {
                if (p.ProductCode.Equals(productCode1))
                {
                    order.AddItem(new OrderItem("i1", p, account, product1Qty));
                }
            }

            string productCode2 = "HE003";
            int product2Qty = 10;
            foreach (Product p in productDB)
            {
                if (p.ProductCode.Equals(productCode2))
                {
                    order.AddItem(new OrderItem("i2", p, account, product2Qty));
                }
            }

            Console.WriteLine(order.ToString());
            

        }
    }
}
