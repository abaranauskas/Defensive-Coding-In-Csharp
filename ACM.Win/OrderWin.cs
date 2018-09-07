using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACM.BL;
using Core.Common;

namespace ACM.Win
{
    public partial class OrderWin : Form
    {       

        private void button1_Click_1(object sender, EventArgs e)
        {
            PlaceOrder();

        }

        private void PlaceOrder()
        {
            var customer = new Customer()
            {   //cia turetu but ivedama per UI
                CustomerId = 1,
                FirtName = "Adas",
                LastName = "Baranauskas",
                EmailAddress = "baranauskas.aidas@gmail.com"
            };

            var order = new Order();
            //pupilate order instance// cia per UI 

            //var allowSplitOrders = true;
            //per UI

            var payment = new Payment();
            //per UI

            //var receiptRequest = true;
            // per UI

            var orderController = new OrderController();
            //orderController.PlaceOrder(customer, order, payment, allowSplitOrders, receiptRequest);
            orderController.PlaceOrder(customer, order, payment, 
                allowSplitOrders:true,
                receiptRequest:false);
            //pagerina kodo skaityma
        }

    }
}
