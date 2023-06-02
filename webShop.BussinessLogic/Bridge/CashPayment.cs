using webShop.BussinessLogic.Interfaces;

namespace webShop.BussinessLogic.Bridge
{
     public class CashPayment : IPaymentMethod
     {
          public string ProcessPayment()
          {
               return "Cash payment will be processed upon delivery.";
          }
     }
}
