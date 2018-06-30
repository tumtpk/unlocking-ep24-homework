using System;
using System.Collections.Generic;

namespace ep24.web.Models
{
    public class OrderProductRequest
    {
        public IEnumerable<KeyValuePair<int, int>> OrderedProducts { get; set; }
        public string Username { get; set; }
    }
}