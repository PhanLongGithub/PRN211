using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public string? ContactName { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
