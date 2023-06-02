using webShop.BussinessLogic.Interfaces;
using webShop.BussinessLogic.Iterator.Cart;

namespace webShop.BussinessLogic.Bridge
{
     public class ProductOrder: Order
     {
          public ProductOrder(IPaymentMethod paymentMethod, CartProductCollection cartProducts) : base(paymentMethod, cartProducts)
          {
          }

          public override string DisplayOrderDetails(string paymentStatus)
          {
               int sum = 0;

               foreach(var obj in this.CartProducts)
               {
                    sum += obj.Price;
               }

               return $"{paymentStatus} Total amount of the order: {sum}$. Product will be delivered in 5-7 days";
          }
     }
}
