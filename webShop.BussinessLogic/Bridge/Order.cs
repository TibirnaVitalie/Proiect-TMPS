using webShop.BussinessLogic.Interfaces;
using webShop.BussinessLogic.Iterator.Cart;

namespace webShop.BussinessLogic.Bridge
{
     public abstract class Order
     {
          public IPaymentMethod PaymentMethod;
          public CartProductCollection CartProducts;

          public Order(IPaymentMethod paymentMethod, CartProductCollection cartProducts)
          {
               this.PaymentMethod = paymentMethod;
               this.CartProducts = cartProducts;
          }

          public abstract string DisplayOrderDetails(string paymentStatus);
     }
}
