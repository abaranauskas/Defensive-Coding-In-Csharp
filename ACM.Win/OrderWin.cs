using System;
using System.Windows.Forms;
using ACM.BL;

namespace ACM.Win
{
    public partial class OrderWin : Form
    {       

        private void button1_Click_1(object sender, EventArgs e)
        {
            Button button = sender as Button; //geresnis budas castinti ((Button).sender).Metodas()
            //nes jei nei pakeisti tipo tada nemes exception o padarys default value null tada 
            //bus galima tikrint per if ir pan. kai naudojasmas as visada naudoti if for null

            if (button!=null)
            {
                button.Text = "Processing ...";
            }
                       

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
            //popilate order instance// cia per UI 

            //var allowSplitOrders = true;           
            //var receiptRequest = true;
            // per UI

            var payment = new Payment();
            //per UI

           

            var orderController = new OrderController();
            //orderController.PlaceOrder(customer, order, payment, allowSplitOrders, receiptRequest);

            try
            {
                orderController.PlaceOrder(customer, order, payment,
                               allowSplitOrders: true,
                               receiptRequest: false);
                                //pagerina kodo skaityma
            }
            catch (ArgumentNullException ex)
            {
                //log yhe issue 
                //display a message for usser kad order nesekmingas                
            }

           
        }

    }
}
