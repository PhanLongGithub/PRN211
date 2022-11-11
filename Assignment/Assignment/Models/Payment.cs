using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentId { get; set; }
        public string? Name { get; set; }
        public string? CardNo { get; set; }
        public string? ExpiryDate { get; set; }
        public int? CvvNo { get; set; }
        public string? Address { get; set; }
        public string? PaymentMode { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
