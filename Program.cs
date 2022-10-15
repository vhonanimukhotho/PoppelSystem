using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using PoppelSystem.BusinessLayer;

namespace PoppelSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            Customer myC= new Customer("0102236014084", "vhonani", "0713686231","Obz Square", "mukhothovhonani23@gmail.com");
            myC.AddBranch("PD Clar", "Claremont");
            myC.AddBranch("PD Town", "Cape Town");
            Console.WriteLine(myC.ToString());
        }
    }
}
