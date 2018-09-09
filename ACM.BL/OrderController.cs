using Core.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public OperationResult PlaceOrder(Customer customer,
                               Order order,                               
                               Payment payment,
                               bool allowSplitOrders,
                               bool receiptRequest)
        {
            Debug.Assert(customerRepository!=null, "Missing customerrepository instance");
            Debug.Assert(orderRepository != null, "Missing orderRepository instance");
            Debug.Assert(inventoryRepository != null, "Missing inventoryRepository instance");
            Debug.Assert(payment != null, "Missing payment instance");
            //veikia tik debug mode //ismes lentele su stacks

            var op = new OperationResult();

            if (customer == null) throw new ArgumentNullException("Customer instance is null");
            if (order == null) throw new ArgumentNullException("Order instance is null");
            if (payment == null) throw new ArgumentNullException("Payment instance is null");

            customerRepository.Add(customer);            
            orderRepository.Add(order);           
            inventoryRepository.OrderItems(order, allowSplitOrders);

            payment.ProcessPayment();

            if (receiptRequest)
            {
                
                var result = customer.ValidateEmail();
                //ref ir out nerekomenduojami code smell

                if (result.Success)
                {
                    customerRepository.Update();
                    emailLibrary.SendEmail(customer.EmailAddress, "Cia yra Receipt");
                }
                else
                {
                    if (result.MessageList.Any())
                    {
                        foreach (var message in result.MessageList)
                        {
                            op.MessageList.Add(message);
                        }
                    }
                }
                
            }
            return op;
        }

        private CustomerRepository customerRepository { get; set; }
        private OrderRepository orderRepository { get; set; }
        private InventoryRepository inventoryRepository { get; set; }
        private EmailLibrary emailLibrary { get; set; }
    }
}
