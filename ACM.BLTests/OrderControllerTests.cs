using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common;

namespace ACM.BLTests
{
    [TestClass()]
    public class OrderControllerTests
    {
        [TestMethod()]
        public void PlaceOrderTest()
        {
            //Arrage
            var orderController = new OrderController();
            var customer = new Customer() {EmailAddress="baranauskas.aidas@gmail.com" };
            var order = new Order();
            var payment = new Payment() { PaymentType = 1 };
            var allowSplitOrder = true;
            var receipRequest = true;

            //Act
            OperationResult op = orderController.PlaceOrder(customer, order, payment, allowSplitOrder, receipRequest);

            //Assert
            Assert.AreEqual(true, op.Success);
            Assert.AreEqual(0, op.MessageList.Count);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrderTestNullCustomer()
        {
            //Arrage
            var orderController = new OrderController();
            Customer customer = null;
            var order = new Order();
            var payment = new Payment() { PaymentType = 1 };

            //Act
            OperationResult op = orderController.PlaceOrder(customer, order, payment, allowSplitOrders: true, receiptRequest: true);

            //Assert
            
        }

        [TestMethod()]
        public void PlaceOrderTestISValidEmail()
        {
            //Arrage
            var orderController = new OrderController();
            var customer = new Customer() { EmailAddress = "" };
            var order = new Order();
            var payment = new Payment() { PaymentType = 1 };
            var allowSplitOrder = true;
            var receipRequest = true;

            //Act
            OperationResult op = orderController.PlaceOrder(customer, order, payment, allowSplitOrder, receipRequest);

            //Assert
            Assert.AreEqual(true, op.Success);  //nes construktoriuje nustatem true o kur is vlidate 
            //operationResult turi false neperstatom
            Assert.AreEqual(1, op.MessageList.Count);
            Assert.AreEqual("Email is null Aidai", op.MessageList[0]);
        }
    }
}