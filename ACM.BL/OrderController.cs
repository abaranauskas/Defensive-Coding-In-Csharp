using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class OrderController
    {
        public OrderController()
        {
            customerRepository = new CustomerRepository();
            orderRepository = new OrderRepository();
            inventoryRepository = new InventoryRepository();
            emailLibrary = new EmailLibrary();
        }

        public void PlaceOrder(Customer customer,
                               Order order,                               
                               Payment payment,
                               bool allowSplitOrders,
                               bool receiptRequest)
        {            
            customerRepository.Add(customer);            
            orderRepository.Add(order);           
            inventoryRepository.OrderItems(order, allowSplitOrders);

            payment.ProcessPayment();

            if (receiptRequest)
            {
                customer.ValidateEmail();
                customerRepository.Update();
                
                emailLibrary.SendEmail(customer.EmailAddress, "Cia yra Receipt");
            }
        }

        private CustomerRepository customerRepository { get; set; }
        private OrderRepository orderRepository { get; set; }
        private InventoryRepository inventoryRepository { get; set; }
        private EmailLibrary emailLibrary { get; set; }
    }
}
