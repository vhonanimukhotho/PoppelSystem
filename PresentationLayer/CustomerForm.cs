using PoppelSystem.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoppelSystem.PresentationLayer
{
    public partial class CustomerForm : Form
    {
        #region Data Members
        private Customer customer;
        private CustomerController customerController;
        #endregion

        public CustomerForm()
        {
            InitializeComponent();
        }

        #region Utility Methods
        private void ShowAll(bool value)
        {
            idLabel.Visible = value;
            customerNoLabel.Visible = value;
            nameLabel.Visible = value;
            phoneLabel.Visible = value;
            addressLabel.Visible = value;
            emailLabel.Visible = value;
            regDateLabel.Visible = value;

            idTextBox.Visible = value;
            customerNoTextBox.Visible = value;
            nameTextBox.Visible = value;
            phoneTextBox.Visible = value;
            addressTextBox.Visible = value;
            emailTextBox.Visible = value;
            regDateTimePicker.Visible = value;
            submitButton.Visible = value;
            cancelButton.Visible = value;
        }
        private void ClearAll()
        {
            idTextBox.Text = "";
            customerNoTextBox.Text = "";
            nameTextBox.Text = "";
            phoneTextBox.Text = "";
            addressTextBox.Text = "";
            emailTextBox.Text = "";
            regDateTimePicker.Value = DateTime.Now;
        }

        private void PopulateObject()
        {
            customer = new Customer();
            customer.ID = idTextBox.Text;
            customer.CustomerID = customerNoTextBox.Text;
            customer.Name = nameTextBox.Text;
            customer.Telephone = phoneTextBox.Text;
            customer.Address = addressLabel.Text;
            customer.CustomerEmail = emailTextBox.Text;
            customer.RegistrationDate = regDateTimePicker.Value;
        }

        #endregion

        private void submitButton_Click(object sender, EventArgs e)
        {
            PopulateObject();
            bool done;
            MessageBox.Show("To be submitted to the Database!");
            customerController.DataMaintenance(customer);
            done = customerController.FinalizeChanges(customer);
            if (done)
            {
                MessageBox.Show("Submitted to the Database!");
            }
            else
            {
                MessageBox.Show("Failed to submitted to the Database!");
            }
            
            ClearAll();
            //ShowAll(false);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            ShowAll(false);
            customerController = new CustomerController();
        }

        private void CustomerForm_Activated(object sender, EventArgs e)
        {
            ShowAll(true);
        }
    }
}
