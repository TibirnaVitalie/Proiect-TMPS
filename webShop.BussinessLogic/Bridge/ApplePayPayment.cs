using webShop.BussinessLogic.Interfaces;

namespace webShop.BussinessLogic.Bridge
{
     public class ApplePayPayment : IPaymentMethod
     {
          public string ProcessPayment()
          {
               return "The transaction from your Apple Pay account has been successfully processed.";
          }
     }
}
