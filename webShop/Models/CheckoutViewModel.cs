using Microsoft.AspNetCore.Mvc.Rendering;
using webShop.Domain.Enums;

namespace webShop.Models
{
     public class CheckoutViewModel: ProductViewModel
     {
          public PaymentMethod PaymentMethod { get; set; }

          public List<SelectListItem> Payments { get;  set; }
     }
}
