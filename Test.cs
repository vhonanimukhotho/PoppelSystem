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
        private Collection<Account> accountDB;
        private Collection<Branch> branchDB;
        private Collection<Catalogue> catalogueDB;
        private Collection<Customer> customerDB;
        private Collection<Employee> employeeDB;
        private Collection<Order> orderDB;
        private Collection<OrderItem> orderItemDB;
        private Collection<Product> productDB;
        private Collection<Stock> stockDB;

        public Test()
        {
            accountDB = new Collection<Account>();
            branchDB = new Collection<Branch>();
            catalogueDB = new Collection<Catalogue>();
            customerDB = new Collection<Customer>();
            employeeDB = new Collection<Employee>();
            orderDB = new Collection<Order>();
            orderItemDB = new Collection<OrderItem>();
            productDB = new Collection<Product>();
            stockDB = new Collection<Stock>();
            Storage();
            inputMethod();

        }
        public void Storage()
        {
            /**************** Customer - Branc - Account ******************/
            Customer c1 = new Customer("0102236014084","PPL1", "vhonani", "0713686231", "Obz Square", "mukhothovhonani23@gmail.com");
            Customer c2 = new Customer("0303970880082","PPL2", "christopher", "0713686231", "Forest Hill", "MKHVHO002@myuct.ac.za");
            customerDB.Add(c1);
            customerDB.Add(c2);

            Branch c1Branch1 = new Branch("B1",c1.CustomerID, "PD Clar", "Claremont");
            Account c1Account1 = new Account(515151,c1Branch1.BranchID,c1Branch1.Name,700,1000);

            Branch c2Branch1 = new Branch("B2",c2.CustomerID, "UCT upper", "Rondebosch");
            Account c2Account1 = new Account(525252,c2Branch1.BranchID,c2Branch1.Name,4500,1000);
            Branch c2Branch2 = new Branch("B2",c2.CustomerID, "UCT middle", "Mowbray");
            Account c2Account2 = new Account(535353,c2Branch2.BranchID,c2Branch2.Name, 1869,1000);

            branchDB.Add(c1Branch1);
            branchDB.Add(c2Branch1);
            branchDB.Add(c2Branch2);

            accountDB.Add(c1Account1);
            accountDB.Add(c2Account1);
            accountDB.Add(c2Account2);
  
            /**************** Products *******************/
            Product p1 = new Product("ML0021","coke","2 litre","black and sweet","drink",21,true,new DateTime(2022,12,31));
            Product p2 = new Product("HE003", "fanta orange","2 litre" ,"orange, colorful and sweet", "drink", 24, true, new DateTime(2022, 11, 25));
            Product p3 = new Product("3", "sprite","2 litre", "carbonated,colourless and sweet", "drink", 28, false, new DateTime(2023, 2, 5));
            Product p4 = new Product("4", "stoney","2 litre", "peri peri and sweet", "drink", 21, false, new DateTime(2022, 7, 29));
            productDB.Add(p1);
            productDB.Add(p2);
            productDB.Add(p3);
            productDB.Add(p4);

            /************** Catalogue *****************/
            Catalogue cat1 = new Catalogue("CAT1",p1,c1);
            Catalogue cat2 = new Catalogue("CAT2", p1,c1);
            catalogueDB.Add(cat1);
            catalogueDB.Add(cat2);

            /*************     Stock      ***************/
            Stock s1 = new Stock("ST1",p1.ProductCode, "A4", 150);
            Stock s2 = new Stock("ST2",p2.ProductCode, "J7", 5691);
            Stock s3 = new Stock("ST3",p3.ProductCode, "A2", 41);
            Stock s4 = new Stock("ST4",p4.ProductCode, "F1", 89);
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
            Employee employee1 = new Employee("EP005","79125592302884", "Mrs Ples", "08245785425", "Table View", "ples@poppel.com");
            employee1.GetRoleVal = Employee.RoleType.MarkertingDirector;
            employeeDB.Add(employee1);
            /************************************************/

            /******** check customer details ********/
            string adminNo = "EP005";
            string customerNo = "PPL1";
            int accountNo = 515151;
            string customerName = "vhonani";
            Customer customer = null;
            Employee employee = null;

            bool employeeFound = false;
            foreach (Employee emp in employeeDB)
            {
                if (emp.EmployeeID.Equals(adminNo))
                {
                    employee = emp;
                    employeeFound = true;
                }
            }
            if (!employeeFound)
            {
                // sales rep not found in the employee database
            }

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
            bool goodCredit = false;
            Branch branch = null;
            Account account = null;
            foreach(Branch b in branchDB)
            {
                if (b.CustomerID.Equals(customerNo)) //branches that belong to the customer
                {
                    foreach(Account acc in accountDB)
                    {
                        if (acc.AccountNo==accountNo) // account match
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
           

            string productCode1 = "ML0021";
            int product1Qty = 30;
            foreach(Product p in productDB)
            {
                if (p.ProductCode.Equals(productCode1))
                {
                    OrderItem ordIt = new OrderItem("OT1",order,p,account,product1Qty);
                    orderItemDB.Add(ordIt);
                }
            }

            string productCode2 = "HE003";
            int product2Qty = 10;
            foreach (Product p in productDB)
            {
                if (p.ProductCode.Equals(productCode2))
                {
                    OrderItem ordIt = new OrderItem("OT2", order, p, account, product2Qty);
                    orderItemDB.Add(ordIt);
                }
            }

            // update order
            order.AddItems(orderItemDB);

            orderDB.Add(order);

            Console.WriteLine(order.ToString());
            

        }
    }
}
