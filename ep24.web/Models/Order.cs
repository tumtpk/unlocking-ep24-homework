using System;
using System.Collections.Generic;

namespace ep24.web.Models
{
    public class Order
    {
        public string Id { get; set; }
        public IEnumerable<Product> OrderedProducts { get; set; }
        public string Username { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public string ReferenceCode { get; set; }
    }
}