using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public enum PaymentType
    {
        CreditCard =1,
        Paypal
    }
    

    public class Payment
    {
        public int PaymentType { get; set; }

     

        public void ProcessPayment()
        {
            PaymentType paymentTypeOption;
            
            //if (!Enum.IsDefined(typeof(PaymantType), this.PaymentType)) //use reflection isdefined geriau nenaudotidaug resursu naudoja
            if(!Enum.TryParse(this.PaymentType.ToString(), out paymentTypeOption))
            {
                throw new InvalidEnumArgumentException("Payment type", (int)this.PaymentType, typeof(PaymentType));
            }

            //if (Enum.TryParse("creditcard", true, out paymentTypeOption))
            //{
            //    throw new InvalidEnumArgumentException("Payment type", (int)this.PaymentType, typeof(PaymantType));
            //}

            switch (paymentTypeOption)
            {
                case ACM.BL.PaymentType.CreditCard:
                    //Process CreditCard
                    break;
                case ACM.BL.PaymentType.Paypal:
                    //process Paypal
                    break;
                default:
                    throw new ArgumentException();
                    break;
            }
        }
    }
}
