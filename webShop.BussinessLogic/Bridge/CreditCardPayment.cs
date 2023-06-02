using webShop.BussinessLogic.Interfaces;

namespace webShop.BussinessLogic.Bridge
{
     public class CreditCardPayment : IPaymentMethod
     {
          public string ProcessPayment()
          {
               return "The transaction from your card has been successfully processed.";
          }
     }
}
