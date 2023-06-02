using webShop.BussinessLogic.Interfaces;

namespace webShop.BussinessLogic.Bridge
{
     public class PayPalPayment : IPaymentMethod
     {
          public string ProcessPayment()
          {
               return "The transaction from your PayPal wallet has been successfully processed.";
          }
     }
}
