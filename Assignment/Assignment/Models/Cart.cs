using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public int? UserId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }

        public Cart(int? productId, int? quantity, int? userId)
        {
            ProductId = productId;
            Quantity = quantity;
            UserId = userId;
        }
    }
}
