using Shop.Web.Products.Models;

namespace Shop.Web.Cart.Models;

public class CartItem
{
       public int Quantity { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public string UserId { get; set; }
        public int? CartId { get; set; }
        public int Id { get; set; }
}